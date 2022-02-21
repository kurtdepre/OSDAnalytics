# OSDAnalytics

DISCLAIMER: These scripts/code/templates serve as an example on how you can implement a OSD reporting solution for ConfigMgr or MDT. These are not production ready and can break stuff, Use at your own Risk.

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
TODO
### Import the template TS or Create your own
TODO
### Create Reports

### Cleaning up timed out OSD 
Todo
## Customizing the data reported
Todo


