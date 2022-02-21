Param($Server)

$tsenv = New-Object -COMObject Microsoft.SMS.TSEnvironment

$object = New-Object -TypeName PSObject
$object | Add-Member -MemberType NoteProperty -Name OSDComputername -Value $tsenv.Value("OSDComputerName")
$object | Add-Member -MemberType NoteProperty -Name Minitntname -Value $tsenv.Value("_SMSTSMachineName")
$object | Add-Member -MemberType NoteProperty -Name tasksequenceName -Value $tsenv.Value("_SMSTSPackageName")
$object | Add-Member -MemberType NoteProperty -Name tasksequenceID -Value $tsenv.Value("_SMSTSPackageID")
$object | Add-Member -MemberType NoteProperty -Name Make -Value $tsenv.Value("_SMSTSMake")
$object | Add-Member -MemberType NoteProperty -Name Model -Value $tsenv.Value("_SMSTSModel")
$object | Add-Member -MemberType NoteProperty -Name Serial -Value (Get-CimInstance -ClassName Win32_BIOS | Select-Object SerialNumber).SerialNumber


$values =@()
$values += $object
$valueobject = $values | ConvertTo-Json

$url = "$($Server)/api/v1/OSDMonitoring/Start?values=$($valueobject)"

$id= Invoke-RestMethod -Uri $url  -Method Get
$tsenv.Value("OSDAnalyticsId")=$id