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
                            post.Type = Convert.ToInt32(rdr["PostType"] == DBNull.Value ? 0 : rdr["PostType"]);
                            post.Title = rdr["PostTitle"].ToString();
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

        public static bool savePost(Post newPost)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_SavePost", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (newPost.Id == 0)
                        {
                            command.Parameters.AddWithValue("@PostId", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PostId", newPost.Id);
                        }
                        command.Parameters.AddWithValue("@PostContent", newPost.Content);
                        command.Parameters.AddWithValue("@PostDate", newPost.CreateDate);
                        command.Parameters.AddWithValue("@UserId", newPost.UserId);
                        command.Parameters.AddWithValue("@PostType", newPost.Type);
                        command.Parameters.AddWithValue("@PostTitle", newPost.Title);
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