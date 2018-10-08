﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using LuckySpin.Entities;
using LuckySpin.Helpers;

namespace LuckySpin.Repositories
{
    public interface ICustomerRepository
    {
        bool CreateCustomer(Customer customer);
        Customer GetCustomerByUsername(string username);
        IEnumerable<Customer> GetAllCustomers();
        bool ToggleSuspend(int customerId);
        bool ActivateCustomer(int customerId);
        Customer GetCustomerByCustomerId(int customerId);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public bool CreateCustomer(Customer customer)
        {
            var sql = "Insert Into Customer (Username, Password, Role, BillNumber, Bank, PhoneNumber, Status, CreatedOn, ModifiedOn)" +
                      "Values (@Username, @Password, 1, @BillNumber, @Bank, @PhoneNumber, 0, @createdOn, @modifiedOn);";
            return _db.Execute(sql, customer) == 1;
        }

        public Customer GetCustomerByUsername(string username)
        {
            var sql = "SELECT [CustomerID],[Username],[Password], [BillNumber], [Bank], [PhoneNumber], [Status], [Role], [CreatedOn], [ModifiedOn] FROM [Customer] WHERE username = @username";
            return _db.Query<Customer>(sql, new {username}).SingleOrDefault();
        }

        public Customer GetCustomerByCustomerId(int customerId)
        {
            var sql = "SELECT [CustomerID],[Username],[Password], [BillNumber], [Bank], [PhoneNumber], [Status], [Role], [CreatedOn], [ModifiedOn] FROM [Customer] WHERE customerId = @customerId";
            return _db.Query<Customer>(sql, new { customerId }).SingleOrDefault();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var sql =
                "SELECT [CustomerID],[Username],[Password], [BillNumber], [Bank], [PhoneNumber], [Status], [Role], [CreatedOn], [ModifiedOn]  FROM [Customer]";
            return _db.Query<Customer>(sql);
        }

        public bool ToggleSuspend(int customerId)
        {
            var sql = "Update Customer Set Status = Status ^ 2 Where CustomerID = @customerId";
            return _db.Execute(sql, new {customerId}) == 1;
        }

        public bool ActivateCustomer(int customerId)
        {
            var sql = "Update Customer Set Status = Status | 1 Where CustomerID = @customerId";
            return _db.Execute(sql, new {customerId}) == 1;
        }
    }
}