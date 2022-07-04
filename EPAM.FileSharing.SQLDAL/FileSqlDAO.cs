using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.FileSharing.Common.Entities;
using EPAM.FileSharing.DAL.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using EPAM.FileSharing.Entities;

namespace EPAM.FileSharing.DAL.SQLDAL
{
    public class FileSqlDAO : IFileShareDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        //private static string _connectionString = @"Data Source=DESKTOP-TAPD89E;Initial Catalog=ShFiles;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static SqlConnection _connection = new SqlConnection(_connectionString);

       


        public bool AddFile(ShFile fileshare)
        {
            using (_connection)
            {
                //var query = "INSERT INTO dbo.ShFile(Name, CreationDate) " +
                //  "VALUES(@Name, @CreationDate)";
                //var command = new SqlCommand(query, _connection);
                var stProc = "dbo.ShFiles_AddFile";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Name", fileshare.Name);
                command.Parameters.AddWithValue("@Extension", fileshare.Extension);
                command.Parameters.AddWithValue("@CreationDate", fileshare.CreationDate);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

      

        

        public ShFile CreateNewFilewithScopeID(string name, DateTime creationDate)
        {
            using (_connection)
            {
                var query = "INSERT INTO dbo.ShFile(Name, CreationDate) " +
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
                        date: creationDate); //!!!!
                throw new InvalidOperationException(string.Format("Oops {0}, {1};",
                    name, creationDate));

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
                        id: (int)reader["ID"],
                        name: reader["Name"] as string,
                        ext: reader["Extension"] as string, //!!!!
                        date: (DateTime)reader["CreationDate"]);
                }

                throw new InvalidOperationException("Cannot find file with ID = " + id);

            }
        }

        public IEnumerable<ShFile> GetShFiles(bool orderedById = true)
        {
            using (_connection)
            {
                // var query = "SELECT ID, Name, Extension, CreationDate FROM ShFile"
                //   + (orderedById ? " ORDER BY ID" : "");
                var stProc = "dbo.ShFiles_GetShFiles";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                //var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new ShFile(
                        id: (int)reader["ID"],
                        name: reader["Name"] as string,
                        ext: reader["Extension"] as string, //!!!!
                        date: (DateTime)reader["CreationDate"]);
                }

            }
        }
        public IEnumerable<ShFile> GetAllUserShFilesById(int ID_User) //все файлы профиля с данным ацди +
        {
            using (_connection)
            {
                var stProc = "ShFiles_GetInfoById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", ID_User);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new ShFile(
                        //id: (int)reader["ID"],
                        name: reader["Name"] as string,
                        ext: reader["Extension"] as string, //!!!!
                        date: (DateTime)reader["CreationDate"]);
                }
                throw new InvalidOperationException("Cannot find user with ID = " + ID_User);
            }
        }

        public User GetProfileById(int id) //инфа о профиле  +
        {
            using (_connection)
            {
                var stProc = "ShFiles_GetProfileById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();
                // public User(int id, string name, DateTime regDate, DateTime dateOfBirth, string email)
                if (reader.Read())
                {
                    return new User(
                        id: (int)reader["ID_User"],
                        name: reader["Name"] as string,
                        regDate: (DateTime)reader["RegistrationDate"], //!!!!
                        dateOfBirth: (DateTime)reader["Date_of_Birth"],
                        email: reader["Email"] as string);
                }

                throw new InvalidOperationException("Cannot find user with ID = " + id);

            }
        }

        public void RemoveFile(int id)
        {
            //!!!!ShFiles_RemoveFile
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "ShFiles_RemoveFile";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                //return result > 0;
            }

        }

        public void EditFile(int id, string newName)
        {
            //!!!!
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "ShFiles_EditNameFile";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@NewName", newName);


                _connection.Open();
                var result = command.ExecuteNonQuery();

                //return (result > 0);
            }
        }

        
    }
}
