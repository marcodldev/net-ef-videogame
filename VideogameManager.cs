using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class VideogameManager
    {
        private readonly SqlConnection connection;


        public VideogameManager(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void InserisciVideogame(Videogame videogame)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=videogames_db;Integrated Security=True";

            string query = "INSERT INTO videogames (name,overview,release_date,created_at,updated_at,software_house_id) VALUES" +
                    " (@name,@overview,@release_date,@created_at,@updated_at,@software_house_id)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@name", videogame.Name));
                cmd.Parameters.Add(new SqlParameter("@overview", videogame.Overview));
                cmd.Parameters.Add(new SqlParameter("@release_date", videogame.ReleaseDate));
                cmd.Parameters.Add(new SqlParameter("@created_at", videogame.CreatedAt));
                cmd.Parameters.Add(new SqlParameter("@updated_at", videogame.UpdatedAt));
                cmd.Parameters.Add(new SqlParameter("@software_house_id", videogame.SoftwareHouseId));

                connection.Open();
                int affectedRows = cmd.ExecuteNonQuery();
            }
        }


        public Videogame RicercaVideogamePerId(int id)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=videogames_db;Integrated Security=True";
            string query = "SELECT * FROM videogames WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int videogameId = Convert.ToInt32(reader["id"]);
                        string name = (string)reader["name"];
                        string overview = (string)reader["overview"];
                        DateTime releaseDate = (DateTime)reader["release_date"];
                        DateTime createdAt = (DateTime)reader["created_at"];
                        DateTime updatedAt = (DateTime)reader["updated_at"];
                        int softwareHouseId = Convert.ToInt32(reader["software_house_id"]);

                        Videogame videogame = new Videogame(name, overview, releaseDate, createdAt, updatedAt, softwareHouseId);

                        Console.WriteLine(videogame);
                        return videogame;
                    }
                    else
                    {
                        Console.WriteLine($"Il videogame con l'id: '{id}' non è stato trovato");
                        return null;
                    }
                }
            }
        }

        public Videogame RicercaVideogiochiPerNome(string? name)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=videogames_db;Integrated Security=True";
            string query = "SELECT * FROM videogames WHERE name = @name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int videogameId = Convert.ToInt32(reader["id"]);
                        string nome = (string)reader["name"];
                        string overview = (string)reader["overview"];
                        DateTime releaseDate = (DateTime)reader["release_date"];
                        DateTime createdAt = (DateTime)reader["created_at"];
                        DateTime updatedAt = (DateTime)reader["updated_at"];
                        int softwareHouseId = Convert.ToInt32(reader["software_house_id"]);

                        Videogame videogame = new Videogame(name, overview, releaseDate, createdAt, updatedAt, softwareHouseId);

                        Console.WriteLine(videogame);
                        return videogame;
                    }
                    else
                    {
                        Console.WriteLine($"Il videogame col nome: '{name}' non è stato trovato");
                        return null;
                    }
                }
            }
        }





        public void CancellaVideogame(string nome)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=videogames_db;Integrated Security=True";

            string query = "DELETE FROM videogames WHERE name = @name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@name", nome));

                connection.Open();
                int affectedRows = cmd.ExecuteNonQuery();
            }
        }




    }

}
