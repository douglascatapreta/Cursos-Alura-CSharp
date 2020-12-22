using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class SQLServerClass
    {
        public string stringConn;
        public SqlConnection connDB;

        public SQLServerClass()
        {
            try
            {
                //stringConn = "Data Source=DESKTOP-15KNLV5;Initial Catalog=ByteBank;Persist Security Info=True;User ID=sa;Password=sqgwT@92";
                stringConn = ConfigurationManager.ConnectionStrings["Fichario"].ConnectionString;
                connDB = new SqlConnection(stringConn);
                connDB.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new SqlCommand(SQL, connDB);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public string SQLCommand(string SQL)
        {
            try
            {
                var myCommand = new SqlCommand(SQL, connDB);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Close()
        {
            connDB.Close();
        }
    }
}
