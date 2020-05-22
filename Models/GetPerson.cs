using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace FirstWebApp.Models
{
    public class DapperPerson
    {
        public static string conString = "Data source = DESKTOP-HSSCLDB; Initial Catalog = master;Trusted_Connection = True;";
        public void GetPerson(){
            using(SqlConnection conn = new SqlConnection(conString)){
                conn.Open();
                var persons = conn.Query<Person>("Select * from Person").ToList();
            }
        }
    }
}