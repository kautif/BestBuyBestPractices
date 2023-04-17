using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartementRepository(conn);

departmentRepo.InsertDepartment("Bobs");

var departments = departmentRepo.GetAllDepartments();

foreach (var dept in departments) 
{
    Console.WriteLine(dept.DepartmentID);
    Console.WriteLine(dept.Name);
}
