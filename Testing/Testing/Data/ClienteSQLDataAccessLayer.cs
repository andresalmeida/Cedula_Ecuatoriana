using Testing.Models;
using Testing.Controllers;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Testing.Data
{
    public class ClienteSQLDataAccessLayer
    {
        //Realizar la conexión a la base de datos, es decir, el connection string

        string connectionString = "Data Source=DESKTOP-9QK0T32\\SQLPRO;Initial Catalog=dbproductos;User ID=sa;Password=password";
        public IEnumerable<ClienteSQL> GetAllClientes()
        {
            List<ClienteSQL> lst = new List<ClienteSQL>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClienteSQL cliente = new ClienteSQL();

                    cliente.Codigo = Convert.ToInt32(reader["Codigo"]);
                    cliente.Cedula = reader["Cedula"].ToString();
                    cliente.Apellidos = reader["Apellidos"].ToString();
                    cliente.Nombres = reader["Nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                    cliente.Mail = reader["Mail"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.Direccion = reader["Direccion"].ToString();
                    cliente.Estado = Convert.ToBoolean(reader["Estado"]);

                    lst.Add(cliente);

                }
                con.Close();
            }
            return lst;
        }

        //Para insertar un nuevo cliente
        public void AddCliente(ClienteSQL cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Para actualizar un cliente
        public void UpdateCliente(ClienteSQL cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Para eliminar un cliente
        public void DeleteCliente(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}