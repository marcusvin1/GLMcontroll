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
    public partial class Alterar_Fornecedor : Form
    {
        public Alterar_Fornecedor()
        {
            InitializeComponent();
        }
        Classes.Fornecedor dados = new Classes.Fornecedor();
        private void Alterar_Fornecedor_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "nomeFornecedor";
            comboBox1.ValueMember = "idFornecedor";
            comboBox1.DataSource = dados.List().Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dados.IdFornecedor = int.Parse(comboBox1.SelectedValue.ToString());
            dados.ConsultarDados();
            txtCnpjFornecedor.Text = dados.CnpjFornecedor;
            txtTelefoneFornecedor.Text = dados.TelefoneFornecedor;
        }

        private void cmdAlter_Click(object sender, EventArgs e)
        {
            dados.TelefoneFornecedor = txtTelefoneFornecedor.Text;
            dados.CnpjFornecedor = txtCnpjFornecedor.Text;
            dados.AlterFornecedor();
            MessageBox.Show("Dados alterados");
        }
    }
}
