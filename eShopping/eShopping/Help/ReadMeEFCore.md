EF Core 3.1
- Database First Approach
	- Generate EF Core Entities using the database schema
	- The following command to generate the Entities from database schema (table)
		- Using .NET Core CLI
		- the 'dotnet' command
		- Microsoft.EntityFrameworkCore
		- Microsoft.EntityFrameworkCore.Ralational
		- Microsoft.EntityFrameworkCore.SqlServer
		- Microsoft.EntityFrameworkCore.Tools
		- Microsoft.EntityFrameworkCore.Design
- Vanilla Machine with .Net Core 3.1 SDK
	- TO install dotnet ef cli, run the following command
		- dotnet tool install --global dotnet-ef
- Database First Scaffolding

	dotnet ef dbcontext scaffold "<Connection String>"
			Microsoft.EntityFrameworCore.SqlServer 
		-o Models -t <TableName> -t <TableName> 
		--context-dir Context -c <CLASS-NAME>

-o is the Output Directory where all model classes will be stored
-t table name from which entity/model classes will be generated (Default is all table)
--conetext-dir is the name of the directory where the context class will be generated
	(defailt is root of the project)
-c is the name of the context class

Example Command
dotnet ef dbcontext scaffold 
"Data Source=.;Initial Catalog=Company;Integrated Security=SSPI;"
 Microsoft.EntityFrameworkCore.SqlServer
-o Models -t Department -t Employee 
--context-dir Context -c CompnayDbContext

===================================================================================
DbContext is the base class
- Manage DB Conection
- Manage the CLR Object (aka Entity/Model classes) with Db Tables using
	DbSet<T> class
- DbSet<T> is a cursor that will store the data from tables in Application Server 
	- T is the name of the CLR Object that will be mapped with theDb Table of name T
- Manages Db Transaction using 
	- SaveChanges(), the Sync transactions
	- SaveChangesAsync(), the Async Transactions
- CRUD Operations using DbSet<T> methods
	- DbSet<T>.Add() / AddAsync()
	- DbSet<T>.Remove()
	- DbSet<T>.Find() / FindAsync()

=====================================================================================
EF Core Features
1. Flexible Object Mapping
	- Usie the Prtivate members of the class to generate the Table Schema 
		by using the public wrapper methods
2. Table Splitting 

3. The Code-First MIgrations
	- Map the CLR Object to Table by generating table
	- Update migration for each CLR Object updates

Commands for Migrations

1. Generate Migrations

dotnet ef migrations add <NAME> -c <COntext-Class>

e.g.

dotnet ef migrations add  MyMigration -c CS_EFCore_Migrations.Models.ShoppingDbContext

Migration command will ganarate migration class 
and the CLR object to Table Mapping class with constrits 

2. Update Database

dotnet ef database update -c <COntext-Class>

e.g.

dotnet ef database update -c CS_EFCore_Migrations.Models.ShoppingDbContext


