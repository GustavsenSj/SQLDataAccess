// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using SQLDataAccess.DB;
using SQLDataAccess.Models;
using SQLDataAccess.Repositories;
using SQLDataAccess.Service;

DatabaseConnection dbConnection = new DatabaseConnection(GetConnectionString());
string GetConnectionString()
{
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
    {
        DataSource = "N-NO-01-03-2688",
        InitialCatalog = "Chinook",
        IntegratedSecurity = true,
        TrustServerCertificate = true
    };
    return builder.ConnectionString;
}