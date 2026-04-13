param([Parameter(Mandatory = $true)] [string]$ConnectionString)

Write-Host "Applying migration..."

.\migrationBundle\efbundle.exe --connection $ConnectionString


if ($LASTEXITCODE -eq 0) {
    Write-Host "Migration has been applied successfully." -ForegroundColor Green
} else {
    Write-Host "Failed to apply migration." -ForegroundColor Red
}
