# HawkSoftContactListAngular

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 8.3.26
The application was developed on angular 8, .net core, EF and Sql server.
Steps:
We need to run dotnet ef update
in order to create and populate the database with mock data
Run
dot net run to compile and extract all the npm (packages)


I spend time setting up my environment as well as compiling and setting my account on git hub, I did not finbsihed the part of update (form and wrap the service)

all the webapis can be tested through swagger

Regarding with the question to escalate the app, there are different approaches My recommendation use MSMQ,Mrabbit (it is not supported on .net core)  or ServiceBus. in order to dosen't lose data.

The pagination work better if we use EF pagination the data, thought the webapi

GITHUB -NG-Hawksoft

##prerequirements
Node > 10.9.0 or later.
Angular 8
Angular cli 8.23
SQL Express
MSQL Managanment Studio
##Database and populate database
cmd
dotnet ef database update 

##Generate artifacta
dotnet ef migrations add InitialCreater

##Drop database artifacta
dotnet ef database drop

## Development 

http://localhost:3298/

##Swagger Test Web Apis
http://localhost:3298/swagger


##Execute
Open Visual studio and run the application
or
dotnet run


## Troubleshooting



