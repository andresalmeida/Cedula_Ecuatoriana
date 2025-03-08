//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Data.SqlTypes;
//using Npgsql;
//using Testing.Models;
//using System.Linq;
//using System.Threading.Tasks;
//using NpgsqlTypes;

//namespace Testing.Data
//{
//    public class ClientePostgreSQLDataAccessLayer
//    {
//        private string connectionString = "Host=localhost; Port=5432; Database=dbproductos; Username=postgres; Password=password;";

//        public IEnumerable<ClientePostgreSQL> GetAllClientes()
//        {
//            List<ClientePostgreSQL> lst = new List<ClientePostgreSQL>();
//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM cliente_SelectAll()", con))
//                {
//                    cmd.CommandType = CommandType.Text;
//                    con.Open();
//                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            ClientePostgreSQL cliente = new ClientePostgreSQL
//                            {
//                                Codigo = reader.GetInt32(reader.GetOrdinal("Codigo")),
//                                Cedula = reader.GetString(reader.GetOrdinal("Cedula")),
//                                Apellidos = reader.GetString(reader.GetOrdinal("Apellidos")),
//                                Nombres = reader.IsDBNull(reader.GetOrdinal("Nombres")) ? null : reader.GetString(reader.GetOrdinal("Nombres")),
//                                FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")),
//                                Mail = reader.GetString(reader.GetOrdinal("Mail")),
//                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
//                                Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
//                                Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
//                            };
//                            lst.Add(cliente);
//                        }
//                    }
//                }
//            }
//            return lst;
//        }
//        // Para insertar un nuevo cliente
//        public void AddCliente(ClientePostgreSQL cliente)
//        {
//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT cliente_Insert(@Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Mail, @Telefono, @Direccion, @Estado)", con))
//                {
//                    cmd.CommandType = CommandType.Text;
//                    cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
//                    cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
//                    cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres ?? (object)DBNull.Value);
//                    //cmd.Parameters.Add("@FechaNacimiento", NpgsqlDbType.Date).Value = cliente.FechaNacimiento.Date;
//                    cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
//                    cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
//                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
//                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);
//                    cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        // Para actualizar un cliente
//        public void UpdateCliente(ClientePostgreSQL cliente)
//        {
//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT cliente_Update(@Codigo, @Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Mail, @Telefono, @Direccion, @Estado)", con))
//                {
//                    cmd.CommandType = CommandType.Text;
//                    cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
//                    cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
//                    cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
//                    cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres ?? (object)DBNull.Value);
//                    cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
//                    cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
//                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
//                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);
//                    cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        // Para eliminar un cliente
//        public void DeleteCliente(int? Codigo)
//        {
//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT cliente_Delete(@Codigo)", con))
//                {
//                    cmd.CommandType = CommandType.Text;
//                    cmd.Parameters.AddWithValue("@Codigo", Codigo ?? (object)DBNull.Value);
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }
//    }
//}

// CODIGO QUE SI FUNCIONA 4K ACHEDE

//using System;
//using System.Collections.Generic;
//using System.Data;
//using Npgsql;
//using Testing.Models;

//namespace Testing.Data
//{
//    public class ClientePostgreSQLDataAccessLayer
//    {
//        private string connectionString = "Host=localhost;Username=postgres;Password=password;Database=dbproductos";

//        public IEnumerable<ClientePostgreSQL> GetAllClientes()
//        {
//            List<ClientePostgreSQL> clientes = new List<ClientePostgreSQL>();

//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM cliente_SelectAll()";
//                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
//                {
//                    con.Open();
//                    NpgsqlDataReader reader = cmd.ExecuteReader();

//                    while (reader.Read())
//                    {
//                        clientes.Add(new ClientePostgreSQL
//                        {
//                            Codigo = Convert.ToInt32(reader["Codigo"]),
//                            Cedula = reader["Cedula"].ToString(),
//                            Apellidos = reader["Apellidos"].ToString(),
//                            Nombres = reader["Nombres"].ToString(),
//                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
//                            Mail = reader["Mail"].ToString(),
//                            Telefono = reader["Telefono"].ToString(),
//                            Direccion = reader["Direccion"].ToString(),
//                            Estado = Convert.ToBoolean(reader["Estado"])
//                        });
//                    }
//                    reader.Close();
//                }
//            }
//            return clientes;
//        }

//        public void AddCliente(ClientePostgreSQL cliente)
//        {
//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                string query = "INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado) VALUES (@Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Mail, @Telefono, @Direccion, @Estado)";
//                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
//                {
//                    cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
//                    cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
//                    cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
//                    cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
//                    cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
//                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
//                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
//                    cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        public ClientePostgreSQL GetClienteByCodigo(int codigo)
//        {
//            ClientePostgreSQL cliente = null;

