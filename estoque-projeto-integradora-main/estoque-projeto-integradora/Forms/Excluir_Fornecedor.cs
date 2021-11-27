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
    public partial class Excluir_Fornecedor : Form
    {
        public Excluir_Fornecedor()
        {
            InitializeComponent();
        }
        Classes.Fornecedor dataFornecedor = new Classes.Fornecedor();
        public void carregarCombo()
        {
            comboBox1.DisplayMember = "nomeFornecedor";
            comboBox1.ValueMember = "idFornecedor";
            comboBox1.DataSource = dataFornecedor.ListNotIn().Tables[0];
        }
        private void Excluir_Fornecedor_Load(object sender, EventArgs e)
        {
            carregarCombo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataFornecedor.IdFornecedor = int.Parse(comboBox1.SelectedValue.ToString());
            dataFornecedor.ConsultarDados();
            txtCnpjFornecedor.Text = dataFornecedor.CnpjFornecedor;
            txtTelefoneFornecedor.Text = dataFornecedor.TelefoneFornecedor;
        }

        private void cmdExclu_Click(object sender, EventArgs e)
        {
            dataFornecedor.Excluir();
            MessageBox.Show("Fornecedor excluido");
            carregarCombo();
        }
    }
}
