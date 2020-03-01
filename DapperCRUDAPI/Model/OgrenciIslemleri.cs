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
    public class OgrenciIslemleri
    {
        private string connectionString;

        public OgrenciIslemleri()
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



        public void Add(Ogrenciler stu)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Students (FirstName,LastName,Number) VALUES(@FirstName,@LastName,@Number)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, stu);
            }
        }

        public IEnumerable<Ogrenciler> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Students";
                dbConnection.Open();
                return dbConnection.Query<Ogrenciler>(sQuery);
            }
        }

        public Ogrenciler GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Students Where Id=@Id";
                dbConnection.Open();
                return dbConnection.Query<Ogrenciler>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Students Where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Ogrenciler stu)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Students SET FirstName=@FirstName,LastName=@LastName,Number=@Number Where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, stu);
            }
        }
    
    }
}
