Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile 'dotnet-install.ps1'; ./dotnet-install.ps1 -Channel LTS -InstallDir 'C:\Program Files\dotnet'
$env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User")
If (!(Test-Path $Profile.CurrentUserAllHosts)) {New-Item -Path $Profile.CurrentUserAllHosts -Force}
Add-Content -Path $Profile.CurrentUserAllHosts -Value '$env:Path += \";C:\Program Files\dotnet;%USERPROFILE%\.dotnet\tools\"'
Invoke-WebRequest 'https://github.com/PowerShell/PowerShell/releases/download/v7.3.7/PowerShell-7.3.7-win-x64.msi' -OutFile 'PowerShell-7.3.7-win-x64.msi' ; ./PowerShell-7.3.7-win-x64.msi /quiet ADD_EXPLORER_CONTEXT_MENU_OPENPOWERSHELL=1 ADD_FILE_CONTEXT_MENU_RUNPOWERSHELL=1 ENABLE_PSREMOTING=1 REGISTER_MANIFEST=1 USE_MU=1 ENABLE_MU=1 ADD_PATH=1