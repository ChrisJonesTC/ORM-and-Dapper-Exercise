using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }

        public void InsertDepartment(int ProductID, string name, double price, int categoryID, int OnSale, char StockLevel)
        {
            _conn.Execute("INSERT INTO departments (name) VALUES (@name)", new { name = name });
        }
    }
}
