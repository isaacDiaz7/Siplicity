using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Data.SqlClient;
using Siplicity.Web.API.Models;
using System.Data;


namespace Siplicity.Web.API.DataAccessLayer
{
    public class User_DAL
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public static IConfiguration ?Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("default");
        }

        public List<User> GetAllUser()
        {
            List<User> userList = new List<User>();
            using(_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[User_SelectAll]";
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetInt32("id");
                    user.Email = reader.GetString("email");
                    user.Mi = reader.GetString("mi");
                    user.FirstName = reader.GetString("firstName");
                    user.LastName = reader.GetString("lastName");
                    user.Password = reader.GetString("password");
                    user.StatusId = reader.GetInt32("statusId");
                    user.AvatarUrl = reader.GetString("avatarUrl");
                    user.DateCreated = reader.GetDateTime("dateCreated");
                    user.DateModified = reader.GetDateTime("dateModified");
                    userList.Add(user);

                }
                _connection.Close();
            }
            return userList;
        }

        public int Add(UserAddRequest request)
        {
            int id = 0;
            using (_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[Users_Insert]";

                _command.Parameters.AddWithValue("@Email", request.Email);
                _command.Parameters.AddWithValue("@FirstName", request.FirstName);
                _command.Parameters.AddWithValue("@Mi", request.Mi);
                _command.Parameters.AddWithValue("@LastName", request.LastName);
                _command.Parameters.AddWithValue("@Password", request.Password);
                _command.Parameters.AddWithValue("@StatusId", request.StatusId);
                _command.Parameters.AddWithValue("@AvatarUrl", request.AvatarUrl);
                _connection.Open();
                id = _command.ExecuteNonQuery();
                _connection.Close();


            }

            return id;
        }
        
    }
}
