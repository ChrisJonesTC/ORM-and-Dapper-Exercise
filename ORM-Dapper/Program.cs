﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("Misc Items");

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);

            }
            var productRepo = new DapperProductRepository(conn);

            var products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
            }
        }
    }
}