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
    }
}
