using System;
using System.Collections.Generic;
using System.Management.Automation;
using PowerShell = PowershellShowcase.PowerShellHandler;

namespace PowershellShowcase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter SamAccountName: ");
            string samAccountName = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(samAccountName))
            {
                Console.WriteLine("SamAccountName cannot be empty.");
                return;
            }

            try
            {
                // Get user information
                var userInfo = PowerShellHandler.GetUserInfo(samAccountName);

                // Output user information
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nUser Information:");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (var property in userInfo)
                {
                    Console.WriteLine($"{property.Key}: {property.Value}");
                }

                // Get user groups
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nUser Groups:");
                Console.ForegroundColor = ConsoleColor.White;
                var userGroups = PowerShellHandler.GetUserGroups(samAccountName);

            }
            catch (Exception ex)
            {
                // Handle errors
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            string testings = PowerShell.Command($"get-aduser -identity {samAccountName} -properties *");

            // invoke powershell command if you dont wanna use the functions premade
            PowerShell.Command("winver");


            Console.WriteLine("\n\n" + testings);
            Console.ReadKey();
        }
    }
}
