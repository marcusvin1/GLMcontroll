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
    public partial class Excluir_Estoque : Form
    {
        public Excluir_Estoque()
        {
            InitializeComponent();
        }
        private Classes.Estoque dataEstoque = new Classes.Estoque();
        private Classes.Fornecedor dataFornecedor = new Classes.Fornecedor();
        private Classes.Produto dataProduto = new Classes.Produto();
        public void carregarCombo()
        {
            cbEstoque.DisplayMember = ("idEstoque").ToString();
            cbEstoque.ValueMember = "idEstoque";
            cbEstoque.DataSource = dataEstoque.listNotIn().Tables[0];
            cbFornecedor.DisplayMember = "nomeFornecedor";
            cbFornecedor.ValueMember = "idFornecedor";
            cbFornecedor.DataSource = dataFornecedor.List().Tables[0];
            cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProduto.DisplayMember = "nomeProduto";
            cbProduto.ValueMember = "idProduto";
            cbProduto.DataSource = dataProduto.List().Tables[0];
            cbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Excluir_Estoque_Load(object sender, EventArgs e)
        {
            carregarCombo();
        }

        private void cbEstoque_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEstoque.IdEstoque = int.Parse(cbEstoque.SelectedValue.ToString());
            dataEstoque.ConsultarDados();
            txtNumLote.Text = dataEstoque.NumeroLote;
            cbFornecedor.Text = dataEstoque.nomeFornecedor;
            cbProduto.Text = dataEstoque.nomeProduto;
            nudQuantidade.Value = dataEstoque.QtdEstoque;
            dateTimePicker1.Text = dataEstoque.DataValEstoque;
        }

        private void cmdexcluir_Click(object sender, EventArgs e)
        {
            dataEstoque.Excluir();
            MessageBox.Show("Estoque excluido com sucesso!");
            carregarCombo();

        }
    }
}
