using DapperTest.Factory;
using DapperTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DapperTest.Controller
{
    public class cmdCustomer
    {
        Repository<Customer> cmd = new Repository<Customer>();

        public List<Customer> GetbyIDCustmer(string customerID)
        {
            try
            {
                return cmd.GetById("Select * From Customer Where CustomerID Like @CustomerID + '%'", new { CustomerID = customerID }).ToList();
                }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Customer> GetAllCustmer()
        {
            try
            {
                return cmd.GetAll("select * from Customer").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool AddCustmer(string customerID, string companyName, string contactName, string contactTitle, string address, string city,
                               string region, string postalCode, string country, string phone, string fax)    
        {
            try
            {
                List<Customer> cust = new List<Customer>();
                cust.Add(new Customer { CustomerID = customerID, CompanyName= companyName, ContactName = contactName, ContactTitle = contactTitle, 
                    Address = address, City=city, Region=region, PostalCode=postalCode, Country=country, Phone=phone, Fax = fax});
                cmd.ExcuteParam("INSERT INTO dbo.Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, " +
                                                            "Region, PostalCode, Country, Phone, Fax) " +
                                                   "VALUES (@customerID, @contactName, @contactTitle, @address, @city, @region, " +
                                                           "@postalCode, @country, @phone, @fax)", cust);
                return    true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCustmere(string customerID, string companyName, string contactName, string contactTitle, string address, string city,
                               string region, string postalCode, string country, string phone, string fax)
        {
            try
            {
                List<Customer> cust = new List<Customer>();
                cust = new List<Customer>();
                cust.Add(new Customer { CompanyName= companyName, ContactName = contactName, ContactTitle = contactTitle, Address = address, 
                    City=city, Region=region, PostalCode=postalCode, Country=country, Phone=phone, Fax = fax, CustomerID = customerID,});
                cmd.ExcuteParam("UPDATE dbo.Customers "+
                                "SET CompanyName = @companyName, ContactName = @contactName, ContactTitle = @contactTitle, Address = @address, " +
                                    "City = @city, Region = @region, PostalCode = @postalCode, Country = @country, Phone = @phone, Fax = < @fax "+
                                "WHERE CustomerID = @customerID", cust);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCustmer(string customerID)
        {
            try
            {
                List<Customer> cust = new List<Customer>();
                cust.Add(new Customer { CustomerID = customerID, });
                cmd.ExcuteParam("DELETE FROM dbo.Customers WHERECustomerID == @customerID", cust);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}


