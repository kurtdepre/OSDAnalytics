# OSDAnalytics

DISCLAIMER: These scripts/code/templates serve as an example on how you can implement a OSD reporting solution for ConfigMgr or MDT. These are not production ready and can break stuff, Use at your own Risk.

DISCLAIMER 2: the WebApi as provided in this example is NOT secured and anyone can Start/Complete/Fail a TS if they know the GUID.

## 1. Introduction

This toolset will allow to create "better" reporting for Tasksequences in MEMCM, the native reports do provide a lot of information, but it can be tough to find trends in there because task sequences & computer resources get deleted and the information get lost.

This toolkit creates a separate DB + tables as well as a webservice (My network admins/DBAs don't like direct writes to the DB and would not allow the trafic), combined with some powershell script to run during the TS to capture information.
PowerBi (or other reporting tools) can then be used to analyze the information.

## 2. Pre-reqs

  - A Database host Like SQL Server, SQL Express or Azure SQL.
  - A Webserver to host the WebApi like IIS (Probably Azure, Linux or docker containers work as well but just not tested).
  - PowerBI Desktop
  - Some Basic IIS, MEMCM, SQL & Power BI Knowledge

## 3. Getting Started

### 4. Installing the Database

The quickest way to install the DB is to open SQL Management studio, logon to you SQL server and run the CreateDBAndTables.sql script in the [SQLScripts](https://github.com/kurtdepre/OSDAnalytics/tree/main/SQLScripts) folder. 
Make sure you have Either a SQL login that has write permisions to the freshly created DB or a Windows Login(that will be used to run the WebApi also)

### 5. Installing the WebApi

1. Copy the content of the [Webservice Binaries](https://github.com/kurtdepre/OSDAnalytics/tree/main/WebService%20Binaries) folder to a location on your webserver.
2. Change the "DBConnection" in the appsettings.json file to point to your environment.
3. Make sure IIS is installed & running.
4. install the [ASP.net Core Hosting bunddle](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.2-windows-hosting-bundle-installer)
5. [Create a new application pool in IIS](iis-pool-settings) 

6. Create a website in IIS and point it to the folder used in step 1. (Use the application pool create in step 5)
7. [Test DB connectivity from webservice](#test-connectivity)
8. Clean the testrecords from the DB (Warning this will delete all data in the DB) using the TruncateAfterTest.sql script found in the [SQLScripts](https://github.com/kurtdepre/OSDAnalytics/tree/main/SQLScripts) folder. 


### 6. Import the template TS or Create your own

<Todo Add more info>
The next step is to adapt your Tasksequences to include the monitoring steps.
you can import the template from the folder [Example TS Export](https://github.com/kurtdepre/OSDAnalytics/tree/main/Example%20TS%20Export), to see how to do this.
Don't forget to change the URL of the webApi to point to your server.

### 7. Create Reports
  
- Import the open the power BI template found in the [PowerBi](https://github.com/kurtdepre/OSDAnalytics/tree/main/PowerBI) folder, and enter the parameters requested.
- Save your report
- If applicable publish to the power BI service.

### 8. Cleaning up timed out OSD 
  
<TO add more info>
Sometimes staging never finish (Network issue, hard crash, TS does not start again after reboot). For this we can schedule a script that automatically Fails all OSD sessions running for more then 48 hours.
see the script Timeout.ps1 in folder [Powershell Scripts](https://github.com/kurtdepre/OSDAnalytics/tree/main/Powershell%20Scripts), This can be run as sheduled taks to perform this cleanup.

## Customizing the data in the dashboard

1. Edit the StartMonitoring script, add a line $object | Add-Member -MemberType NoteProperty -Name <NameOfyourField> -Value '<ValueOfYourField>' for each additional property to capture.
  ![image](https://user-images.githubusercontent.com/56970265/154999634-6b88eda4-836b-4611-abbc-1dd5e99ac5a7.png)
2. Open the power BI report -> Transform Data ->Transform Data
3. Click on the little wheel next to source in the applied steps section
![image](https://user-images.githubusercontent.com/56970265/154997769-6ea297ee-9782-485c-8655-433b1c20585b.png)
4. Add a line 'JSON_VALUE(Data, '$.<NameOfYourField>') AS <NameOfYourField>,' the below JSON_VALUE(Data, '$.Model') AS Model, in the SQL statement field.
![image](https://user-images.githubusercontent.com/56970265/154998204-378766a8-eefa-4fc2-b8e0-47879a7673b1.png)
5. Pray to the SQL Gods
6. Apply changes
7. Use your new field in the dashboard.

## IIS Pool Settings
  
If you use Windows auth for your DB, make sure it is running under an account that has access to the database.
### Windows Auth
To add more info
![AppPool1](https://user-images.githubusercontent.com/56970265/155001788-fa49a405-654c-45c2-bb80-a2c0ef803377.PNG)

## Test Connectivity
  
1. Browse to http(s)://yourserver/
2. Click on the arrow to expand the StartMonitoring section
  ![image](https://user-images.githubusercontent.com/56970265/155000052-55bdec7b-3342-4ba6-92ee-ce64fc1cebbc.png)
3. Click on the Try it out button
  ![image](https://user-images.githubusercontent.com/56970265/155000190-c6074cfc-addc-44bd-a868-2ee311365f83.png)
4. Fill a dummy value in the request field and press execute
  ![image](https://user-images.githubusercontent.com/56970265/155000319-0f021193-dc92-4c59-a8a5-08076837bd65.png)
5. The response should be a code 200 and contain a guid (unique on each run)
  ![image](https://user-images.githubusercontent.com/56970265/155000496-b8f4cd53-da55-45de-ad8a-5e6b26445355.png)
6. Congratz your WebApi is working
  
  
  
  

