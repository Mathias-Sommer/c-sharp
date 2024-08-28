using System.Management;

string? userDomain, computerName, userName;
long uptimeMilliseconds;

userDomain = Environment.GetEnvironmentVariable("USERDOMAIN");
computerName = Environment.GetEnvironmentVariable("COMPUTERNAME");
userName = Environment.UserName;
uptimeMilliseconds = Environment.TickCount64;

TimeSpan uptime = TimeSpan.FromMilliseconds(uptimeMilliseconds);

Console.WriteLine("Current user: " + userName);
Console.WriteLine("Computername: " + userDomain + "\\" + computerName);
Console.WriteLine("System Uptime: " + uptime.ToString(@"dd\.hh\:mm\:ss"));

// Suppress CA1416 warning for this section of the code
#pragma warning disable CA1416

// Iterate through all drives
foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    // Check if the drive is a network drive
    if (drive.DriveType == DriveType.Network)
    {
        // Output the drive letter and network path in one line
        string? networkPath = "Unknown Path";
        try
        {
            using (var searcher = new ManagementObjectSearcher(
                $"SELECT * FROM Win32_NetworkConnection WHERE LocalName = '{drive.Name.TrimEnd('\\')}'"))
            {
                foreach (var queryObj in searcher.Get())
                {
                    networkPath = queryObj["RemoteName"]?.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving network path: {ex.Message}");
        }

        // Print drive letter and network path
        Console.WriteLine($"Drive Letter: {drive.Name.TrimEnd('\\')} - Network Path: {networkPath}");

        // List the contents of the drive
        Console.WriteLine("Contents of the drive:");
        try
        {
            // Get directories and files
            var directories = Directory.GetDirectories(drive.Name);
            var files = Directory.GetFiles(drive.Name);

            // List directories
            foreach (var dir in directories)
            {
                Console.WriteLine($"Directory: {Path.GetFileName(dir)}");
            }

            // List files
            foreach (var file in files)
            {
                Console.WriteLine($"File: {Path.GetFileName(file)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error listing contents: {ex.Message}");
        }

        Console.WriteLine();
    }
}

// Re-enable CA1416 warning
#pragma warning restore CA1416
