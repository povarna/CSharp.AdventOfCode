#TODO: Replace this with an argument
$year = 2015
$maxDay = 21
$parts = 1,2
$separator = "="*50

$dotnetVersion="net6.0"

$currentLocation=Get-Location

Set-Location -Path $currentLocation/bin/Debug/$dotnetVersion

Write-Host($separator)
for($i=1; $i -le $maxDay; $i++){
  foreach ($part in $parts)
  {
    Invoke-Expression -Command "dotnet ConsoleApp.dll solve -y $year -d $i -p $part"
  }
  Write-Host($separator)
}
Set-Location -Path $currentLocation

