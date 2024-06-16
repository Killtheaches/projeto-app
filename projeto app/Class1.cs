using System;
using System.Data;
using MySql.Data.MySqlClient;

public class DatabaseHelper
{
    // String de conexão configurada com as informações fornecidas
    private string connectionString = "Server=jrcf.ddns.net;Port=33036;Database=db-grupo-14;Uid=usr-grupo-14;Pwd='JEXkN&m.AP;PMP1|';";

    public bool Login(string email, string senha)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            string query = "SELECT COUNT(1) FROM Clientes WHERE Email=@Email AND Senha=@Senha";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count == 1;
        }
    }

    public void InsertUser(string email, string senha)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            string query = "INSERT INTO Clientes (Email, Senha) VALUES (@Email, @Senha)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void UpdateUser(int id, string email, string senha)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            string query = "UPDATE Clientes SET Email=@Email, Senha=@Senha WHERE Id=@Id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteUser(int id)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            string query = "DELETE FROM Clientes WHERE Id=@Id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public DataTable GetAllUsers()
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            string query = "SELECT * FROM Usuarios";
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}





namespace projeto_app
{
    class Class1
    {
    }
}
