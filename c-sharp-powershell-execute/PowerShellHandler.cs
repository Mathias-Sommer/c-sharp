using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace PowershellShowcase;

public static class PowerShellHandler
{
    private static readonly PowerShell _ps = PowerShell.Create();

    public static string Command(string script)
    {
        string errorMsg = string.Empty;

        _ps.AddScript(script);

        //Make sure return values are outputted to the stream captured by C#
        _ps.AddCommand("Out-String");

        PSDataCollection<PSObject> outputCollection = new();
        _ps.Streams.Error.DataAdded += (object sender, DataAddedEventArgs e) =>
        {
            errorMsg = ((PSDataCollection<ErrorRecord>)sender)[e.Index].ToString();
        };


        IAsyncResult result = _ps.BeginInvoke<PSObject, PSObject>(null, outputCollection);

        //Wait for powershell command/script to finish executing
        _ps.EndInvoke(result);

        StringBuilder sb = new();

        foreach (var outputItem in outputCollection)
        {
            sb.AppendLine(outputItem.BaseObject.ToString());
        }

        //Clears the commands we added to the powershell runspace so it's empty the next time we use it
        _ps.Commands.Clear();

        //If an error is encountered, return it
        if (!string.IsNullOrEmpty(errorMsg))
            return errorMsg;

        return sb.ToString().Trim();

    }

    private static IEnumerable<PSObject> RunScript(string script)
    {
        using var powerShell = PowerShell.Create();
        powerShell.AddScript(script);

        var outputCollection = new PSDataCollection<PSObject>();
        var errorMsg = string.Empty;

        powerShell.Streams.Error.DataAdded += (sender, e) =>
        {
            errorMsg = ((PSDataCollection<ErrorRecord>)sender)[e.Index].ToString();
        };

        IAsyncResult result = powerShell.BeginInvoke<PSObject, PSObject>(null, outputCollection);

        // Wait for PowerShell command/script to finish executing
        powerShell.EndInvoke(result);

        if (!string.IsNullOrEmpty(errorMsg))
        {
            Console.WriteLine($"PowerShell error: {errorMsg}");
            throw new InvalidOperationException($"PowerShell error: {errorMsg}");
        }

        return outputCollection;
    }
    public static Dictionary<string, string> GetUserInfo(string samAccountName)
    {
        // Script to get user information
        string userScript = $"Get-ADUser -Identity {samAccountName} -Properties *";
        var result = RunScript(userScript);
        string managerDistinguishedName = null;
        var properties = new Dictionary<string, string>();

        foreach (var psObject in result)
        {
            // can add more properties here if needed
            foreach (var propertyName in new[] { "Name", "SamAccountName", "EmailAddress", "DisplayName", "Manager", "Enabled", "Surname" })
            {
                var property = psObject.Properties[propertyName];
                if (propertyName == "Manager")
                {
                    // Get the manager's distinguished name if available
                    managerDistinguishedName = property?.Value?.ToString();
                }
                else
                {
                    try
                    {
                        properties[propertyName] = property?.Value?.ToString() ?? "N/A";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: Exception getting \"{propertyName}\": {ex.Message}");
                        properties[propertyName] = "N/A";
                    }
                }
            }
        }

        // If manager's distinguished name is available, get the manager's name
        if (!string.IsNullOrEmpty(managerDistinguishedName))
        {
            // Adjust script to get the manager's name only
            string managerScript = $"Get-ADUser -Identity \"{managerDistinguishedName}\" -Properties Name | Select-Object -ExpandProperty Name";
            var managerResult = RunScript(managerScript);

            if (managerResult.Any())
            {
                properties["Manager"] = managerResult.First().BaseObject.ToString();
            }
            else
            {
                properties["Manager"] = "N/A";
            }
        }
        else
        {
            properties["Manager"] = "N/A";
        }

        return properties;
    }

    public static IEnumerable<string> GetUserGroups(string samAccountName)
    {
        // Use Get-ADPrincipalGroupMembership to get the group names
        string script = $"Get-ADUser -Identity {samAccountName} | Get-ADPrincipalGroupMembership | Select-Object -ExpandProperty Name";
        var result = RunScript(script);

        var groups = new List<string>();

        foreach (var psObject in result)
        {
            Console.WriteLine(psObject.BaseObject);

            foreach (var property in psObject.Properties)
            {
                if (property.Value is string group)
                {
                    groups.Add(group);
                }
                else if (property.Value is IEnumerable<object> collection)
                {
                    foreach (var item in collection)
                    {
                        groups.Add(item.ToString());
                    }
                }
            }
        }

        foreach (var group in groups)
        {
            Console.WriteLine($"Group: {group}");
        }

        return groups;
    }
}
