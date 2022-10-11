using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        void InsertDepartment(int ProductID, string name, double price, int categoryID, int OnSale, char StockLevel);
    }
}
