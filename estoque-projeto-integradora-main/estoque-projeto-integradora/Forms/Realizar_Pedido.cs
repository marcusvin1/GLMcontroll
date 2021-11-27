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
    public partial class Realizar_Pedido : Form
    {
        //int quantidade;
        //float preco;
        //float total;
        int i;
        FrmPrincipalOficial x = new FrmPrincipalOficial();
        Classes.Produto dataProduto = new Classes.Produto();
        Classes.Cliente dataCliente = new Classes.Cliente();
        Classes.Funcionario dataFuncionario = new Classes.Funcionario();
        Classes.Pedidos dataPedido = new Classes.Pedidos();
        Classes.ItensPedido dataItensPedido = new Classes.ItensPedido();
        Classes.Estoque dataEstoque = new Classes.Estoque();
        Classes.Geral dataGeral = new Classes.Geral();
        Classes.Pagamento dataPagamento = new Classes.Pagamento();
        Classes.Parcelas dataParcelas = new Classes.Parcelas();
        public Realizar_Pedido()
        {
            InitializeComponent();
        }
        private void cmdIniciarPedido_Click(object sender, EventArgs e)
        {
            dataPedido.DataPedido = dateTimePicker1.Value.ToString();
            dataPedido.Preco = 0;
            dataPedido.IdFuncionario = int.Parse(cbFuncionario.SelectedValue.ToString());
            dataPedido.IdCliente = int.Parse(cbCliente.SelectedValue.ToString());
            dataPedido.InsertPedido();

            cbProduto.DisplayMember = "nomeProduto";
            cbProduto.ValueMember = "idProduto";
            cbProduto.DataSource = dataProduto.ListNotIn().Tables[0];
            cbProduto.DropDownStyle = ComboBoxStyle.DropDownList;

            panel3.Visible = false;


        }
        private void cbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGeral.IdProduto = int.Parse(cbProduto.SelectedValue.ToString());
            dataProduto.IdProduto = int.Parse(cbProduto.SelectedValue.ToString());

            cbNumLote.DisplayMember = "numeroLote";
            cbNumLote.ValueMember = "idEstoque";
            cbNumLote.DataSource = dataGeral.ListNumeroLote().Tables[0];
            cbNumLote.DropDownStyle = ComboBoxStyle.DropDownList;

            dataProduto.Consult();
            txtPrecoProduto.Text = dataProduto.PrecoProduto.ToString();
        }
        /*private void nudQtdItensPedido_ValueChanged(object sender, EventArgs e)
        {
            preco = float.Parse(txtPrecoProduto.Text);
            quantidade = int.Parse(nudQtdItensPedido.Text);
            total = preco * quantidade;
            txtPrecoPedido.Text = total.ToString();
        }*/
        private void cbNumLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataItensPedido.IdEstoque = int.Parse(cbNumLote.SelectedValue.ToString());
        }

        private void cmdAddProduto_Click(object sender, EventArgs e)
        {
            i++;
            dataItensPedido.PrecoItensPedido = Decimal.Parse(txtPrecoProduto.Text);
            dataItensPedido.QuantidadeItensPedido = int.Parse(nudQtdItensPedido.Value.ToString());
            dataItensPedido.IdPedido = int.Parse(dataPedido.getLastIdPedido().ToString());
            dataPedido.IdPedido = int.Parse(dataPedido.getLastIdPedido().ToString());
            dataPagamento.IdPedido = int.Parse(dataPedido.getLastIdPedido().ToString());


            dataItensPedido.InsertItensPedido();

            dataGridView1.DataSource = dataGeral.ListItensNomeProduto(i).Tables[0];

            dataPedido.ConsultPrecoPedido();
            txtPrecoPedido.Text = "R$" + dataPedido.Preco.ToString();

            cmdFinalizar.Enabled = true;
            nudQtdItensPedido.Value = 1;

        }
        private void cmdConfirmar_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            txtVALORFINAL.Text = "R$" + dataPedido.Preco.ToString();
        }

        private void Realizar_Pedido_Load(object sender, EventArgs e)
        {
            cbCliente.DisplayMember = "nomeCliente";
            cbCliente.ValueMember = "idCliente";
            cbCliente.DataSource = dataCliente.List().Tables[0];
            cbCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            cbFuncionario.DisplayMember = "nomeFuncionario";
            cbFuncionario.ValueMember = "idFuncionario";
            cbFuncionario.DataSource = dataFuncionario.List().Tables[0];
            cbFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;

            cbFormaPag.Text = "À vista";
            /*
            cbProduto.DisplayMember = "nomeProduto";
            cbProduto.ValueMember = "idProduto";
            cbProduto.DataSource = dataProduto.List().Tables[0];
            cbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            */
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbFormaPag.SelectedItem == "Crediário") 
            {
                dataPagamento.QuantidadeParcela = int.Parse(cbParcelas.SelectedItem.ToString());
            }
            dataPagamento.FormaPagamento = cbFormaPag.SelectedItem.ToString();
            dataPagamento.PrecoTotal = dataPedido.Preco.ToString();
            dataPagamento.InsertPagamento();
            if (cbFormaPag.SelectedItem == "Crediário")
            {
                dataPagamento.ConsultLastIdPagamento();
                dataParcelas.IdPagamento = dataPagamento.IdPagamento;
                dataParcelas.InsertParcelas(dataPagamento.QuantidadeParcela, Decimal.Parse(dataPedido.Preco.ToString()));
            }
            txtValorParcela.Text = dataParcelas.PrecoParcela.ToString();
            button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFormaPag.SelectedItem == "Crediário")
            {
                lblParcela.Visible = true;
                txtValorParcela.Visible = true;
                cbParcelas.Visible = true;
                label9.Visible = true;
            }
            else
            {
                cbParcelas.Visible = false;
                label9.Visible = false;
                dataPagamento.QuantidadeParcela = 0;
                txtValorParcela.Visible = false;
                lblParcela.Visible = false;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            dataPedido.IdPedido = int.Parse(dataPedido.getLastIdPedido().ToString());
            dataPedido.DeleteLastPedido();
        }
    }
}
