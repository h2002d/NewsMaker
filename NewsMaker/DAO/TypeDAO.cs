using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMaker.DAO
{
    class TypeDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["NewsMakerConnectionString"].ConnectionString;

        public static List<NewsMaker.Models.Type> getTypes(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetTypes", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                        {
                            command.Parameters.AddWithValue("@TypeID", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@TypeID", id);
                        }

                        SqlDataReader rdr = command.ExecuteReader();
                        List<NewsMaker.Models.Type> typeList = new List<NewsMaker.Models.Type>();

                        while (rdr.Read())
                        {
                            NewsMaker.Models.Type type = new NewsMaker.Models.Type();
                            type.TypeId = Convert.ToInt32(rdr["TypeId"]);
                            type.TypeName = rdr["TypeName"].ToString();
                            typeList.Add(type);
                        }
                        return typeList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }

        }

        public static bool saveType(NewsMaker.Models.Type newType)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_SaveType", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (newType.TypeId == null)
                        {
                            command.Parameters.AddWithValue("@TypeID", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@TypeID", newType.TypeId);
                        }
                        command.Parameters.AddWithValue("@TypeName", newType.TypeName);
                        command.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                    }
                    return false;
                }
            }
        }



    }
}
