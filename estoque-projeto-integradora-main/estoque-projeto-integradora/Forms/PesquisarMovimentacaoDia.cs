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
    public partial class PesquisarMovimentacaoDia : Form
    {
        public PesquisarMovimentacaoDia()
        {
            InitializeComponent();
        }
        Classes.Geral dataGeral = new Classes.Geral();

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            dataGeral.DataPedidoDia = dateTimePicker2.Text;
            dataGridView1.DataSource = dataGeral.ListPedidosDoDia().Tables[0];
            dataGeral.ConsultarSomaPedidosDia();
            txtFaturamento.Text = dataGeral.TotalPedidosDia.ToString();
        }
    }
}
