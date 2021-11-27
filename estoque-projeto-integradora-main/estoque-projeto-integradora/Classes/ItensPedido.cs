using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    internal class ItensPedido
    {
        Connection connection = new Connection();

        public int IdItensPedidos { get; set; }
        public int IdPedido { get; set; }
        public int IdEstoque { get; set; }
        public int QuantidadeItensPedido { get; set; }
        public Decimal PrecoItensPedido { get; set; }
        


        public void InsertItensPedido()
        {
            string sql = $"Insert into Itens_Pedidos (idPedido, idEstoque, quantidadeItensPedido, precoItensPedido) values ('{IdPedido}', '{IdEstoque}', '{QuantidadeItensPedido}', '{PrecoItensPedido.ToString().Replace(',', '.')}')";
            connection.Execute(sql);
        }

        
    }
}
