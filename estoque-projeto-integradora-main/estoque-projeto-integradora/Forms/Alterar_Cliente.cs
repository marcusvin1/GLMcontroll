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
    public partial class Alterar_Cliente : Form
    {
        public Alterar_Cliente()
        {
            InitializeComponent();
        }
        Classes.Cliente dados = new Classes.Cliente();
        public void carregar()
        {
            comboboxnome.DisplayMember = "nomeCliente";
            comboboxnome.ValueMember = "idCliente";
            comboboxnome.DataSource = dados.List().Tables[0];
        }
        private void Alterar_Cliente_Load(object sender, EventArgs e)
        {
            carregar();
        }

        private void comboboxnome_SelectedIndexChanged(object sender, EventArgs e)
        {
            dados.IdCliente = int.Parse(comboboxnome.SelectedValue.ToString());
            dados.ConsultarDados();
            txtCpf.Text = dados.CpfCliente;
            txtEndereco.Text = dados.EnderecoCliente;
            txtTelefone.Text = dados.TelefoneCliente;
        }

        private void cmdAlterar_Click(object sender, EventArgs e)
        {
            dados.TelefoneCliente = txtTelefone.Text;
            dados.EnderecoCliente = txtEndereco.Text;
            dados.CpfCliente = txtCpf.Text;
            dados.NomeCliente = comboboxnome.Text;
            dados.AlterarCliente();
            MessageBox.Show("Registro alterado com sucesso!");
            carregar();
        }
    }
}
