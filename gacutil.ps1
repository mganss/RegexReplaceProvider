[CmdletBinding()]
Param(
	[parameter(ParameterSetName="seta")][switch]$install,
	[parameter(ParameterSetName="setb")][switch]$uninstall,
	[switch]$quiet,
	[parameter(Mandatory=$true,Position=0)][string]$assemblyPath
)

[Reflection.Assembly]::LoadWithPartialName("System.EnterpriseServices") > $null
[System.EnterpriseServices.Internal.Publish] $publish = new-object System.EnterpriseServices.Internal.Publish

if (!$uninstall)
{
	$publish.GacInstall($assemblyPath)
	if (!$quiet) { Write-Host -ForegroundColor Green "Installed $assemblyPath into the GAC" }
}
else
{
	$publish.GacRemove($assemblyPath)
	if (!$quiet) { Write-Host -ForegroundColor Green "Removed $assemblyPath from the GAC" }
}
