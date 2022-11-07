using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//--------------------------------------
// David Zientara
// 11-7-2022
//
// DapperProductRepository.cs
// Implementation file for 
// DapperProductRepository
// Contains constructor, CreateProduct,
// UpdateProduct, DeleteProduct
//
//--------------------------------------

namespace ORM_Dapper
{
    internal class DapperProductRepository : IProductRepository
    {
        public IDbConnection _conn;
        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        
        public IEnumerable<Product> GetAllProducts()
        {
            return (IEnumerable<Product>)_conn.Query<Models.Product>("SELECT * FROM PRODUCTS;");
        }
        public void CreateProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @id);",
                new { name = productToInsert.Name, price = productToInsert.Price, id = productToInsert.CategoryID});
        }
        public void UpdateProduct(Product product)
        {
            ///product.OnSale = 1;
            _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new { name = product.Name, price = product.Price, id = product.ProductID});
        }
        public void DeleteProduct(int pid) //Product product)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
                new { id = pid });

            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                new { id = pid });

            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;",
                new { id = pid });
                                       
        }

    }
}
