# OSDAnalytics

DISCLAIMER: These scripts/code/templates serve as an example on how you can implement a OSD reporting solution for ConfigMgr or MDT. These are not production ready and can break stuff, Use at your own Risk.

DISCLAIMER2: the WebApi as provided here is NOT secured and anyone can Start/Complete/Fail a TS if they know the GUID.

## Introduction

This toolset will allow to create "better" reporting for Tasksequences in MEMCM, the native reports do provide a lot of information, but it can be tough to find trends in there because task sequences & computer resources get deleted and the information get lost.

This toolkit creates a separate DB + tables as well as a webservice, combined with some powershell script to run during the TS to capture information.
PowerBi (or other reporting tools) can then be used to analyze the information.

## Pre-reqs

  - A Database host Like SQL Server, SQL Express or Azure SQL.
  - A Webserver to host the WebApi like IIS (Probably Azure, Linux or docker containers work as well but just not tested).
  - PowerBi Desktop
  - Some MEMCM Knowledge

## Getting Started

### Installing the Database
The quickest way to install the DB is to open SQL Management studio, logon to you SQL server and run the script in the [SQLScripts](https://github.com/kurtdepre/OSDAnalytics/tree/main/SQLScripts) folder. 
Make sure you have Either a SQL login that has write permisions to the freshly created DB or a Windows Login(that will be used to run the WebApi also)

### Installing the WebApi
1. Copy the content of the [Webservice Binaries](https://github.com/kurtdepre/OSDAnalytics/tree/main/WebService%20Binaries) folder to a location on your webserver.
2. Change the connectionstring in the appsettings.json file to point to your environment
3. Make sure IIS is installed & running.
4. Create a new application pool in IIS. (if you use Windows auth for your DB, make sure it is running under an account that has access to the database).
5. Create a website in IIS and point it to the folder used in step 1.
6. Test the webApi by browsing to it 
7. Test DB connectivity from webservice
8. Clean the testrecords from the DB (Warning this will delete all data in the DB)


### Import the template TS or Create your own
The next step is to adapt your Tasksequences to include the monitoring steps.
you can import the template from the folder [Example TS Export](https://github.com/kurtdepre/OSDAnalytics/tree/main/Example%20TS%20Export), to see how to do this.
Don't forget to change the URL of the webApi to your server.

### Create Reports

### Cleaning up timed out OSD 
Todo
## Customizing the data reported
Todo


