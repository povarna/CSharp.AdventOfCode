$year = 2015
$maxDay = 21
$parts = "-p 1 -p 2"

$currentLocation=Get-Location

Set-Location -Path $currentLocation/bin/Debug/net6.0

Get-Location

Write-Host("="*50)
for($i=1; $i -le $maxDay; $i++){
  if ($i -eq 13) {
    continue
  }
  Invoke-Expression -Command "dotnet ConsoleApp.dll solve -y $year -d $i $parts"
  Write-Host("="*50)
}
