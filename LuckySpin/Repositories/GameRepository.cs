using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using LuckySpin.Entities;
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
                                       where customerId = @customerId and expiryon > GetDate() and Status = 1
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

        public void AddVoucher(Voucher voucher)
        {
            _db.Query<Voucher>(@"insert into Voucher values (@customerId, @spinCount, @maxWinning, @spinBoard, @ExpiryOn, @status, GetDate(), GetDate())", voucher);
        }
    }
}