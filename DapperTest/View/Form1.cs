using Dapper;
using DapperTest.Controller;
using DapperTest.Model;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DapperTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        static readonly string conn = ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomerID_Click(object sender, EventArgs e)
        {
            string sqlCust = "SELECT * FROM dbo.Customers Where CustomerID Like @CustomerID + '%'";
            string sqlOrder  = "SELECT * FROM dbo.Orders where CustomerID Like @CustomerID + '%' and OrderDate = @OrderDate";
            string sqlOrderDetail = "SELECT * FROM dbo.[Order Details] where OrderID = @OrderID";

            using (var db = new SqlConnection(conn))
            {
                // 코드성 테이블로 보내고 Order을 주검색으로
                var cust = db.QueryFirst<Customer>(sqlCust, new { CustomerID = txtCustomerID.Text.Trim() });
                txtCompanyName.Text = cust.CompanyName;
                // 검색후 테이타가 없거나 여러개 일때 Exception처리를..
                var order = db.QueryFirstOrDefault<Order>(sqlOrder, new { CustomerID = txtCustomerID.Text.Trim(), OrderDate = txtOderDate.Text.Trim()});
                txtOderDate.Text = order.OrderDate.ToString();
                var order_Detail = db.Query<Order_Detail>(sqlOrderDetail, new { OrderID = order.OrderID });
                grdCusttomer.DataSource = order_Detail;
            }
        }

        private void btnCustomerAll_Click(object sender, EventArgs e)
        {
            cmdCustomer cmdcust = new cmdCustomer();
            var custs = cmdcust.GetAllCustmer();
            grdCusttomer.DataSource = custs;
        }

       
    }
}
