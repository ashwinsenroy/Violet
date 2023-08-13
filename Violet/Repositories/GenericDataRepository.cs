using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using MySqlConnector;
using Violet.CommonHelper;
using Violet.Interfaces.RepositoryInterfaces;

namespace Violet.Repositories
{
    public class GenericDataRepository<T> : IGenericDataRepository<T>
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["VioletDB"].ConnectionString;
        public bool Add<T>(T data)  // this is a traditional method to add to db, using an insert sql query.
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Create the INSERT query
                    string Table = ReflectionHelper.GetTableName(data);
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic = ReflectionHelper.ConvertObjectIntoDictionary(data);
                    dic = ReflectionHelper.FilterOutPropertiesWithKeyAttribute(dic,data);
                    int NumberOfParameters = ReflectionHelper.NumberofPropertiesWithoutKeyAttribute(dic, data);
                    string[] parameters = new string[NumberOfParameters];
                    parameters = ReflectionHelper.GetPropertyNames(dic);
                    string InsertQuery = QueryHelper.CreateInsertQuery(NumberOfParameters,Table,dic);

                    using (MySqlCommand command = new MySqlCommand(InsertQuery, connection))
                    {

                        // Add parameters to the query to prevent SQL injection
                        Dictionary<string, object> dictionary = dic;
                        foreach (var parameter in dictionary)
                        {
                            string parameterName = parameter.Key;
                            parameterName = string.Concat("@", parameterName);
                            object parameterValue = parameter.Value;
                            command.Parameters.AddWithValue(parameterName, parameterValue);

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