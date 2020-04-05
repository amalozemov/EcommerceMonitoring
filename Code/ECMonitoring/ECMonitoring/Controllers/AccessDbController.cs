using ECMonitoring.Models.EcMonitoring;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMonitoring.Controllers
{
    public class AccessDbController : Controller
    {
        string _connectionString = 
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Projects\Tolik\ECMonitoring\Code\ECMonitoring\ECMonitoring\App_Data\ECMonitoring.accdb";

        public AccessDbController()
        {
            
        }

        public ActionResult Index()
        {
            //var connectionString = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DBases\\ECMonitoring.accdb");
            //var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projects\Tolik\ECMonitoring\Code\ECMonitoring\ECMonitoring\App_Data\ECMonitoring.accdb";
            //var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Projects\Tolik\ECMonitoring\Code\ECMonitoring\ECMonitoring\App_Data\ECMonitoring.accdb";

            //var connection = CreateConnection(connectionString);
            ReadData(new Dictionary<string, string>() {
                {"TestData","Select * From Metrics" }
            });

            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = "";// metrics;

            return View();
        }


        OleDbConnection CreateConnection()
        {
            var connection = default(OleDbConnection);
            //try
            //{
                connection = new OleDbConnection();
                connection.ConnectionString = _connectionString;
                connection.Open();
            //}
            //catch (Exception er)
            //{
            //    throw new DBaseError("Ошибка подключения к базе данных.\n" + er.ToString());
            //}
            return connection;
        }

        public DataSet ReadData(Dictionary<string, string> sql)
        {
            DataSet out_data = new DataSet();
            OleDbConnection connection;
            OleDbDataAdapter adapter;
            string err_mess = String.Empty;

            // создание соединения с БД
            connection = CreateConnection();

            //try
            //{
                foreach (string key in sql.Keys)
                {
                    //
                    // подготавливают команду
                    OleDbCommand command =
                        new OleDbCommand(sql[key].ToString());
                    command.Connection = connection;

                    // добавляют её в адаптер
                    adapter = new OleDbDataAdapter(command);

                    // заполняют очередную таблицу из набора
                    out_data.Tables.Add(key);
                    adapter.Fill(out_data.Tables[key]);
                    //
                }
            //}
            //catch (Exception er)
            //{
            //    err_mess = "Ошибка запроса базы данных.\n" + er.ToString();
            //}

            //if (err_mess == String.Empty)
            //    foreach (DataTable dt in out_data.Tables)
            //        dt.AcceptChanges();

            //try
            //{
                connection.Close();
            //}
            //catch { }

            //if (err_mess != String.Empty)
            //    throw new DBaseError(err_mess);

            return out_data;
        }

    }
}