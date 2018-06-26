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
        List<Ticket> GetActiveTickets(Customer customer);
    }

    public class GameRepository: IGameRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<Ticket> GetActiveTickets(Customer customer)
        {
            return _db.Query<Ticket>(@"select * from ticket 
                                       where customerId = @customerId and expiryon > GetDate()
                                       order by createdon desc", new {customer.CustomerId}).ToList();
        }
    }
}