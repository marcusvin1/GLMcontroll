using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    internal class Setor
    {
        Connection connection = new Connection();

        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }


        public void InsertSetor()
        {
            string sql = $"Insert into Setor (nomeSetor) values ('{NomeSetor}')";
            connection.Execute(sql);
        }
        public void Consult()
        {
            string sql = $"Select * from Setor where idSetor = {IdSetor}";

            connection.Consult(sql);
            if (connection.dr.Read())
            {
                NomeSetor = connection.dr["nomeSetor"].ToString();
            }
            connection.Disconnect();
        }

        public DataSet List()
        {
            string sql = "Select * from Setor";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }
    }
}
