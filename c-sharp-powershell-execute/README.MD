For running powershell code from C# app.

Prebuilt functions includes:
1. Get-ADUser
2. Get-ADPrincipalGroupMembership
3. Run powershell commands. 

(
--Get output with:
#string testings = PowerShell.Command($"get-aduser -identity {samAccountName} -properties *");
#Console.WriteLine(testings); --)

PowerShell.Command("winver"); // for opening winver.
