using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using Violet.CommonHelper;
using Violet.Interfaces.RepositoryInterfaces;

namespace Violet.Repositories
{
    public class GenericDataRepository<T> : IGenericDataRepository<T>
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["VioletDB"].ConnectionString;
        public bool Add<T>(T data)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create the INSERT query
                    string Table = ReflectionHelper.GetTableName(data);
                    string[] parameters = ReflectionHelper.GetAllPropertyNames(data);
                    string InsertQuery = QueryHelper.CreateInsertQuery(Table, parameters);

                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {

                        // Add parameters to the query to prevent SQL injection
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic = ReflectionHelper.ConvertObjectIntoDictionary(data);
                        foreach (var parameter in dic)
                        {
                            string parameterName = parameter.Key;
                            parameterName = string.Concat("@", parameterName);
                            object parameterValue = parameter.Value;
                            command.Parameters.AddWithValue(parameterName,parameterValue);

                        }

                        // Execute the INSERT query
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}