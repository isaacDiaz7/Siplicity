using System.Data;
using System.Data.SqlClient;

namespace Siplicity.Web.API.DataProvider
{
    public class SqlDataProvider : IDataProvider
    {
        private readonly string _connectionString;

        public SqlDataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecuteCmd(
            string storedProc,
            Action<SqlParameterCollection> inputParamMapper,
            Action<IDataReader, short> singleRecordMapper,
            Action<SqlParameterCollection> returnParameters = null,
            Action<SqlCommand> cmdModifier = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(storedProc, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    inputParamMapper?.Invoke(command.Parameters);
                    cmdModifier?.Invoke(command);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        short resultSetIndex = 0;
                        while (reader.Read())
                        {
                            singleRecordMapper(reader, resultSetIndex);
                        }
                    }
                    returnParameters?.Invoke(command.Parameters);
                }
            }
        }

        public int ExecuteNonQuery(
            string storedProc,
            Action<SqlParameterCollection> inputParamMapper,
            Action<SqlParameterCollection> returnParameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(storedProc, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    inputParamMapper?.Invoke(command.Parameters);
                    connection.Open();
                    var rowsAffected = command.ExecuteNonQuery();
                    returnParameters?.Invoke(command.Parameters);
                    return rowsAffected;
                }
            }
        }
    }
}
