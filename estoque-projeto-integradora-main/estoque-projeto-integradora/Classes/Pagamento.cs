using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    internal class Pagamento
    {
        Connection connection = new Connection();

        public int IdPagamento { get; set; }
        public int IdPedido { get; set; }
        public string FormaPagamento { get; set; }
        public int QuantidadeParcela { get; set; }
        public string PrecoTotal { get; set; }

        public void InsertPagamento()
        {
            string sql = $"Insert into Pagamento ( idPedido, formaPagamento, quantidadeParcela, precoTotal) values ('{IdPedido}', '{FormaPagamento}', {QuantidadeParcela}, {PrecoTotal.ToString().Replace(',', '.')})";
            connection.Execute(sql);
        }

        public void ConsultLastIdPagamento()
        {
            string sql = $"select top 1 * from Pagamento order by idPagamento desc";

            connection.Consult(sql);
            if (connection.dr.Read())
            {
                IdPagamento = int.Parse(connection.dr["idPagamento"].ToString());
            }
            connection.Disconnect();
        }

    }
}
