param($Server)


$tsenv = New-Object -COMObject Microsoft.SMS.TSEnvironment

$id = $tsenv.Value("OSDAnalyticsId")

$url = "$($Server)/api/v1/OSDMonitoring/Complete?EntryID=$($id)" 

$test= Invoke-RestMethod -Uri $url  -Method Get
if($test)
{
    exit 0
}

else
{
    exit 1
}