Param (
	[Datetime]$pointintime = (Get-Date).AddMinutes(-1),
	[string]$servername = $(throw "Please provide a server name."),
	[string]$databasename=$(throw "Please provide a database name."), 
	[string]$restoreddatabasename = "$databasename-restored",
	[string]$resourcegroupname = $(throw "Please provide a resource group name."),
	[string]$restoretoedition = "Standard",
	[string]$restoretoserviceobjective = "S1"
)

try {
	$Database = Get-AzureRmSqlDatabase `
		-ResourceGroupName $resourcegroupname `
		-ServerName $servername `
		-DatabaseName $databasename

	Restore-AzureRmSqlDatabase `
		-FromPointInTimeBackup `
		-PointInTime $pointintime `
		-ResourceGroupName $Database.ResourceGroupName `
		-ServerName $Database.ServerName  `
		-TargetDatabaseName $restoreddatabasename `
		-ResourceId $Database.ResourceID `
		-Edition $restoretoedition `
		-ServiceObjectiveName $restoretoserviceobjective

} catch { Write-Error $_ }