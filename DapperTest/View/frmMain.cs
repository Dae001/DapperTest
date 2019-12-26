using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using DapperTest.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using DevExpress.XtraGrid.Views.Grid;

namespace DapperTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        static readonly string conn = ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString;

        public Form1()
        {
            InitializeComponent();

            using (IDbConnection db = new SqlConnection(conn))
            {
                var custs = db.GetAll<Customer>();
                customerBindingSource.DataSource = custs;
                grdCusttomer.DataSource = customerBindingSource;
            }
        }

        private void btnCustomerID_Click(object sender, EventArgs e)
        {
            CustomerSlect();
        }

        private void CustomerSlect()
        {
            using (var db = new SqlConnection(conn))
            {
                // Customers를 코드성 테이블로 보내고 Order을 주검색으로
                string sqlCust = "SELECT * FROM dbo.Customers Where CustomerID Like @CustomerID + '%'";
                var cust = db.QueryFirstOrDefault<Customer>(sqlCust, new { CustomerID = txtCustomerID.Text.Trim() });
                txtCompanyName.Text = cust.CompanyName;

                // 검색후 테이타가 없거나 여러개 일때 Exception처리를..
                string sqlOrder = "SELECT * FROM dbo.Orders where CustomerID Like @CustomerID + '%' and OrderDate = @OrderDate";
                var order = db.QuerySingleOrDefault<Order>(sqlOrder, new { CustomerID = txtCustomerID.Text.Trim(), OrderDate = txtOderDate.Text.Trim() });
                txtOderDate.Text = order.OrderDate.ToString();

                string sqlOrderDetail = "SELECT * FROM dbo.OrderDetails where OrderID = @OrderID";
                var order_Detail = db.Query<OrderDetail>(sqlOrderDetail, new { OrderID = order.OrderID });
                grdCusttomer.DataSource = order_Detail;

                // 멀티로 읽기와 트랜잭션 

                customerBindingSource.DataSource = cust;

            }
        }

        private void btnCustomerAll_Click(object sender, EventArgs e)
        {
            // 멀티로 읽기와 트랜잭션 Query Multi-Mapping (One to Many)
            // string sql = "SELECT TOP 10 * FROM Orders AS A INNER JOIN OrderDetails AS B ON A.OrderID = B.OrderID;";

            //using (var connection = new SqlConnection(conn))
            //{
            //    var orderDictionary = new Dictionary<int, Order>();
            //    var list = connection.Query<Order, OrderDetail, Order>(sql, (order, orderDetail) =>
            //        {
            //            Order orderEntry;
            //            if (!orderDictionary.TryGetValue(order.OrderID, out orderEntry))
            //            {
            //                orderEntry = order;
            //                orderEntry.OrderDetails = new List<OrderDetail>();
            //                orderDictionary.Add(orderEntry.OrderID, orderEntry);
            //            }
            //            orderEntry.OrderDetails.Add(orderDetail);
            //            return orderEntry;
            //        }, splitOn: "OrderDetailID").Distinct().ToList();

            //    Console.WriteLine("Orders Count:" + list.Count);

            //    //FiddleHelper.WriteTable(list);
            //    //FiddleHelper.WriteTable(list.First().OrderDetails);
            //}

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            using (IDbConnection db = new SqlConnection(conn))
            {
                var cust = db.Get<Customer>("ALFKI");
                customerBindingSource.DataSource = cust;
            }

            using (IDbConnection db = new SqlConnection(conn))
            {
                var custs = db.GetAll<Customer>();
                customerBindingSource.DataSource = custs;
                grdCusttomer.DataSource = customerBindingSource;
            }
        }

        bool indicatorIcon = true;
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
           // GridView view = sender as GridView;
            if (e.Info.IsRowIndicator && e.RowHandle>=0)
            {
                e.Info.DisplayText = (e.RowHandle+1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }


    }
}
