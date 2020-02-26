using System;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Banking.DataAccess.Account
{
    public class AccountBaseDal
    {
        protected static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conUser"].ConnectionString);
            return connection;
        }

        protected static DataSet GetDataset(string storedProcName, params object[] parameterValues)
        {
            return SqlHelper.ExecuteDataset(GetConnection(), storedProcName, parameterValues);
        }

        private static T PopulateData<T>(IDataReader reader, object data) where T : class
        {
            var obj = data as T;
            if (obj == null) throw new InvalidCastException("Could not cast data as T.");

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (reader.IsColumnExists(prop.Name))
                    prop.SetValue(obj, reader[prop.Name]);
            }

            return obj;
        }

        protected static T PopulateData<T>(DataRow row) where T : class, new()
        {
            var obj = new T();
            if (obj == null) throw new InvalidCastException("Could not cast data as T.");

            if (row == null) return null;

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (row.Table.Columns.Contains(prop.Name))
                    if (Nullable.GetUnderlyingType(prop.PropertyType)?.IsEnum == true)
                        prop.SetValue(obj, row.GetValue(prop) == DBNull.Value ? null : Enum.ToObject(Nullable.GetUnderlyingType(prop.PropertyType), row.GetValue(prop)));
                    else
                        prop.SetValue(obj, row.GetValue(prop));
            }

            return obj;
        }
        protected static T PopulateData<T>(DataRow row, object data) where T : class
        {
            var obj = data as T;
            if (obj == null) throw new InvalidCastException("Could not cast data as T.");

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (row.Table.Columns.Contains(prop.Name))
                    prop.SetValue(obj, row.GetValue(prop));
            }

            return obj;
        }

        protected static T GetValue<T>(string storedProcName, params SqlParameter[] parameterValues)
        {
            return (T)SqlHelper.ExecuteScalar(GetConnection(), CommandType.StoredProcedure, storedProcName, parameterValues);
        }

        protected static T GetObject<T>(string storedProcName, params object[] parameterValues) where T : class, new()
        {
            var obj = new T();
            using (var reader = SqlHelper.ExecuteReader(GetConnection(), storedProcName, parameterValues))
            {
                while (reader.Read())
                {
                    PopulateData<T>(reader, obj);
                }

                return obj;
            }
        }

        protected static int GetResult(string storedProcName, params SqlParameter[] parameterValues)
        {
            return SqlHelper.ExecuteNonQuery(GetConnection(), CommandType.StoredProcedure, storedProcName, parameterValues);
        }

    }

}

