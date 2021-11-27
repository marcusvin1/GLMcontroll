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
    public partial class Cadastrar_Setor : Form
    {
        public Cadastrar_Setor()
        {
            InitializeComponent();
        }
        Classes.Setor dataSetor = new Classes.Setor();
        private void cmdCadastrar_Click(object sender, EventArgs e)
        {
            dataSetor.NomeSetor = txtNomeSetor.Text;
            dataSetor.InsertSetor();
            txtNomeSetor.Text = "";
            MessageBox.Show("Setor incluído com sucesso");
            txtNomeSetor.Clear();
        }
    }
}
