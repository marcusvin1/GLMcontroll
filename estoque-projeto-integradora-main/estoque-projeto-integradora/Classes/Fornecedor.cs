using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    internal class Fornecedor
    {
        Connection connection = new Connection();

        public int IdFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string TelefoneFornecedor { get; set; }


        public void InsertFornecedor()
        {
            string sql = $"Insert into Fornecedor (cnpjFornecedor, nomeFornecedor, telefoneFornecedor) values ('{CnpjFornecedor}', '{NomeFornecedor}', '{TelefoneFornecedor}')";
            connection.Execute(sql);
        }
        public void AlterFornecedor()
        {
            string sql = $"Update Fornecedor set cnpjFornecedor = '{CnpjFornecedor}',telefoneFornecedor = '{TelefoneFornecedor}' Where idFornecedor = {IdFornecedor} ";
            connection.Execute(sql);
        }
        public void Excluir()
        {
            string sql = $"Delete Fornecedor where idFornecedor = {IdFornecedor.ToString()}";
            connection.Execute(sql);
        }
        public DataSet List()
        {
            string sql = "Select * from Fornecedor";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }
        public DataSet ListNotIn()
        {
            string sql = "select f.idFornecedor, f.nomeFornecedor from Fornecedor f where f.nomeFornecedor not in (select f.nomeFornecedor from Fornecedor f inner join Estoque e on f.idFornecedor = e.idFornecedor)";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }
        public void ConsultarDados()
        {
            string sql = $"Select * from Fornecedor where idFornecedor = {IdFornecedor}";
            connection.Consult(sql);
            if (connection.dr.Read())
            {
                CnpjFornecedor = connection.dr["cnpjFornecedor"].ToString();
                TelefoneFornecedor = connection.dr["telefoneFornecedor"].ToString();
            }
            connection.Disconnect();
        }
    }
}
