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
    public partial class Cadastrar_Funcionario : Form
    {
        public Cadastrar_Funcionario()
        {
            InitializeComponent();
        }
        Classes.Funcionario dataFunc = new Classes.Funcionario();
        private void cmdCadastrar_Click(object sender, EventArgs e)
        {
            dataFunc.CpfFuncionario = txtCpf.Text;
            dataFunc.NomeFuncionario = txtNomeFunc.Text;
            dataFunc.DataNascFuncionario = dateTimePicker1.Text;
            dataFunc.EnderecoFuncionario = txtEndereco.Text;
            dataFunc.TelefoneFuncionario = txtTelefone.Text;
            dataFunc.CargoFuncionario = txtCargo.Text;

            dataFunc.InsertFuncionario();
            MessageBox.Show("Funcionario inserido com sucesso");
            txtCargo.Text = "";
            txtCpf.Text = "";
            dateTimePicker1.Text = "";
            txtEndereco.Text = "";
            txtNomeFunc.Text = "";
            txtTelefone.Text = "";
        }
    }
}
