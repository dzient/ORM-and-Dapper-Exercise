using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

//--------------------------------------
// David Zientara
// 11-7-2022
//
// Program.cs
// 
// This connects to the Bestbuy SQL database
// and allows the user to create/delete/update a
// product
//
//--------------------------------------

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
           

            IDbConnection conn = new MySqlConnection(connString);
            DapperProductRepository dpr = new DapperProductRepository(conn);

            // A simple switch/case statement should do to test our methods:
            string? c;
            do
            {
                bool success = false;
                Console.WriteLine("[C]reate a product, [D]elete a product, [U]pdate a product, or [Q]uit? ");
                c = Console.ReadLine().ToString().ToUpper();
                switch (c)
                {
                    case "C":
                        // Use try/catch for user input:
                        Console.WriteLine("Enter product name: ");
                        string product="";
                        try
                        {
                            do
                            {
                                product = Console.ReadLine().ToString();
                            } while (product == null);
                        } 
                        catch (System.NullReferenceException)
                        {
                            Console.WriteLine("Null reference exception.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unknown error: " + ex.Message);
                        }
                        Console.WriteLine("Enter price: ");
                        double _price=0;
                        string str = "";
                        try
                        {
                            str = Console.ReadLine();
                            do
                            {
                                success = double.TryParse(str, out _price);
                            } while (!success);
                        }
                        catch (System.NullReferenceException)
                        {
                            Console.WriteLine("Null reference exception.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unknown error: " + ex.Message);
                        }
                        Product prod = new Product();
                        prod.Name = product;
                        prod.Price = _price;
                        prod.CategoryID = 1;
                        //Use try/catch for the DB call: 
                        try
                        {
                            dpr.CreateProduct(prod);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unknown error: " + ex.Message);
                        }
                        break;
                    case "D":
                        // Use try/catch for user input:
                        Console.WriteLine("Enter product ID: ");
                        int id = -1;
                        try
                        {
                            str = Console.ReadLine();
                            do
                            {
                                success = int.TryParse(str, out id);
                            } while (!success);
                        }
                        catch (System.NullReferenceException)
                        {
                            Console.WriteLine("Null reference exception.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unknown error: " + ex.Message);
                        }
                        //Use try/catch for the DB call: 
                        try
                        {

                            dpr.DeleteProduct(id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unknown error: " + ex.Message);
                        }
                        break;
                    case "U":
                        Console.WriteLine("Enter product ID: ");
                        do
                        {
                            str = Console.ReadLine();
                            success = int.TryParse(str, out id);
                        } while (!success);
                        Console.WriteLine("Enter product name: ");
                        do
                        {
                            product = Console.ReadLine().ToString();
                        } while (product == null);
                        Console.WriteLine("Enter price: ");
                        str = Console.ReadLine();
                        double price=0;
                        do
                        {
                            success = double.TryParse(str, out price);
                        } while (!success);
                        Product _prod = new Product();
                        _prod.ProductID = id;
                        _prod.Name = product;
                        _prod.Price = price;
                        //Use try/catch for the DB call: 
                        try
                        {
                            dpr.UpdateProduct(_prod);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unknown error: " + ex.Message);
                        }
                        break;
                }
            } while (c != "Q");

        }
    }
}
