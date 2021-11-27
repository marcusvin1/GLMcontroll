using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    internal class Estoque
    {
        Connection connection = new Connection();

        public int IdEstoque { get; set; }
        public string DataValEstoque { get; set; }
        public string NumeroLote { get; set; }
        public int QtdEstoque { get; set; }
        public int IdProduto { get; set; }
        public int IdFornecedor { get; set; }
        public string nomeProduto { get; set; }
        public string nomeFornecedor { get; set; }

        public void InsertEstoque()
        {
            string sql = $"Insert into Estoque (dataValEstoque, numeroLote, qtdEstoque, idProduto, idFornecedor) values ('{DataValEstoque}', '{NumeroLote}', '{QtdEstoque}', '{IdProduto}', '{IdFornecedor}')";
            connection.Execute(sql);
        }
        public void Excluir()
        {
            string sql = $"Delete Estoque where idEstoque =  {IdEstoque.ToString()}";
            connection.Execute(sql);
        }
        public void ConsultarDados()
        {
            string sql = $"Select * from Estoque e inner join Fornecedor f on e.idFornecedor = f.idFornecedor inner join Produto p on e.idProduto = p.idProduto where idEstoque = {IdEstoque}";
            connection.Consult(sql);

            if (connection.dr.Read())
            {
                DataValEstoque = connection.dr["DataValEstoque"].ToString();
                NumeroLote = connection.dr["numeroLote"].ToString();
                QtdEstoque = Convert.ToInt32(connection.dr["qtdEstoque"].ToString());
                nomeProduto = connection.dr["nomeProduto"].ToString();
                nomeFornecedor = connection.dr["nomeFornecedor"].ToString();
                
            }
            connection.Disconnect();
        }
        public DataSet listNotIn()
        {
            string sql = $"select e.idEstoque from Estoque e where e.idEstoque not in (select e.idEstoque from Estoque e inner join Itens_Pedidos iprod on e.idEstoque = iprod.idEstoque)";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }
        public DataSet List()
        {
            string sql = "Select * from Estoque";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }
        public DataSet ListNumLote()
        {
            string sql = "Select * from Estoque";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }
        public void Alterar()
        {
            string sql = $"Update Estoque set dataValEstoque = '{DataValEstoque}',numeroLote = '{NumeroLote}',qtdEstoque = '{QtdEstoque}',idProduto = '{IdProduto}',idFornecedor = '{IdFornecedor}' Where idEstoque =" + IdEstoque.ToString();
            connection.Execute(sql);
        }
    }
}
