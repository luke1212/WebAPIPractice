# WebAPIPrectice
Database Setup Steps

Add Connection String  =>
Server=localhost;Database=Northwind;Uid=root;Pwd=root

Packages to install =>
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql

Install & Update dotnet EF tool =>
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

Scaffold MySQL Database =>
dotnet ef dbcontext scaffold MySQL Database =>
>> dotnet ef dbcontext scaffold Name=lukedb Pomelo.EntityFrameworkCore.MySql --output-dir Models --context-dir Data --namespace WebAPIPrectice.Models --context-namespace WebAPIPrectice.Data --context WebAPIContext -f --no-onconfiguring
