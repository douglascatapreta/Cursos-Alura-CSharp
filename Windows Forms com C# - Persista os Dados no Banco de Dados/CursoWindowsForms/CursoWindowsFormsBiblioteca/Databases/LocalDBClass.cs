﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class LocalDBClass
    {
        public string stringConn { get; set; }
        public SqlConnection connDB { get; set; }

        public LocalDBClass()
        {
            try
            {
                //stringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='D: \\Users\\Douglas Cata Preta\\Developer\\Workspace_Alura\\Cursos - Alura - CSharp\\Windows Forms com C# - Persista os Dados no Banco de Dados\\CursoWindowsForms\\CursoWindowsFormsBiblioteca\\Databases\\Fichario.mdf';Integrated Security=True";
                stringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='D:\\Fichario.mdf';Integrated Security=True";
                connDB = new SqlConnection(stringConn);
                connDB.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
