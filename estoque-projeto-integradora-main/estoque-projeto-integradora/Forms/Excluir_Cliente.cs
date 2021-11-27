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
    public partial class Excluir_Cliente : Form
    {
        public Excluir_Cliente()
        {
            InitializeComponent();
        }
        Classes.Cliente dados = new Classes.Cliente();
        public void CarregaCombo()
        {
            comboboxnome.DisplayMember = "nomeCliente";
            comboboxnome.ValueMember = "idCliente";
            comboboxnome.DataSource = dados.ListNotIn().Tables[0];
        }
        private void Excluir_Cliente_Load(object sender, EventArgs e)
        {
            CarregaCombo();
        }

        private void comboboxnome_SelectedIndexChanged(object sender, EventArgs e)
        {
            dados.IdCliente = int.Parse(comboboxnome.SelectedValue.ToString());
            dados.ConsultarDados();
            txtCpf.Text = dados.CpfCliente;
            txtEndereco.Text = dados.EnderecoCliente;
            txtTelefone.Text = dados.TelefoneCliente;
        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            dados.Excluir();
            MessageBox.Show("Cliente excluido com sucesso");
            CarregaCombo();
        }
    
    }
}
