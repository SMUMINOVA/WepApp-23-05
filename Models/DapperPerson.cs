using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace FirstWebApp.Models
{
    public class DapperPerson
    {
        public static string conString = "Data source = DESKTOP-HSSCLDB; Initial Catalog = master;Trusted_Connection = True;";
        public List<Person> GetPersons(){
            using(SqlConnection conn = new SqlConnection(conString)){
                conn.Open();
                var persons = conn.Query<Person>("Select * from Person").ToList();
                conn.Close();
                return persons;
            }
        }
        public List<Person> GetPersonById(int Id){
            using(SqlConnection conn = new SqlConnection(conString)){
                conn.Open();
                var persons = conn.Query<Person>($"Select * from Person where Id = {Id}").ToList();
                conn.Close();
                return persons;
            }           
        }
        public List<Person> GetPersonByFIO(Person p){
            using(SqlConnection conn = new SqlConnection(conString)){
                conn.Open();
                var persons = conn.Query<Person>($"Select * from Person where FirstName = '{p.FirstName}' AND LastName = '{p.LastName}' AND MiddleName = '{p.MiddleName}'").ToList();
                conn.Close();
                return persons;
            }           
        }
        public void InsertPerson(Person p){
            using(SqlConnection conn = new SqlConnection(conString)){
                conn.Open();
                conn.Execute($"INSERT into Person(FirstName, LastName, MiddleName) VALUES('{p.FirstName}', '{p.LastName}', '{p.MiddleName}')");
                conn.Close();
            }
        }
    }
}