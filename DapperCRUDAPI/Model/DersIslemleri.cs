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
    public class DersIslemleri
    {
        private string connectionString;

        public DersIslemleri()
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



        public void Add(Dersler less)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Lessons (FirstName,LastName,Number) VALUES(@FirstName,@LastName,@Number)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, less);
            }
        }

        public IEnumerable<Dersler> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Lessons";
                dbConnection.Open();
                return dbConnection.Query<Dersler>(sQuery);
            }
        }



        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Lessons Where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Dersler less)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Lessons SET Class=@Class,LessonName=@LessonName";
                dbConnection.Open();
                dbConnection.Execute(sQuery, less);
            }
        }
    
    }
}
