![alt text](https://github.com/cesarma/ng-hawksoft/blob/master/HawkSoftContactListAngular/Capture01.PNG?raw=true)

NG-HawkSoft <br/>
The application was developed on angular 8, .net core, EF and Sql server.
Steps:<br/>
We need to run dotnet ef update
in order to create and populate the database with mock data
Run
dot net run to compile and extract all the npm (packages)
<br/>

I expect time setting up my environment as well as compiling and setting my account on git hub, I did not finbsihed the part of update (form and wrap the service)
<br/>
all the webapis can be tested through swagger
<br/>
Regarding with the question to escalate the app, there are different approaches Ny recommendation use MSMQ,Mrabbit (it is not supported on .net core)  or ServiceBus. in order to dosen't lose data.
<br/>
The pagination work better if we use EF pagination the data, thought the webapi

GITHUB -NG-Hawksoft<br/>

https://github.com/cesarma/ng-hawksoft


WebApi-testing<br/>

http://localhost:3298/swagger/index.html

App<br/>
http://localhost:3298

