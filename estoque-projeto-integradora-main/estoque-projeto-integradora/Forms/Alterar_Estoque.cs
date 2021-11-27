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
    public partial class Alterar_Estoque : Form
    {
        public Alterar_Estoque()
        {
            InitializeComponent();
        }
        private Classes.Estoque dataEstoque = new Classes.Estoque();
        private Classes.Fornecedor dataFornecedor = new Classes.Fornecedor();
        private Classes.Produto dataProduto = new Classes.Produto();
        private void Alterar_Estoque_Load(object sender, EventArgs e)
        {
            cbEstoque.DisplayMember = ("idEstoque").ToString();
            cbEstoque.ValueMember = "idEstoque";
            cbEstoque.DataSource = dataEstoque.List().Tables[0];
            cbFornecedor.DisplayMember = "nomeFornecedor";
            cbFornecedor.ValueMember = "idFornecedor";
            cbFornecedor.DataSource = dataFornecedor.List().Tables[0];
            cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProduto.DisplayMember = "nomeProduto";
            cbProduto.ValueMember = "idProduto";
            cbProduto.DataSource = dataProduto.List().Tables[0];
            cbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void cmdAlterar_Click(object sender, EventArgs e)
        {
            dataEstoque.IdFornecedor = int.Parse(cbFornecedor.SelectedValue.ToString());
            dataEstoque.IdProduto = int.Parse(cbProduto.SelectedValue.ToString());
            dataEstoque.NumeroLote = txtNumLote.Text;
            dataEstoque.QtdEstoque = Convert.ToInt32(nudQuantidade.Value);
            dataEstoque.DataValEstoque = dateTimePicker1.Text;
            dataEstoque.Alterar();
            MessageBox.Show("Registro alterado com sucesso!");
        }   
    }
}
