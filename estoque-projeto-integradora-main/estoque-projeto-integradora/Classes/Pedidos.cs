using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    internal class Pedidos
    {
        Connection connection = new Connection();

        public int IdPedido { get; set; }
        public string DataPedido { get; set; }
        public Decimal Preco { get; set; }
        public int IdFuncionario { get; set; }
        public int IdCliente { get; set; }

        public string nomeCli { get; set; }
        public string nomeFunc { get; set; }


        public void InsertPedido()
        {
            string sql = $"Insert into Pedidos (DataPedido, Preco, IdFuncionario, IdCliente) values ('{DataPedido}', '{Preco.ToString().Replace(',', '.')}', '{IdFuncionario}', '{IdCliente}')";
            connection.Execute(sql);
        }
        public DataSet pedidosAlt()
        {
            string sql = $"select p.idPedido, f.nomeFuncionario, c.nomeCliente, p.preco from Funcionario f inner join Pedidos p on f.idFuncionario = p.idFuncionario inner join Cliente c on p.idCliente = c.idCliente";
            connection.ListInfo(sql);
            connection.Disconnect();
            return connection.ds;
        }
        public void ExcluirPedido()
        {
            string sql = $"Delete Pedidos where idPedido = {IdPedido.ToString()}";
            connection.Execute(sql);
        }
        public object getLastIdPedido()
        {
            string sql = "select top 1 * from pedidos order by idPedido desc";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds.Tables[0].Rows[0].ItemArray[0];
        }

        public void ConsultPrecoPedido()
        {
            string sql = $"Select * from Pedidos where idPedido = {IdPedido}";

            connection.Consult(sql);
            if (connection.dr.Read())
            {
                Preco = Decimal.Parse(connection.dr["preco"].ToString());
            }
            connection.Disconnect();
        }

        public void DeleteLastPedido()
        {
            string sql = $"Delete Pedidos where idPedido = {IdPedido}";
            connection.Execute(sql);
        }

        public void ConsultarDados()
        {
            string sql = $"Select * from Pedidos p inner join Cliente c on p.idCliente = c.idCliente inner join Funcionario f on p.idFuncionario = f.idFuncionario where idPedido = {IdPedido}";
            connection.Consult(sql);

            if (connection.dr.Read())
            {
                nomeCli = connection.dr["nomeCliente"].ToString();
                nomeFunc = connection.dr["nomeFuncionario"].ToString();
                DataPedido = connection.dr["dataPedido"].ToString();
                Preco = Decimal.Parse(connection.dr["preco"].ToString());
            }
            connection.Disconnect();
        }
    }
}
