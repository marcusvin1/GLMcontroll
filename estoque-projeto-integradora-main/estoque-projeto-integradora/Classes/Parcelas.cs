using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    internal class Parcelas
    {
        Connection connection = new Connection();

        public int IdParcela { get; set; }
        public int IdPagamento { get; set; }
        public int NumeroParcela { get; set; }
        public Decimal PrecoParcela { get; set; }



        public void InsertParcelas(int qtdParcela, Decimal precoTotal)
        {
            PrecoParcela = precoTotal / qtdParcela;
            for (int i = 0; i < qtdParcela; i++)
            {
                string sql = $"Insert into Parcela (idPagamento, numeroParcela, precoParcela) values ({IdPagamento}, {i}, {PrecoParcela.ToString().Replace(',', '.')})";
                connection.Execute(sql);
            } 
        }

    }
}
