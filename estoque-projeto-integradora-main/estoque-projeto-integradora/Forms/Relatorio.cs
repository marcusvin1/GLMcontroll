using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estoque_projeto_integradora.Forms
{
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
        }
        Classes.Geral dataGeral = new Classes.Geral();

        private int i = 0;
        private void cmdGerarRelatório_Click(object sender, EventArgs e)
        {
            dataGeral.DataPedidoDia = dateTimePicker2.Text;
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = "Relatório";
            pd.BeginPrint += Pd_BeginPrint;
            pd.PrintPage += Imprimir;
            //cria objeto preview 
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }
        private void Pd_BeginPrint(object sender, PrintEventArgs e)
        {
            //O que deve ocorrer antes de iniciar a impressão 
            i = 0;
        }
        private void Imprimir(object sender, PrintPageEventArgs ev)
        {
            //Configurações da página
            float linhaPorPagina = 0;
            float posicaoVertical = 0;
            float contador = 0;
            float margemEsqueda = 20;
            float margemSuperior = 20;
            float alturaFonte = 0;
            string linha = "";

            Font fonte = new Font("Arial", 14);
            alturaFonte = fonte.GetHeight(ev.Graphics);
            linhaPorPagina = Convert.ToInt32(ev.MarginBounds.Height / alturaFonte);

            //Título
            linha = "Pedidos feitos";
            posicaoVertical = margemSuperior + contador * alturaFonte;

            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda, posicaoVertical);
            contador += 4;

            linha = "Funcionario";
            posicaoVertical = margemSuperior + contador * alturaFonte;
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda, posicaoVertical);

            linha = "Cliente";
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda + 200, posicaoVertical);

            linha = "Preço";
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda + 400, posicaoVertical);

            linha = "Data Pedido";
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda + 600, posicaoVertical);

            contador += 1;
            linha = "----------------------------------------------------------------------------------------------------------------------------";
            posicaoVertical = margemSuperior + contador * alturaFonte;
            ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda, posicaoVertical);

            contador++;
            DataSet ds = dataGeral.ListRelatorio();

            if (ds.Tables[0] != null)
            {
                while (i < ds.Tables[0].Rows.Count && contador < linhaPorPagina)
                {
                    DataRow item = ds.Tables[0].Rows[i];

                    linha = item["nomeFuncionario"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda, posicaoVertical);

                    linha = item["nomeCliente"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda + 200, posicaoVertical);

                    linha = item["preco"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda + 400, posicaoVertical);

                    linha = item["dataPedido"].ToString();
                    posicaoVertical = margemSuperior + contador * alturaFonte;
                    ev.Graphics.DrawString(linha, fonte, Brushes.Black, margemEsqueda + 600, posicaoVertical);


                    contador += 2;
                    i++;
                }

            }
            else MessageBox.Show("Não existe Pessoa cadastrada!");

            if (contador > linhaPorPagina)
            {
                ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;
            }
        }

        
    }
}
