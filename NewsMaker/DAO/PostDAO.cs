using NewsMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NewsMaker.DAO
{
    public class PostDAO
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["NewsMakerConnectionString"].ConnectionString;

        public static List<Post> getPosts(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPosts", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                        {
                            command.Parameters.AddWithValue("@PostId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PostId", id);
                        }

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Post> postList = new List<Post>();

                        while (rdr.Read())
                        {
                            Post post = new Post();
                            post.Id = Convert.ToInt32(rdr["PostId"]);
                            post.Content = rdr["PostContent"].ToString();
                            post.CreateDate = Convert.ToDateTime(rdr["PostDate"]);
                            post.UserId = Convert.ToInt32(rdr["UserId"]);
                            postList.Add(post);
                        }
                        return postList;
                    }
                    catch (Exception ex)
                    {
                    }
                    return null;
                }
            }
        }

    }
}