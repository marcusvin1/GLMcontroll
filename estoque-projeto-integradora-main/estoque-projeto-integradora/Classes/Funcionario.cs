using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace estoque_projeto_integradora.Classes
{
    class Funcionario
    {
        Connection connection = new Connection();

        public int IdFuncionario { get; set; }
        public string CpfFuncionario { get; set; }
        public string NomeFuncionario{ get; set; }
        public string DataNascFuncionario { get; set; }
        public string EnderecoFuncionario { get; set; }
        public string TelefoneFuncionario { get; set; }
        public string CargoFuncionario { get; set; }


        public void InsertFuncionario()
        {
            string sql = $"Insert into Funcionario (cpfFuncionario, nomeFuncionario, dataNascFuncionario, enderecoFuncionario, telefoneFuncionario, cargoFuncionario) values ('{CpfFuncionario}', '{NomeFuncionario}', '{DataNascFuncionario}', '{EnderecoFuncionario}', '{TelefoneFuncionario}', '{CargoFuncionario}')";
            connection.Execute(sql);
        }
        public void AlterarFuncionario()
        {
            string sql = $"Update Funcionario set cpfFuncionario = '{CpfFuncionario}',dataNascFuncionario = '{DataNascFuncionario}',enderecoFuncionario = '{EnderecoFuncionario}',telefoneFuncionario = '{TelefoneFuncionario}', cargoFuncionario = '{CargoFuncionario}' where idFuncionario = {IdFuncionario}";
            connection.Execute(sql);
        }
        public void Excluir()
        {
            string sql = $"Delete Funcionario where idFuncionario = {IdFuncionario}";
            connection.Execute(sql);
        }

        public DataSet List()
        {
            string sql = "Select * from Funcionario";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }

        public DataSet ListNotIn()
        {
            string sql = "select f.idFuncionario, f.nomeFuncionario from Funcionario f where f.idFuncionario not in (select f.idFuncionario from Funcionario f inner join Pedidos p on f.idFuncionario = p.idFuncionario)";
            connection.ListInfo(sql);

            connection.Disconnect();
            return connection.ds;
        }
        public void ConsultarDados()
        {
            string sql = $"Select * from Funcionario where idFuncionario = {IdFuncionario}";
            connection.Consult(sql);

            if (connection.dr.Read())
            {
                CpfFuncionario = connection.dr["cpfFuncionario"].ToString();
                DataNascFuncionario = connection.dr["dataNascFuncionario"].ToString();
                EnderecoFuncionario = connection.dr["enderecoFuncionario"].ToString();
                CargoFuncionario = connection.dr["cargoFuncionario"].ToString();
                TelefoneFuncionario = connection.dr["telefoneFuncionario"].ToString();
            }
            connection.Disconnect();
        }
    }
}


