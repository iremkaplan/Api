using DapperCRUDAPI;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDAPI.Model
{
    public class SinifIslemleri
    {
        private string connectionString;

        public SinifIslemleri()
        {
            connectionString = @"Persist Security Info=False;Trusted_Connection=True;Initial Catalog=DAPPERDB;Data Source=(localdb)\Kaplan;Connection Timeout=100000";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }



        public void Add(Siniflar clss)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Classes (FirstName,LastName,Number) VALUES(@FirstName,@LastName,@Number)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, clss);
            }
        }

        public IEnumerable<Siniflar> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Classes";
                dbConnection.Open();
                return dbConnection.Query<Siniflar>(sQuery);
            }
        }



        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Classes Where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Siniflar clss)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Classes SET Class=@Class,Lesson=@Lesson";
                dbConnection.Open();
                dbConnection.Execute(sQuery, clss);
            }
        }
    
    }
}
