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

namespace EntityFramework.DataFirst
{
    public partial class FormMain : Form
    {
        string _connectionString;

        public FormMain()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["TEST_DB"].ConnectionString;
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
            using (var uow = new UnitOfWork())
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
                uow.Commit();
            }
        }

        private void _btnViewProducts2_Click(object sender, EventArgs e)
        {
            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository();
                var products = repository.GetEntities<Product>();
                foreach (var p in products)
                {
                    Console.WriteLine($"Id = {p.Id}; Name = {p.Name}");
                }
                Console.WriteLine();
            }
        }

        private void _btnDeleteProduct2_Click(object sender, EventArgs e)
        {
            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository();
                var product = repository.GetEntities<Product>().FirstOrDefault();
                repository.Delete(product);
                uow.Commit();
            }
        }

        private void _btnChangProduct2_Click(object sender, EventArgs e)
        {
            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository();
                var product = repository.GetEntities<Product>().FirstOrDefault();
                product.Name = "Яблоко 11";
                uow.Commit();
            }
        }

        private void _btnRollback_Click(object sender, EventArgs e)
        {
            using (var uow = new UnitOfWork())
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
            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository();
                var product = repository.GetEntities<Product>().FirstOrDefault();
                repository.Delete(product);
                uow.Commit();

                repository.Add(new Product()
                {
                    Name = "Капуста",
                    Cost = 500.23m
                });

                product = repository.GetEntities<Product>().FirstOrDefault();
                product.Name = "Груша";

                uow.Commit();
            }
        }
    }
}
