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
    public partial class Alterar_Funcionario : Form
    {
        public Alterar_Funcionario()
        {
            InitializeComponent();
        }
        Classes.Funcionario dados = new Classes.Funcionario();
        private void Alterar_Funcionario_Load(object sender, EventArgs e)
        {
            cbNome.DisplayMember = "nomeFuncionario";
            cbNome.ValueMember = "idFuncionario";
            cbNome.DataSource = dados.List().Tables[0];
        }

        private void cbNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            dados.IdFuncionario = int.Parse(cbNome.SelectedValue.ToString());
            dados.ConsultarDados();
            txtCargo.Text = dados.CargoFuncionario;
            txtCpf.Text = dados.CpfFuncionario;
            txtDataNascimento.Text = dados.DataNascFuncionario;
            txtEndereco.Text = dados.EnderecoFuncionario;
            txtTelefone.Text = dados.TelefoneFuncionario;
        }

        private void alterFunc_Click(object sender, EventArgs e)
        {
            dados.CargoFuncionario = txtCargo.Text;
            dados.CpfFuncionario = txtCpf.Text;
            dados.DataNascFuncionario = txtDataNascimento.Text;
            dados.EnderecoFuncionario = txtEndereco.Text;
            dados.TelefoneFuncionario = txtTelefone.Text;
            dados.AlterarFuncionario();
            MessageBox.Show("Dados alterados !!");
        }
    }
}
