# Movie-Management-System-using-ASP.NET-Core-MVC-and-ASP.NET-Web-API
This project is an Online Movie Management System (MMS). It is a web application developed using ASP.NET Web API implementing MVC (Model-View-Controller) architecture and Entity Framework Core. 
To run This Application in your System, You need to go through the following steps:
1)Install Visual studio to run the application
2)Install SSMS to configure the SQL Database.
3)Change the Connection string of the Application in AppSettings.JSON file to your own connection string. The database name you input will be the name of the database going to be created in the sql server.
4)Click on the package manager console on Visual studio and now you need to execute the command add-migration "Message for migration"
5)Execute the command update-database after the migration.
6)Now if you open ssms you will see that the SQL database is created for this application.
7)Execute the file procedure.sql(uploaded in this repository) in this newly created database.
8)Your Application should be fully working now.
