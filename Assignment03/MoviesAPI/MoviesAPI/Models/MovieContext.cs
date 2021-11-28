using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesAPI.Models
{
    public class MovieContext
    {
        public string connectionString { get; set; }

        public MovieContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<MovieItem> GetAllMovie()
        {
            List<MovieItem> list = new List<MovieItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Movie", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MovieItem()
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            genre = reader.GetString("genre"),
                            duration = reader.GetString("duration"),
                            releasedate = reader.GetString("releasedate")
                        });
                    }
                }
            }
            
            return list;
        }


        public List<MovieItem> GetMovie (string id)
        {
            List<MovieItem> list = new List<MovieItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Movie WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MovieItem()
                        {
                            id = reader.GetInt32("id"),
                            name = reader.GetString("name"),
                            genre = reader.GetString("genre"),
                            duration = reader.GetString("duration"),
                            releasedate = reader.GetString("releasedate")
                        });
                    }
                }
                conn.Close();
            }


            return list;
        }

         public List<MovieItem> SetMovie(MovieItem newMovie)
         {

             using (MySqlConnection conn = GetConnection())
             {
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Movie(name, genre, duration, releasedate) " +
                     "VALUES(@name, @genre, @duration, @releasedate)", conn);
                cmd.Parameters.AddWithValue("@name", newMovie.name);
                cmd.Parameters.AddWithValue("@genre", newMovie.genre);
                cmd.Parameters.AddWithValue("@duration", newMovie.duration);
                cmd.Parameters.AddWithValue("@releasedate", newMovie.releasedate);

                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;

                conn.Close();
                
                return GetMovie(id.ToString());

            }
         }

        public List<MovieItem> UpdateMovie(string id, MovieItem newMovie)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE Movie " +
                     "SET name = @name, genre = @genre, duration = @duration, releasedate = @releasedate " +
                     "WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", newMovie.name);
                cmd.Parameters.AddWithValue("@genre", newMovie.genre);
                cmd.Parameters.AddWithValue("@duration", newMovie.duration);
                cmd.Parameters.AddWithValue("@releasedate", newMovie.releasedate);

                cmd.ExecuteNonQuery();
                conn.Close();
                return GetMovie(id.ToString());

            }
        }

        public bool DeleteMovie(string id)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var listMovie = GetMovie(id);
                if (listMovie.Count != 0)
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM Movie " +
                         "WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    
                    conn.Close();
                    return true;
                }

                conn.Close();
                return false;

            }
        }



    }
}
