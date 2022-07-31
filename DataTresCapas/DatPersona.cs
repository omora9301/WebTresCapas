using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataTresCapas
{
    public class DatPersona
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable ObtenerSinStoreProcedure() 
        {
            string sentencia = "Select * From personas Order By Nombre";
            SqlDataAdapter da = new SqlDataAdapter(sentencia, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Obtener()
        {
            SqlCommand cmd = new SqlCommand("spObtenerPersona",cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            //string sentencia = "Select * From personas Order By Nombre";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataRow ObtenerEditarSinStoreProcedure(int id)
        {
            string sentencia = $"select * from personas where id={id}";
            SqlDataAdapter da = new SqlDataAdapter(sentencia, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }
        public DataRow ObtenerEditar(int id)
        {
            SqlCommand cmd = new SqlCommand("spObtEditarPersona", cnn);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }
        public void EditarSinStoreProcedure(int id, string nombre, string paterno, string materno, int edad)
        {
            string sentencia = $"update personas set Nombre = '{nombre}',Paterno='{paterno}',Materno='{materno}',Edad={edad} where Id={id}";
            SqlCommand cmd = new SqlCommand(sentencia, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void Editar(int id, string nombre, string paterno, string materno, int edad, int estadocivil)
        {
            SqlCommand cmd = new SqlCommand("spActualizarPersona", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Paterno", paterno);
            cmd.Parameters.AddWithValue("@Materno", materno);
            cmd.Parameters.AddWithValue("@Edad", edad);
            cmd.Parameters.AddWithValue("@EstadoCivil", estadocivil);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void AgregarSinStoreProcedure(string nombre, string paterno, string materno, int edad)
        {
            string sentencia = $"Insert into personas values('{nombre}','{paterno}','{materno}',{edad}, GETDATE())";
            SqlCommand cmd = new SqlCommand(sentencia, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void Agregar(string nombre, string paterno, string materno, int edad, int estadocivil)
        {
            SqlCommand cmd = new SqlCommand("spAgregarPersona",cnn);
            //string sentencia = $"Insert into personas values('{nombre}','{paterno}','{materno}',{edad}, GETDATE())";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Paterno", paterno);
            cmd.Parameters.AddWithValue("@Materno", materno);
            cmd.Parameters.AddWithValue("@Edad", edad);
            cmd.Parameters.AddWithValue("@EstadoCivil", estadocivil);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void EliminarSinStoreProcedure(int id)
        {
            string sentencia = $"delete from personas where id ={id}";
            SqlCommand cmd = new SqlCommand(sentencia, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void Eliminar(int id) 
        {
            SqlCommand cmd = new SqlCommand("spEliminarPersona", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable BuscarSinStoreProcedure(string valor)
        {
            string sentencia = $"select * from personas where Nombre like'%{valor}%' or Paterno like'%{valor}%' or Materno like'{valor}'";
            SqlDataAdapter da = new SqlDataAdapter(sentencia, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Buscar(string valor) 
        {
            SqlCommand cmd = new SqlCommand("spBuscarValor", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@valor", valor);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ValidarPersonaSinStoreProcedure(string nombre, string paterno, string materno)
        {
            string sentencia = $"select * from personas where Nombre='{nombre}'and Paterno='{paterno}'and Materno='{materno}'";
            SqlDataAdapter da = new SqlDataAdapter(sentencia, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ValidarPersona(string nombre, string paterno, string materno) 
        {
            SqlCommand cmd = new SqlCommand("spValidarPersona", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Paterno", paterno);
            cmd.Parameters.AddWithValue("@Materno", materno);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable UsuarioRepetidoEditarSinStoreProcedure(int id, string nombre, string paterno, string materno)
        {
            string sentencia = $"select * from personas where Nombre='{nombre}' and Paterno='{paterno}' and Materno='{materno}' and Id!= {id}";
            SqlDataAdapter da = new SqlDataAdapter(sentencia, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable UsuarioRepetidoEditar(int id, string nombre, string paterno, string materno) 
        {
            SqlCommand cmd = new SqlCommand("spUsuarioRepetidoValidar", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Paterno", paterno);
            cmd.Parameters.AddWithValue("@Materno", materno);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
