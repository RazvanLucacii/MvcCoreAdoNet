using MvcCoreAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctores
    {
        SqlCommand command;
        SqlConnection connection;
        SqlDataReader reader;
        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "select * from DOCTOR";
            this.command.CommandText = sql;
            this.command.CommandType = CommandType.Text;
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.Hospital_cod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.Doctor_no = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.connection.Close();
            return doctores;
        }

        public List<Doctor> FindDoctoresByEspecialidad(string especialidad)
        {
            string sql = "select * from DOCTOR where ESPECIALIDAD = @especialidad";
            this.command.Parameters.AddWithValue("especialidad", especialidad);
            this.command.CommandText = sql;
            this.command.CommandType = CommandType.Text;
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.Hospital_cod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.Doctor_no = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.command.Parameters.Clear();
            this.connection.Close();
            return doctores;
        }

        public List<string> GetEspecialidades()
        {
            string sql = "select distinct ESPECIALIDAD from DOCTOR";
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = sql;
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            List<string> especialidades = new List<string>();
            while (this.reader.Read())
            {
                string espe = this.reader["ESPECIALIDAD"].ToString();
                especialidades.Add(espe);
            }
            this.reader.Close();
            this.connection.Close();
            return especialidades;
        }
    }

}
