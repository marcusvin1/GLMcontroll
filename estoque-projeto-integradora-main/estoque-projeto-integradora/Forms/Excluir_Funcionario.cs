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
    public partial class Excluir_Funcionario : Form
    {
        public Excluir_Funcionario()
        {
            InitializeComponent();
        }
        Classes.Funcionario dados = new Classes.Funcionario();
        public void carregarCombo()
        {
            cbNome.DisplayMember = "nomeFuncionario";
            cbNome.ValueMember = "idFuncionario";
            cbNome.DataSource = dados.ListNotIn().Tables[0];
        }
        private void Excluir_Funcionario_Load(object sender, EventArgs e)
        {
            carregarCombo();
        }

        private void cbNome_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dados.IdFuncionario = int.Parse(cbNome.SelectedValue.ToString());
            dados.ConsultarDados();
            txtCargo.Text = dados.CargoFuncionario;
            txtCpf.Text = dados.CpfFuncionario;
            txtDataNascimento.Text = dados.DataNascFuncionario;
            txtEndereco.Text = dados.EnderecoFuncionario;
            txtTelefone.Text = dados.TelefoneFuncionario;
        }

        private void alterFunc_Click_1(object sender, EventArgs e)
        {
            dados.Excluir();
            MessageBox.Show("Funcionario excluido !!");
            carregarCombo();
        }
    }
}
