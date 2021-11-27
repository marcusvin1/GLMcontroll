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
    public partial class Cadastrar_Cliente : Form
    {
        public Cadastrar_Cliente()
        {
            InitializeComponent();
        }
        Classes.Cliente dataCliente = new Classes.Cliente();
        private void Cadastrar_Cliente_Load(object sender, EventArgs e)
        {

        }
        private void cmdCadastrar_Click(object sender, EventArgs e)
        {
            dataCliente.TelefoneCliente = txtTelefone.Text;
            dataCliente.NomeCliente = txtNome.Text;
            dataCliente.EnderecoCliente = txtEndereco.Text;
            dataCliente.CpfCliente = txtCpf.Text;

            dataCliente.InsertCliente();

            txtCpf.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            MessageBox.Show("Cliente incluído com sucesso");
        }
    }
}
