﻿using Dapper;
using DapperTest.Controller;
using DapperTest.Model;
using System;
using System.Collections.Generic;
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
            string sqlOrderDetail = "SELECT * FROM dbo.OrderDetails where OrderID = @OrderID";

            using (var db = new SqlConnection(conn))
            {
                // Customers를 코드성 테이블로 보내고 Order을 주검색으로
                var cust = db.QueryFirstOrDefault<Customer>(sqlCust, new { CustomerID = txtCustomerID.Text.Trim() });
                txtCompanyName.Text = cust.CompanyName;

                // 검색후 테이타가 없거나 여러개 일때 Exception처리를..
                var order = db.QuerySingleOrDefault<Order>(sqlOrder, new { CustomerID = txtCustomerID.Text.Trim(), OrderDate = txtOderDate.Text.Trim()});
                txtOderDate.Text = order.OrderDate.ToString();
                
                var order_Detail = db.Query<OrderDetail>(sqlOrderDetail, new { OrderID = order.OrderID });
                grdCusttomer.DataSource = order_Detail;

                // 멀티로 읽기와 트랜잭션 

                customerBindingSource.DataSource = cust;
            }
        }

        private void btnCustomerAll_Click(object sender, EventArgs e)
        {
            // 멀티로 읽기와 트랜잭션 Query Multi-Mapping (One to Many)
            string sql = "SELECT TOP 10 * FROM Orders AS A INNER JOIN OrderDetails AS B ON A.OrderID = B.OrderID;";

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


    }
}