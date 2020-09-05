//using EntityFramework.DataFirst2.Data;
using EntityFramework.DataFirst2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework.DataFirst2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new TEST_DBEntities())
            {
                //foreach (var prod in context.Products)
                //{
                //    Console.WriteLine($"{prod.Order.Number}; {prod.Order.Id}; {prod.ProductType.Id}; {prod.TypeProduct}");
                //}
                foreach (var o in context.Orders)
                {
                    Console.WriteLine($"Продукты заказа {o.Number}");

                    foreach (var p in o.Products)
                    {
                        Console.WriteLine($"Id = {p.Id}; Name = {p.Name}; Тип = {p.ProductType.Value}; Заказ № = {p.Order.Number}; Тип: {p.ProductType.Value}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new TEST_DBEntities())
            {
                var order = new Order()
                {
                    Number = "Test001"
                };
                context.Orders.Add(order);

                var productType = context.ProductTypes.Where(p => p.Value == TypeProduct.Type2).FirstOrDefault();
                var product = new Product()
                {
                    Name = "Картошка",
                    //TypeProduct = TypeProduct.Type1,
                    ProductType = productType,
                    Order = order
                };

                context.Products.Add(product);

                context.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new TEST_DBEntities())
            {
                var order = context.Orders.Where(o => o.Number == "Test001").FirstOrDefault();
                var products = context.Products.Where(p => p.OrderId == order.Id);

                foreach (var product in products)
                {
                    context.Products.Remove(product);
                }                

                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }
    }
}
