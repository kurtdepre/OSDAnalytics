param($Server)


$url = "$($Server)/api/v1/OSDMonitoring/Timeout"

$test= Invoke-RestMethod -Uri $url  -Method Get
if($test)
{
    exit 0
}

else
{
    exit 1
}