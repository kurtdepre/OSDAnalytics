param($Server)

$tsenv = New-Object -COMObject Microsoft.SMS.TSEnvironment

$id = $tsenv.Value("OSDAnalyticsId")
$message = $tsenv.Value("_SMSTSLastActionName")

$url = "$($Server)/api/v1/OSDMonitoring/Fail?EntryID=$($id)&Message=$($message)"

$test= Invoke-RestMethod -Uri $url  -Method Get
if($test)
{
    exit 0
}

else
{
    exit 1
}