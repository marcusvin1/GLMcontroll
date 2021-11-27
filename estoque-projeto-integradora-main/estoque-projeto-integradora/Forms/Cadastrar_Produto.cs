using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace estoque_projeto_integradora.Forms
{
    public partial class Cadastrar_Produto : Form
    {
        public Cadastrar_Produto()
        {
            InitializeComponent();
        }
        Classes.Setor dataSetor = new Classes.Setor();
        Classes.Produto dataProduto = new Classes.Produto();
        Classes.Fornecedor dataFornecedor = new Classes.Fornecedor();
        Classes.Estoque dataEstoque = new Classes.Estoque();
        string valorProd;
        public void CarregarCombo()
        {
            pictureBox1.Image = Properties.Resources.semfoto;
            ConverteFoto();
            comboBox1.DisplayMember = "nomeSetor";
            comboBox1.ValueMember = "idSetor";
            comboBox1.DataSource = dataSetor.List().Tables[0];
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Cadastrar_Produto_Load(object sender, EventArgs e)
        {
            CarregarCombo();

            /*cbFornecedor.DisplayMember = "nomeFornecedor";
            cbFornecedor.ValueMember = "idFornecedor";
            cbFornecedor.DataSource = dataFornecedor.List().Tables[0];
            cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;*/
        }

        private void cmdCadastrar_Click(object sender, EventArgs e)
        {
            valorProd = txtPreco.Text;

            if (valorProd.Contains("."))
            {
                valorProd = valorProd.Replace(".", ",");
            }
            dataProduto.IdSetor = int.Parse(comboBox1.SelectedValue.ToString());
            dataProduto.NomeProduto = txtNomeProduto.Text;
            dataProduto.DescProduto = txtDesc.Text;
            dataProduto.PrecoProduto = Convert.ToDecimal(valorProd, CultureInfo.CurrentCulture);
            dataProduto.InsertProduto();
            MessageBox.Show("Produto Cadastrado com sucesso");
            txtNomeProduto.Clear();
            txtDesc.Clear();
            txtPreco.Clear();
            CarregarCombo();

            /*dataEstoque.DataValEstoque = dateTimePicker1.Text.ToString();
            dataEstoque.QtdEstoque = int.Parse(nudQuantidade.ToString());
            dataEstoque.IdFornecedor = int.Parse(cbFornecedor.SelectedValue.ToString());
            dataEstoque.IdProduto = ;

            dataEstoque.InsertEstoque();*/


        }

        private void cmdImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                ConverteFoto();
            }
        }

        private void ConverteFoto()
        {
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] fotoArray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(fotoArray, 0, fotoArray.Length);
                dataProduto.FotoProduto = fotoArray;
            }
        }
    }
}
