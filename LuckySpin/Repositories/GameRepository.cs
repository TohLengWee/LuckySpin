using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using LuckySpin.Entities;
using LuckySpin.Models.Game;

namespace LuckySpin.Repositories
{
    public interface IGameRepository
    {
        Ticket GetCurrentTicket(Customer customer);
    }

    public class GameRepository: IGameRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public Ticket GetCurrentTicket(Customer customer)
        {
            return _db.QueryFirst<Ticket>("select top 1 * from ticket order by createdon desc", new {customer.CustomerId});
        }
    }
}