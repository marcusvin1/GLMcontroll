using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estoque_projeto_integradora.Forms
{
    public partial class Excluir_Pedidos : Form
    {
        public Excluir_Pedidos()
        {
            InitializeComponent();
        }
        Classes.Pedidos dados = new Classes.Pedidos();
        Classes.Funcionario func = new Classes.Funcionario();
        Classes.Cliente cli = new Classes.Cliente();
        public void CarregaCombo()
        {
            cbPedido.DisplayMember = "idPedido".ToString();
            cbPedido.ValueMember = "idPedido";
            cbPedido.DataSource = dados.pedidosAlt().Tables[0];

            cbFuncionario.DisplayMember = "nomeFuncionario".ToString();
            cbFuncionario.ValueMember = "idFuncionario";
            cbFuncionario.DataSource = func.List().Tables[0];

            cbCliente.DisplayMember = "nomeCliente".ToString();
            cbCliente.ValueMember = "idCliente";
            cbCliente.DataSource = cli.List().Tables[0];
        }
        private void Excluir_Pedidos_Load(object sender, EventArgs e)
        {
            CarregaCombo();
        }

        private void cbPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            dados.IdPedido = int.Parse(cbPedido.SelectedValue.ToString());
            dados.ConsultarDados();
            cbCliente.Text = dados.nomeCli;
            cbFuncionario.Text = dados.nomeFunc;
            dateTimePicker1.Text = dados.DataPedido;
            txtPreco.Text = dados.Preco.ToString("C");
            
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            dados.ExcluirPedido();
            MessageBox.Show("Pedido excluido com sucesso");
            CarregaCombo();
        }
    }
}
