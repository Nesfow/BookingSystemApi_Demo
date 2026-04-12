param([Parameter(Mandatory = $true)] [string]$Name)

Write-Host "Creating migration: $Name..."

dotnet ef migrations add $Name `
    --project ".\src\Infrastructure" `
    --output-dir ".\Migrations" `
    --startup-project ".\src\Api" `
    --context "BookingSystemDbContext"

if ($LASTEXITCODE -eq 0) {
    Write-Host "Migration '$Name' created successfully." -ForegroundColor Green
} else {
    Write-Host "Failed to create migration." -ForegroundColor Red
}

dotnet ef migrations bundle `
    --project ".\src\Infrastructure" `
    --startup-project ".\src\Api" `
    --context "BookingSystemDbContext" `
    --output ".\migrationBundle\efbundle.exe" `
    --force `
    --no-build