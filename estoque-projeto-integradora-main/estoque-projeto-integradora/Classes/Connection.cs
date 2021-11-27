using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    class Connection
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cd = new SqlCommand();
        public SqlDataReader dr;
        SqlDataAdapter da;
        public DataSet ds;
        public DataTable dt;


        public void Connect()
        {
            cn.ConnectionString = "SERVER = LAPTOP-PG3TNAT4\\SQLEXPRESS; Database=Controle de estoque; UID=sa; PWD=123;";
            //cn.ConnectionString = "SERVER = DESKTOP-GM7EVH8\\SQLEXPRESS; Database=Controle de estoque; UID=sa; PWD=1234;";
            cn.Open();

        }

        public void Disconnect()
        {
            cn.Close();
        }

        public void Execute(string sql)
        {
            Geral dataGeral = new Geral();

            Connect();
            cd.Connection = cn;
            cd.CommandText = sql;
            cd.ExecuteNonQuery();
            
            Disconnect();
        }

        public void ExecuteFoto(string sql, byte[]foto)
        {
            Connect();
            cd.Connection = cn;
            cd.CommandText = sql;
            if (foto != null)
            {
                cd.Parameters.Clear();
                cd.Parameters.Add("@BINARIO", SqlDbType.Image);
                cd.Parameters["@BINARIO"].Value = foto;
            }
            cd.ExecuteNonQuery();
            Disconnect();
        }

        public void ListInfo(string sql)
        {
            Connect();
            da = new SqlDataAdapter(sql, cn);
            ds = new DataSet();
            da.Fill(ds);
        }

        public void Consult(string sql)
        {
            Connect();
            cd.CommandText = sql;
            cd.Connection = cn;
            dr = cd.ExecuteReader();
        }
    }
}
