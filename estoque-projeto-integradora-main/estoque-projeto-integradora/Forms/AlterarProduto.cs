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
    public partial class AlterarProduto : Form
    {
        public AlterarProduto()
        {
            InitializeComponent();
        }
        Classes.Produto dados = new Classes.Produto();
        Classes.Setor dadosSetor = new Classes.Setor();
        public void carregar()
        {
            cbnomeProd.DisplayMember = "nomeProduto";
            cbnomeProd.ValueMember = "idProduto";
            cbnomeProd.DataSource = dados.List().Tables[0];
            cbSetor.DisplayMember = "nomeSetor";
            cbSetor.ValueMember = "idSetor";
            cbSetor.DataSource = dadosSetor.List().Tables[0];
        }
        private void AlterarProduto_Load(object sender, EventArgs e)
        {
            carregar();
        }

        private void cbnomeProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            dados.IdProduto = int.Parse(cbnomeProd.SelectedValue.ToString());
            dados.Consult();
            if (!(dados.FotoProduto is null))
            {
                MemoryStream ms = new MemoryStream();
                ms.Write(dados.FotoProduto, 0, dados.FotoProduto.Length);
                pictureBox1.Image = Image.FromStream(ms);
            }
            txtPreco.Text = dados.PrecoProduto.ToString();
            txtDesc.Text = dados.DescProduto.ToString();
            cbSetor.Text = dados.nomeSetor;
        }

        private void cmdImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                ConverteFoto();
            }
            else
            {
                pictureBox1.Image = Properties.Resources.semfoto;
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
                dados.FotoProduto = fotoArray;
            }
        }

        private void cmdAlterar_Click(object sender, EventArgs e)
        {
            dados.IdSetor = int.Parse(cbSetor.SelectedValue.ToString());
            dados.DescProduto = txtDesc.Text;
            dados.PrecoProduto = Convert.ToDecimal(txtPreco.Text, CultureInfo.CurrentCulture);
            dados.Alterar();
        }
    }
}
