﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

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

            // FocusedRow에 칼라 그라데이션 
            gridView1.Appearance.FocusedRow.BackColor = Color.Beige;
            gridView1.Appearance.FocusedRow.BackColor2 = Color.Orange;
            gridView1.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            //  gridView1.Appearance.FocusedRow.Options.UseBackColor = true;

            //using (IDbConnection db = new SqlConnection(conn))
            //{
            //    var custs = db.GetAll<Customer>();
            //    customerBindingSource.DataSource = custs;
            //    grdCusttomer.DataSource = customerBindingSource;
            //}

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

                // TODO: 멀티로 읽기와 트랜잭션 
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
                grdCusttomer.DataSource = customerBindingSource;
            }

            //using (IDbConnection db = new SqlConnection(conn))
            //{
            //    var custs = db.GetAll<Customer>();
            //    customerBindingSource.DataSource = custs;
            //    grdCusttomer.DataSource = customerBindingSource;
            //}
        }

        // Indicator에 일련번호를 달아줌
        bool indicatorIcon = true;
        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            // GridView view = sender as GridView;
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
        }

        // 윈도우 방화벽 인바운드 포트 1433을 열어줌
        // 특정조건의 Row를 그라데이션 처리함
        private void gridView2_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                //컬럼 값이 PRODUCT인 컬럼의 Cell 값을 찾아옴
                string product = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CustomerID"]);
                if (product == "ANTON")   // ANTON 경우 Row색 변경
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.White;     //그라데이션 처리
                }
            }
        }


    }
}
