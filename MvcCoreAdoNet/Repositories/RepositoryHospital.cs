using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryHospital
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public List<Hospital> GetHospitales()
        {
            string sql = "select * from HOSPITAL";
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = sql;
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            List<Hospital> listaHospitales = new List<Hospital>();
            while (this.reader.Read()) 
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["DIRECCION"].ToString();
                hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
                listaHospitales.Add(hospital);
            }
            this.reader.Close();
            this.connection.Close();
            return listaHospitales;
        }

        public Hospital FindHospitalById(int idHospital)
        {
            string sql = "select * from HOSPITAL where HOSPITAL_COD=@IDHOSPITAL";
            SqlParameter pamIdHospital = new SqlParameter("@IDHOSPITAL", idHospital);
            this.command.Parameters.Add(pamIdHospital);
            this.command.CommandText = sql;
            this.command.CommandType = CommandType.Text;
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            this.reader.Read();
            Hospital hospital = new Hospital();
            hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            hospital.Nombre = this.reader["NOMBRE"].ToString();
            hospital.Direccion = this.reader["DIRECCION"].ToString();
            hospital.Telefono = this.reader["TELEFONO"].ToString();
            hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
            this.reader.Close();
            this.command.Parameters.Clear();
            this.connection.Close();
            return hospital;
        }

        public void InsertHospital(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            string sql = "insert into HOSPITAL values (@idHospital, @nombre " + ", @direccion, @telefono, @camas)";
            SqlParameter pamId = new SqlParameter("@idHospital", idHospital);
            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);
            SqlParameter pamDireccion = new SqlParameter("@direccion", direccion);
            SqlParameter pamTelefono = new SqlParameter("@telefono", telefono);
            SqlParameter pamCamas = new SqlParameter("@camas", camas);
            this.command.Parameters.Add(pamId);
            this.command.Parameters.Add(pamNombre);
            this.command.Parameters.Add(pamDireccion);
            this.command.Parameters.Add(pamTelefono);
            this.command.Parameters.Add(pamCamas);
            this.command.CommandText = sql;
            this.command.CommandType = CommandType.Text;
            this.connection.Open();
            int af = this.command.ExecuteNonQuery();
            this.connection.Close();
            this.command.Parameters.Clear();
        }

        public void UpdateHospital(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            string sql = "update HOSPITAL set NOMBRE=@nombre, DIRECCION=@direccion "
                + ", TELEFONO=@telefono, NUM_CAMA=@camas where HOSPITAL_COD=@idHospital";
            this.command.Parameters.AddWithValue("@idHospital", idHospital);
            this.command.Parameters.AddWithValue("@nombre", nombre);
            this.command.Parameters.AddWithValue("@direccion", direccion);
            this.command.Parameters.AddWithValue("@telefono", telefono);
            this.command.Parameters.AddWithValue("@camas", camas);
            this.command.CommandText = sql;
            this.command.CommandType = CommandType.Text;
            this.connection.Open();
            int af = this.command.ExecuteNonQuery();
            this.connection.Close();
            this.command.Parameters.Clear();
        }
        
        public void DeleteHospital(int idHospital)
        {
            string sql = "delete from HOSPITAL where HOSPITAL_COD=@idhospital";
            this.command.Parameters.AddWithValue("@idHospital", idHospital);
            this.command.CommandText = sql;
            this.command.CommandType = CommandType.Text;
            this.connection.Open();
            int af = this.command.ExecuteNonQuery();
            this.command.Parameters.Clear();
            this.connection.Close();

        }
    }
}
