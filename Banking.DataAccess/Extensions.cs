using System;
using System.Data;
using System.Reflection;

namespace Banking.DataAccess
{
    public static class Extensions
    {
        public static bool IsColumnExists(this IDataReader reader, string columnName)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                    return true;
            }
            return false;
        }

        public static object GetValue(this DataRow row, PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string))
                return (string)(row[prop.Name] == DBNull.Value ? null : row[prop.Name]);

            if (prop.PropertyType == typeof(int))
                return row[prop.Name] == DBNull.Value ? 0 : Convert.ToInt32(row[prop.Name]);

            if (prop.PropertyType == typeof(int?))
                return row[prop.Name] == DBNull.Value ? (int?)null : Convert.ToInt32(row[prop.Name]);

            if (prop.PropertyType == typeof(double))
                return Convert.ToDouble(row[prop.Name]);

            if (prop.PropertyType == typeof(decimal?))
                return row[prop.Name] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row[prop.Name]);

            if (prop.PropertyType == typeof(DateTime?))
                return row[prop.Name] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[prop.Name]);

            if (prop.PropertyType == typeof(bool?))
                return row[prop.Name] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row[prop.Name]);

            if (prop.PropertyType == typeof(Guid?))
                return row[prop.Name] == DBNull.Value ? (Guid?)null : new Guid(row[prop.Name].ToString());

            return row[prop.Name];
        }

        public static T GetValue<T>(this DataRow dr, string fieldName)
        {
            if (dr[fieldName].Equals(DBNull.Value))
            {
                return default(T);
            }

            return dr.Field<T>(fieldName);
        }
    }
}
