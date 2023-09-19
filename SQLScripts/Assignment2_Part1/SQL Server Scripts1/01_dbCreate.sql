USE [master]
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'SuperheroesDb')

/* removes all connections and rolls back all transactions */
ALTER DATABASE SuperheroesDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE SuperheroesDb;
CREATE DATABASE SuperheroesDb;
GO