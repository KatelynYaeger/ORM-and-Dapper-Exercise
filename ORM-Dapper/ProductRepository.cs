using System;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
	public class ProductRepository : IProductRepository
	{
		private readonly IDbConnection _connection;


		public ProductRepository(IDbConnection connection)
		{
			_connection = connection;
		}

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (name, price, categoryID) VALUES ( @name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public void UpdateProductName(int productId, string updatedName)
        {
            _connection.Execute("UPDATE PRODUCTS SET name = @updatedName WHERE productID = @productID;",
                new { updatedName = @updatedName, productId = productId});
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM REVIEWS WHERE ProductID = @productID;",
                new {productID = productID});
            _connection.Execute("DELETE FROM SALES WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM PRODUCTS WHERE ProductID = @productID;",
                new { productID = productID });
        }

    }
}

