using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.FileSharing.Common.Entities;
using EPAM.FileSharing.DAL.Interfaces;
using System.Configuration;
using System.Data.SqlClient;

namespace EPAM.FileSharing.DAL.SQLDAL
{
    public class FileSqlDAO : IFileShareDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public IEnumerable<ShFile> GetShFiles(bool orderedById = true)
        {
            using (_connection)
            {
                var query = "SELECT Id, Name, Extension, CreationDate FROM ShFiles"
                    + (orderedById ? " ORDER BY Id" : "");

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new ShFile(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        ext: reader["Extension"] as string, //!!!!
                        date: (DateTime)reader["CreationDate"]);
                }

            }
        }


        public bool AddFile(ShFile fileshare)
        {
            using (_connection)
            {
                var query = "INSERT INTO dbo.ShFiles(Name, CreationDate) " +
                    "VALUES(@Name, @CreationDate)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Name", fileshare.Name);
                command.Parameters.AddWithValue("@CreationDate", fileshare.CreationDate);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

      

        public ShFile GetShFile(int id)
        {
            using (_connection)
            {
                var stProc = "ShFiles_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new ShFile(
                        id: (int)reader["Id"],
                        name: reader["Name"] as string,
                        ext: reader["Extension"] as string, //!!!!
                        date: (DateTime)reader["CreationDate"]);
                }

                throw new InvalidOperationException("Cannot find file with ID = " + id);

            }
        }

        public ShFile CreateNewFilewithScopeID(string name, DateTime creationDate)
        {
            using (_connection)
            {
                var query = "INSERT INTO dbo.ShFiles(Name, CreationDate) " +
                    "VALUES(@Name, @CreationDate); SELECT CAST(scope_identity() AS INT) AS NewID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@CreationDate", creationDate);

                var result = command.ExecuteScalar();

                if (result != null)
                    return new ShFile(
                        id: (int)result,
                        name: name,
                        // ext : ext,   //!!!!
                        creationDate: creationDate); //!!!!
                throw new InvalidOperationException(string.Format("Oops {0}, {1};",
                    name, creationDate));

            }
        }

        public void RemoveFile(int id)
        {
            //!!!!
        }

        public void EditFile(int id, string newName)
        {
            //!!!!
        }
    }
}
