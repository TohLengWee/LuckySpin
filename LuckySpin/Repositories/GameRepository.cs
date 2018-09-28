using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using LuckySpin.Controllers;
using LuckySpin.Entities;
using LuckySpin.Enums;
using LuckySpin.Models;
using LuckySpin.Models.Game;

namespace LuckySpin.Repositories
{
    public interface IGameRepository
    {
        List<Voucher> GetActiveVouchers(Customer customer);
        void AddVoucher(Voucher voucher);
        List<Voucher> GetAllVouchersFromCustomer(Customer customer);
        Voucher GetVoucherById(int id, Customer customer);
        void ReduceSpinCountByVoucherId(int voucherId, Customer currentUserCustomer);
        void AddTransaction(Transaction transaction);
        void UpdateVoucher(Voucher voucher);
        List<Transaction> GetTransactionHistory(Customer customer);
    }

    public class GameRepository: IGameRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<Voucher> GetAllVouchersFromCustomer(Customer customer)
        {
            return _db.Query<Voucher>(@"select * from voucher 
                                       where customerId = @customerId
                                       order by status, createdon desc", new { customer.CustomerId }).ToList();
        }

        public List<Voucher> GetActiveVouchers(Customer customer)
        {
            return _db.Query<Voucher>(@"select * from voucher 
                                       where customerId = @customerId and expiryon > GetDate() and Status = 1 and SpinCount > 0
                                       order by createdon desc", new {customer.CustomerId}).ToList();
        }

        public Voucher GetVoucherById(int id, Customer customer)
        {
            return _db.QueryFirst<Voucher>(@"select * from voucher where id = @id and customerId = @customerId", new {id, customer.CustomerId});
        }

        public void ReduceSpinCountByVoucherId(int voucherId, Customer currentUserCustomer)
        {
            _db.Execute(
                @"update voucher set spincount = spincount -1 where id = @voucherId and customerId = @customerId",
                new {voucherId, currentUserCustomer.CustomerId});
        }

        public void AddTransaction(Transaction transaction)
        {
            _db.Execute(@"insert into [Transaction] (VoucherId, CustomerId, Prize, Status, CreatedOn, ModifiedOn)
                values (@VoucherId, @CustomerId, @Prize, @Status, @CreatedOn, @ModifiedOn)",
                transaction);
        }

        public void UpdateVoucher(Voucher voucher)
        {
            _db.Execute(
                @"update voucher set status = @status, expiryOn = @expiryOn where id = @voucherId",
                new { voucherId = voucher.Id, status = voucher.Status, expiryOn = voucher.ExpiryOn.ToString("yyyy-MM-dd")});
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _db.Execute(
                @"update [Transaction] set status = @status, transactionTime = getdate() where id = @Id",
                new { Id = transaction.Id, status = transaction.Status });
        }

        public List<Transaction> GetTransactionHistory(Customer customer)
        {
            return _db.Query<Transaction>("select Id, VoucherId, CustomerId, Prize, Status, TransactionTime from [Transaction] where CustomerId = @customerId", 
                new { customer.CustomerId, Status = (int) TransactionStatus.Used}).ToList();
        }

        public void AddVoucher(Voucher voucher)
        {
            _db.Query<Voucher>(@"insert into Voucher (CustomerId, SpinCount, Winning, SpinBoard, ExpiryOn, Status, CreatedOn, ModifiedOn)
            values (@customerId, @spinCount, @Winning, @spinBoard, @ExpiryOn, @status, GetDate(), GetDate())", voucher);
        }
    }
}