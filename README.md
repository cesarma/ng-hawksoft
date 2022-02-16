![alt text](https://github.com/cesarma/ng-hawksoft/blob/master/HawkSoftContactListAngular/Capture01.PNG?raw=true)

<b>NG-HawkSoft</b> <br/>
The application was developed on angular 8, .net core, EF(Migrations) and Sql server.
I have deployed the app using AzureDev Ops
<a href='https://cesarma.azurewebsites.net/' target='_blank'>https://cesarma.azurewebsites.net/</a>
<br/>
<b>Steps:</b><br/>
We need to run <br/>
dotnet ef update<br/>
in order to create and populate the database with mock data
<br/>
Run<br/>
dot net run 
<br/>to compile and extract all the npm (packages)

I spent time setting up my environment as well as compiling and setting my account on git hub, I did not finish the part of update (form and wrap the service)
<br/>
all the webapis can be tested through swagger
<br/>
Regarding with the question to escalate the app, there are differents approaches, My recommendation use MSMQ,Mrabbit (MSMQ  is not supported on .net core so far)  or ServiceBus. in order to dosen't lose data.
<br/>
The pagination work better if we use EF pagination the data, thought the webapi

<b>Notes</b>
<br/>
Regarding with the users I have created a table but I did not work on the log in because is not part of the scope but every contact has an id fk that need to be filled by default is 1,
Identity Service is a good approach<br/>
Regarding with EF we are using migrations .net core dosent support  sql proj so far other options is use DBup

GITHUB -NG-Hawksoft<br/>

https://github.com/cesarma/ng-hawksoft


WebApi-testing<br/>

http://localhost:3298/swagger/index.html

App<br/>
http://localhost:3298

