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
    public partial class Cadastrar_Fornecedor : Form
    {
        Classes.Fornecedor dataFornecedor = new Classes.Fornecedor();
        public Cadastrar_Fornecedor()
        {
            InitializeComponent();
        }
        private void cmdCadastrar_Click(object sender, EventArgs e)
        {
            dataFornecedor.NomeFornecedor = txtNomeFornecedor.Text;
            dataFornecedor.CnpjFornecedor = txtCnpjFornecedor.Text;
            dataFornecedor.TelefoneFornecedor = txtTelefoneFornecedor.Text;
            dataFornecedor.InsertFornecedor();

            txtCnpjFornecedor.Text = "";
            txtNomeFornecedor.Text = "";
            txtTelefoneFornecedor.Text = "";

            MessageBox.Show("Fornecedor incluído com sucesso");
        }
    }
}
