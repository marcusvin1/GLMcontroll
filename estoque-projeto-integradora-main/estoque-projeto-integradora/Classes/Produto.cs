using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    class Produto
    {
        Connection connection = new Connection();

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescProduto { get; set; }
        public Decimal PrecoProduto { get; set; }
        public int IdSetor { get; set; }
        public byte[] FotoProduto { get; set; }
        public string nomeSetor { get; set; }

        public void InsertProduto()
        {
            string sql = $"Insert into Produto (nomeProduto, descProduto, precoProduto, idSetor, fotoProduto) values ('{NomeProduto}', '{DescProduto}', '{PrecoProduto.ToString().Replace(',','.')}', '{IdSetor}', @BINARIO)";
            connection.ExecuteFoto(sql,FotoProduto);
        }
        public void Alterar()
        {
            string sql = $"Update Produto set descProduto = '{DescProduto}',precoProduto = '{PrecoProduto.ToString().Replace(',','.')}',idSetor = '{IdSetor}', fotoProduto = @Binario Where idProduto =" + IdProduto.ToString();
            connection.ExecuteFoto(sql, FotoProduto);
        }
        public DataSet List()
        {
            string sql = "Select * from Produto";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }
        public DataSet ListNotIn()
        {
            string sql = "select p.idProduto, p.nomeProduto from Produto p where p.idProduto in (select p.idProduto from Produto p inner join Estoque e on p.idProduto = e.idProduto)";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }

        public void Consult()
        {
            string sql = $"Select * from Produto p inner join Setor s on p.idSetor = s.idSetor where idProduto = {IdProduto}";

            connection.Consult(sql);
            if (connection.dr.Read())
            {
                PrecoProduto = Decimal.Parse(connection.dr["precoProduto"].ToString());
                DescProduto = connection.dr["descProduto"].ToString();
                nomeSetor = connection.dr["nomeSetor"].ToString();
                FotoProduto = (byte[])connection.dr["fotoProduto"];
            }
            connection.Disconnect();
        }
    }
}
