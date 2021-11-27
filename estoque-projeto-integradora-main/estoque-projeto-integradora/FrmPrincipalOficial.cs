using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estoque_projeto_integradora
{
    public partial class FrmPrincipalOficial : Form
    {
        //fields 
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activateForm;

        public FrmPrincipalOficial()
        {
            InitializeComponent();
            random = new Random();
            btnFechaChildForms.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //methods
        private void corPainel()
        {
        }
        private void visiblePanel()
        {
            panelCadastrar.Visible = false;
            painelExcluir.Visible = false;
            panelAlterar.Visible = false;

        }

        private void fecharFormButton()
        {
            if (activateForm != null)
                activateForm.Close();
            Reset();
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender !=null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    paneltitlebar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    panelCadastrar.BackColor = color;
                    painelExcluir.BackColor = color;
                    panelAlterar.BackColor = color;
                    ThemeColor.PrimeiraCor = color;
                    ThemeColor.SegundaCor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnFechaChildForms.Visible = true;
                  
                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType()==typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activateForm!=null)
            {
                activateForm.Close();
            }
            ActivateButton(btnSender);
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbltitle.Text = childForm.Text;
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Realizar_Pedido(), sender);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            fecharFormButton();
            visiblePanel();
            ActivateButton(sender);
            panelCadastrar.Visible = true;
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            fecharFormButton();
            visiblePanel();
            ActivateButton(sender);
            panelAlterar.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fecharFormButton();
            visiblePanel();
            ActivateButton(sender);
            painelExcluir.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fecharFormButton();
            visiblePanel();
            OpenChildForm(new Forms.Pesquisar(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fecharFormButton();
            visiblePanel();
            OpenChildForm(new Forms.Relatorio(), sender);
        }

        private void btnFechaChildForms_Click(object sender, EventArgs e)
        {
            visiblePanel();
            if (activateForm != null)
                activateForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lbltitle.Text = "HOME";
            paneltitlebar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnFechaChildForms.Visible = false;

        }

        private void paneltitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void excluFunc_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Excluir_Funcionario(), sender);
        }

        private void ExcluProduto_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Excluir_Estoque(), sender);

        }
        private void cadCliente_Click(object sender, EventArgs e)
        {
            
            visiblePanel();
            OpenChildForm(new Forms.Cadastrar_Cliente(), sender);
        }

        private void cadaFornecedor_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Cadastrar_Fornecedor(), sender);
        }

        private void cadaFuncionario_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Cadastrar_Funcionario(), sender);
        }

        private void cadProduto_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Cadastrar_Produto(), sender);
        }

        private void cadPedidos_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Cadastrar_Setor(), sender);
        }

        private void AltCliente_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Alterar_Cliente(), sender);
        }

        private void AltFornecedor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Alterar_Fornecedor(), sender);
        }

        private void AlterarFuncionario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Alterar_Funcionario(), sender);
        }

        private void AlterarProduto_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AlterarProduto(), sender);
        }

        private void AlterarSetor_Click(object sender, EventArgs e)
        {
            //alterarEstoque
            OpenChildForm(new Forms.Alterar_Estoque(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.CadastrarEstoque(), sender);
        }

        private void ExclCliente_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Excluir_Cliente(), sender);
        }

        private void excluFornecedor_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Excluir_Fornecedor(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.PesquisarMovimentacaoDia(), sender);
        }

        private void cmdPedido_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Excluir_Pedidos(), sender);
        }

        private void cmdEstoque_Click(object sender, EventArgs e)
        {
            visiblePanel();
            OpenChildForm(new Forms.Excluir_Estoque(), sender);
        }
    }
}
