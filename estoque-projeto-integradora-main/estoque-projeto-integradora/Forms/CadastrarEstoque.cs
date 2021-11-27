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
    public partial class CadastrarEstoque : Form
    {
        public CadastrarEstoque()
        {
            InitializeComponent();
        }
        Classes.Estoque dataEstoque = new Classes.Estoque();
        Classes.Fornecedor dataFornecedor = new Classes.Fornecedor();
        Classes.Produto dataProduto = new Classes.Produto();
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("The selected value is " + dateTimePicker1.Text);
        }
        public void carregarCombo()
        {
            cbFornecedor.DisplayMember = "nomeFornecedor";
            cbFornecedor.ValueMember = "idFornecedor";
            cbFornecedor.DataSource = dataFornecedor.List().Tables[0];
            cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProduto.DisplayMember = "nomeProduto";
            cbProduto.ValueMember = "idProduto";
            cbProduto.DataSource = dataProduto.List().Tables[0];
            cbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CadastrarEstoque_Load(object sender, EventArgs e)
        {
            carregarCombo();
        }

        private void cmdCadastrar_Click(object sender, EventArgs e)
        {
            dataEstoque.QtdEstoque = int.Parse(nudQuantidade.Value.ToString());
            dataEstoque.DataValEstoque = dateTimePicker1.Text;
            dataEstoque.NumeroLote = txtNumLote.Text;
            dataEstoque.IdFornecedor = int.Parse(cbFornecedor.SelectedValue.ToString());
            dataEstoque.IdProduto = int.Parse(cbProduto.SelectedValue.ToString());
            dataEstoque.InsertEstoque();
            MessageBox.Show("Estoque cadastrado com sucesso!");
            txtNumLote.Text = "";
            nudQuantidade.Value = 0;
            carregarCombo();
        }
    }
}
