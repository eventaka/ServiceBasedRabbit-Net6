# ServiceBasedRabbit

This Rest service works in parallel of worker service called WorkerServiceBasedRabbitMQ.
The Rest service send data to the worker service through RabbitMQ, then it is saved in a local SqlServer Database.

It's recommanded to launch first the WorkerServiceBasedRabbitMQ.
For details, please go to WorkerServiceBasedRabbitMQ repository and open the Readme file.

 

## Technologies

* [ASP.NET Core 6]
* [Entity Framework Core 7]
* [RabbitMQ]
* [Docker]
* [LocalDB Sql Server]  



## Getting Started


### 1/4 - Downloading Applications and Installing RabbitMQ using Docker

#### RabbitMQ

1. Given that Docker is installed, we’ll open a command-line terminal and use the docker run command to spin up our server:
   docker run -d --hostname my-rabbitmq-server --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
2. Run command : docker start rabbitmq
3. Navigate to http://localhost:15672
4. Login as guest (Username : guest, Password : guest)


#### ServiceBasedRabbit application

1. Download the ServiceBasedRabbit application
2. Open Windows command prompt and go to : ServiceBasedRabbit.api folder
3. Launch dotnet run  
4. Navigate to : http://localhost:5195/swagger/index.html


#### WorkerServiceBasedRabbitMQ application

1. Download the WorkerServiceBasedRabbitMQ application
2. Open Windows command prompt and go to : WorkerServiceBasedRabbitMQ folder
3. Launch dotnet run  



### 2/4 - Database Configuration

WorkerServiceBasedRabbitMQ application is configured to use a (localDB) Sql Server database. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

Set up a local Sql Server Database:

1. Open Windows command prompt 
2. Launch sqllocaldb create "local"
3. Open MSSQL Management Studio
4. Connect to server : (localdb)\local 

 

### 3/4 - Database Migrations

This step is about to create the RabbitMQ Database in the LocalDB, before starting to use the applications:

2 ways for creating:

* From Visual Studio
1. Open Package Manager Console
2. Run PM> add-migration Migration-1
3. Run PM> Update-Database
4. Check RabbitMQ Database that is created
 
* From .Net CLI
1. Run dotnet ef migrations add Migration-1
2. Run dotnet ef database update
3. Check RabbitMQ Database that is created

 
### 4/4 - Now you can, use the applications !
 
1. Go to Rest Service ServiceBasedRabbit
2. Post a new User
3. Check WorkerServiceBasedRabbitMQ windows : you have to get the message (the user you just post).
4. Check the database, User table to see it has been created. 


N.B. I Apologize but for this moment, only Posting a new User is working.


## Overview

This project is designed using Clean Architecture.

 
