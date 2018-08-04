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
    }

    public class GameRepository: IGameRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<Voucher> GetActiveVouchers(Customer customer)
        {
            return _db.Query<Voucher>(@"select * from voucher 
                                       where customerId = @customerId and expiryon > GetDate()
                                       order by createdon desc", new {customer.CustomerId}).ToList();
        }

        public void AddVoucher(Voucher voucher)
        {
            _db.Query<Voucher>(@"insert into Voucher values (@customerId, @spinCount, @maxWinning, @spinBoard, @ExpiryOn, @Status, GetDate(), GetDate())", voucher);
        }
    }
}