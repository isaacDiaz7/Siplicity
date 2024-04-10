using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Siplicity.Web.API.DataProvider;
using Siplicity.Web.API.Extensions;
using Siplicity.Web.API.Interface;
using Siplicity.Web.API.Models;
using System.Data;


namespace Siplicity.Web.API.DataAccessLayer
{
    public class UserService : IUserService
    {
        IDataProvider _data = null;

        public UserService(IDataProvider data)
        {
            _data = data;
        }

        #region - GETS/Mapper -
        public List<User> GetAll()
        {
            List<User> list = null;

            string procName = "[dbo].[Users_SelectAll]";

            _data.ExecuteCmd(procName, inputParamMapper: null, singleRecordMapper: delegate (IDataReader reader, short set)
            {
                int startingIndex = 0;
                User aUser = MapSingleUser(reader, ref startingIndex);
                if (list == null)
                {
                    list = new List<User>();
                }

                list.Add(aUser);
            });

            return list;
        }

        public User GetById(int id)
        {
            User user = null;

            string procName = "[dbo].[Users_SelectById]";

            _data.ExecuteCmd(procName, delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@Id", id);
            }, delegate (IDataReader reader, short set)
            {
                int startingIndex = 0;
                user = MapSingleUser(reader, ref startingIndex);
            });

            return user;
        }

        public Paged<User> GetPaginated(int pageIndex, int pageSize)
        {
            string procName = "[dbo].[Users_Paginated]";
            Paged<User> pagedList = null;
            List<User> list = null;

            int totalCount = 0;

            _data.ExecuteCmd(procName, inputParamMapper: delegate (SqlParameterCollection collection) 
            {
                collection.AddWithValue("@PageIndex", pageIndex);
                collection.AddWithValue("@PageSize", pageSize);

            }, singleRecordMapper: delegate (IDataReader reader, short set) 
            {
                int startingIndex = 0;
                User user = MapSingleUser(reader, ref startingIndex);
                
                if (totalCount == 0)
                {
                    totalCount = reader.GetSafeInt32(startingIndex);
                }

                if (list == null)
                {
                    list = new List<User>();
                }

                list.Add(user);
            });

            if (list != null)
            {
                pagedList = new Paged<User>(list, pageIndex, pageSize, totalCount);
            }

            return pagedList;
        }

        public Paged<User> GetSearchPaginated(int pageIndex, int pageSize, string query)
        {
            string procName = "[dbo].[Users_Search]";
            Paged<User> pagedList = null;
            List<User> list = null;

            int totalCount = 0;

            _data.ExecuteCmd(procName, inputParamMapper: delegate (SqlParameterCollection collection)
            {
                collection.AddWithValue("@PageIndex", pageIndex);
                collection.AddWithValue("@PageSize", pageSize);
                collection.AddWithValue("@Query", query);

            }, singleRecordMapper: delegate (IDataReader reader, short set)
            {
                int startingIndex = 0;
                User user = MapSingleUser(reader, ref startingIndex);

                if (totalCount == 0)
                {
                    totalCount = reader.GetSafeInt32(startingIndex);
                }

                if (list == null)
                {
                    list = new List<User>();
                }

                list.Add(user);
            });

            if (list != null)
            {
                pagedList = new Paged<User>(list, pageIndex, pageSize, totalCount);
            }

            return pagedList;
        }

        private User MapSingleUser(IDataReader reader, ref int startingIndex)
        {
            User aUser = new User();

            aUser.Id = reader.GetSafeInt32(startingIndex++);
            aUser.Email = reader.GetString(startingIndex++);
            aUser.FirstName = reader.GetString(startingIndex++);
            aUser.Mi = reader.GetSafeString(startingIndex++);
            aUser.LastName = reader.GetSafeString(startingIndex++);
            aUser.Password = reader.GetSafeString(startingIndex++);
            aUser.StatusId = reader.GetSafeInt32(startingIndex++);
            aUser.AvatarUrl = reader.GetSafeString(startingIndex++);
            aUser.DateCreated = reader.GetSafeDateTime(startingIndex++);
            aUser.DateModified = reader.GetSafeDateTime(startingIndex++);

            return aUser;
        }
        #endregion

        #region - PUT/POST/DELETE/CommonParams -
        public int Add(UserAddRequest request)
        {
            int id = 0;
            string procName = "[dbo].[Users_Insert]";

            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection collection)
            {
                AddCommonParams(request, collection);
                SqlParameter idOut = new SqlParameter("@Id", SqlDbType.Int);
                idOut.Direction = ParameterDirection.Output;
                collection.Add(idOut);

            }, returnParameters: delegate (SqlParameterCollection returnCollection)
            {
                object objectId = returnCollection["@Id"].Value;
                int.TryParse(objectId.ToString(), out id);
            });

            return id;
        }

        public void Update(UserUpdateRequest request, int id)
        {
            string procName = "[dbo].[Users_Update]";

            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection collection)
            {
                AddCommonParams(request, collection);
                collection.AddWithValue("@Id", id);

            }, returnParameters: null);
        }

        public void Delete(int id)
        {
            string procName = "[dbo].[Users_DeleteById]";

            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection collection)
            {
                collection.AddWithValue("@Id", id);

            }, returnParameters: null);
        }
        private static void AddCommonParams(UserAddRequest request, SqlParameterCollection collection)
        {
            collection.AddWithValue("@Email", request.Email);
            collection.AddWithValue("@FirstName", request.FirstName);
            collection.AddWithValue("@Mi", request.Mi);
            collection.AddWithValue("@LastName", request.LastName);
            collection.AddWithValue("@Password", request.Password);
            collection.AddWithValue("@StatusId", request.StatusId);
            collection.AddWithValue("@AvatarUrl", request.AvatarUrl);
        } 
        #endregion
    }
}
