using EntityFramework.DataFirst.Data;
using EntityFramework.DataFirst.Data.Models;
using EntityFramework.DataFirst.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EntityFramework.DataFirst.Data.Models.Enumerators;

namespace EntityFramework.DataFirst
{
    public partial class FormMain : Form
    {
        string _connectionString;
        IUnitOfWorkFactory _unitOfWorkFactory;

        public FormMain()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["TEST_DB"].ConnectionString;
            _unitOfWorkFactory = new UnitOfWorkFactory(_connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new DataContext(_connectionString);
            var products = context.Products.ToList();
            foreach (Product p in products)
            {
                Console.WriteLine($"Id = {p.Id}; Name = {p.Name}");
            }
        }

        private void _btnAddProduct_Click(object sender, EventArgs e)
        {
            var context = new DataContext(_connectionString);
            var products = context.Products;
            products.Add(new Product() { 
                Name = "Арбуз",
                Cost = 50.23m
            });
            context.SaveChanges();
        }

        private void _btnChangProduct_Click(object sender, EventArgs e)
        {
            var context = new DataContext(_connectionString);
            var product = context.Products.AsQueryable().FirstOrDefault();
            product.Name = "Арбуз 222";
            context.SaveChanges();
        }

        private void _btnDeleteProduct_Click(object sender, EventArgs e)
        {
            using (var context = new DataContext(_connectionString)) 
            {
                var product = context.Products.AsQueryable().FirstOrDefault();
                var products = context.Products;//.AsQueryable();
                products.Remove(product);
                context.SaveChanges();
            }
        }

        private void _btnAddProduct2_Click(object sender, EventArgs e)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var productTypes = repository.GetEntities<ProductType>();

                var order = new Order()
                {
                    Number = "Test001"
                };
                repository.Add(order);

                repository.Add(new Product()
                {
                    Name = "Апельсин",
                    Cost = 500.23m,
                    Order = order,
                    ProductType = productTypes.Where(p => p.Value == TypeProduct.Type2).FirstOrDefault()
                });
                repository.Add(new Product()
                {
                    Name = "Ананас",
                    Cost = 1500.23m,
                    Order = order,
                    ProductType = productTypes.Where(p => p.Value == TypeProduct.Type2).FirstOrDefault()
                });
                repository.Add(new Product()
                {
                    Name = "Картошка",
                    Cost = 50.73m,
                    Order = order,
                    ProductType = productTypes.Where(p => p.Value == TypeProduct.Type1).FirstOrDefault()
                });

                uow.Commit();
            }
        }

        private void _btnViewProducts2_Click(object sender, EventArgs e)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var products = repository.GetEntities<Product>().ToList();
                
                foreach (var p in products)
                {
                    Console.WriteLine($"Id = {p.Id}; Name = {p.Name}; Заказ № = {p.Order.Number}");
                }
                Console.WriteLine();
            }
        }

        private void _btnDeleteProduct2_Click(object sender, EventArgs e)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var product = repository.GetEntities<Product>().FirstOrDefault();
                repository.Delete(product);
                uow.Commit();
            }
        }

        private void _btnChangProduct2_Click(object sender, EventArgs e)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var product = repository.GetEntities<Product>().FirstOrDefault();
                product.Name = "Яблоко 11";
                uow.Commit();
            }
        }

        private void _btnRollback_Click(object sender, EventArgs e)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                repository.Add(new Product()
                {
                    Name = "Апельсин",
                    Cost = 500.23m
                });
                repository.Add(new Product()
                {
                    Name = "Ананас",
                    Cost = 1500.23m
                });
                uow.Rollback();
            }
        }

        private void _btnCommit_Click(object sender, EventArgs e)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var product = repository.GetEntities<Product>().FirstOrDefault();
                repository.Delete(product);
                

                repository.Add(new Product()
                {
                    Name = "Капуста",
                    Cost = 500.23m
                });

                product = repository.GetEntities<Product>().ToList()[1];
                product.Name = "Груша";

                uow.Commit();
            }
        }

        // https://andrey.moveax.ru/post/entity-framework-ef5-enum-support
        private void _btnViewProductsByOrders_Click(object sender, EventArgs e)
        {
            Console.WriteLine("_btnViewProductsByOrders_Click");

            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var orders = repository.GetEntities<Order>().ToList();

                foreach (var o in orders)
                {
                    Console.WriteLine($"Продукты заказа {o.Number}");

                    foreach (var p in o.Products)
                    {
                        Console.WriteLine($"Id = {p.Id}; Name = {p.Name}; Заказ № = {p.Order.Number}; Тип: {p.ProductType.Value}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private void _btnProductGroupDelete_Click(object sender, EventArgs e)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                
                var order = repository.GetEntities<Order>().Where(o => o.Number == "Test001").FirstOrDefault();
                
                var products = repository.GetEntities<Product>().Where(p => p.OrderId == order.Id);
                foreach (var product in products)
                {
                    repository.Delete(product);
                }

                repository.Delete(order);
                uow.Commit();
            }
        }
    }
}