//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                string query = "SELECT * FROM Cliente WHERE Codigo = @Codigo";
//                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
//                {
//                    cmd.Parameters.AddWithValue("@Codigo", codigo);
//                    con.Open();
//                    NpgsqlDataReader reader = cmd.ExecuteReader();

//                    if (reader.Read())
//                    {
//                        cliente = new ClientePostgreSQL
//                        {
//                            Codigo = Convert.ToInt32(reader["Codigo"]),
//                            Cedula = reader["Cedula"].ToString(),
//                            Apellidos = reader["Apellidos"].ToString(),
//                            Nombres = reader["Nombres"].ToString(),
//                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
//                            Mail = reader["Mail"].ToString(),
//                            Telefono = reader["Telefono"].ToString(),
//                            Direccion = reader["Direccion"].ToString(),
//                            Estado = Convert.ToBoolean(reader["Estado"])
//                        };
//                    }
//                    reader.Close();
//                }
//            }
//            return cliente;
//        }

//        public void UpdateCliente(ClientePostgreSQL cliente)
//        {
//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                string query = "UPDATE Cliente SET Cedula = @Cedula, Apellidos = @Apellidos, Nombres = @Nombres, FechaNacimiento = @FechaNacimiento, Mail = @Mail, Telefono = @Telefono, Direccion = @Direccion, Estado = @Estado WHERE Codigo = @Codigo";
//                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
//                {
//                    cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
//                    cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
//                    cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
//                    cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
//                    cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
//                    cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
//                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
//                    cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
//                    cmd.Parameters.AddWithValue("@Estado", cliente.Estado);

//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

//        public void DeleteCliente(int codigo)
//        {
//            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
//            {
//                string query = "DELETE FROM Cliente WHERE Codigo = @Codigo";
//                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
//                {
//                    cmd.Parameters.AddWithValue("@Codigo", codigo);
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }
//    }
//}

// CODIGO QUE CREAMOS PARA LA CLASE DIO MIO POR FAVOR QUE FUNCIONE

using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using Testing.Models;

namespace Testing.Data
{
    public class ClientePostgreSQLDataAccessLayer
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=password;Database=dbproductos";

        public IEnumerable<ClientePostgreSQL> GetAllClientes()
        {
            List<ClientePostgreSQL> clientes = new List<ClientePostgreSQL>();

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM cliente_SelectAll()";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    con.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        clientes.Add(new ClientePostgreSQL
                        {
                            Codigo = Convert.ToInt32(reader["Codigo"]),
                            Cedula = reader["Cedula"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Nombres = reader["Nombres"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                            Mail = reader["Mail"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        });
                    }
                    reader.Close();
                }
            }
            return clientes;
        }

        public void AddCliente(ClientePostgreSQL cliente)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO Cliente (Cedula, Apellidos, Nombres, FechaNacimiento, Mail, Telefono, Direccion, Estado, Saldo) VALUES (@Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Mail, @Telefono, @Direccion, @Estado, 0)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
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
                }
            }
        }


        public ClientePostgreSQL GetClienteByCodigo(int codigo)
        {
            ClientePostgreSQL cliente = null;

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cliente WHERE Codigo = @Codigo";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    con.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        cliente = new ClientePostgreSQL
                        {
                            Codigo = Convert.ToInt32(reader["Codigo"]),
                            Cedula = reader["Cedula"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Nombres = reader["Nombres"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                            Mail = reader["Mail"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"])
                        };
                    }
                    reader.Close();
                }
            }
            return cliente;
        }

        public void UpdateCliente(ClientePostgreSQL cliente)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "UPDATE Cliente SET Cedula = @Cedula, Apellidos = @Apellidos, Nombres = @Nombres, FechaNacimiento = @FechaNacimiento, Mail = @Mail, Telefono = @Telefono, Direccion = @Direccion, Estado = @Estado WHERE Codigo = @Codigo";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
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
                }
            }
        }

        public void DeleteCliente(int codigo)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM Cliente WHERE Codigo = @Codigo";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSaldo(int codigo, decimal monto, bool esDeposito)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string query = esDeposito ?
                    "UPDATE Cliente SET Saldo = Saldo + @Monto WHERE Codigo = @Codigo" :
                    "UPDATE Cliente SET Saldo = Saldo - @Monto WHERE Codigo = @Codigo AND Saldo >= @Monto";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    cmd.Parameters.AddWithValue("@Monto", monto);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0 && !esDeposito)
                    {
                        throw new InvalidOperationException("Saldo insuficiente para realizar el retiro.");
                    }
                }
            }
        }
    }
}