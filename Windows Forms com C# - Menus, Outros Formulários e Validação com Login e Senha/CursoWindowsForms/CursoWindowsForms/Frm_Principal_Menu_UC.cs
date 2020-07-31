using CursoWindowsFormsBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWindowsForms
{
    public partial class Frm_Principal_Menu_UC : Form
    {
        int controleDemonstracao = 0;
        int controleHelloWorld = 0;
        int controleMascara = 0;
        int controleValidaCPF = 0;
        int controleValidaCPF2 = 0;
        int controleValidaSenha = 0;
        int controleArquivoImagem = 0;

        public Frm_Principal_Menu_UC()
        {
            InitializeComponent();
            novoToolStripMenuItem.Enabled = false;
            apagarAbaToolStripMenuItem.Enabled = false;
            abrirImagemToolStripMenuItem.Enabled = false;
            desconectarToolStripMenuItem.Enabled = false;
        }

        private void demonstraçãoKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controleDemonstracao++;

            Frm_DemonstracaoKey_UC f = new Frm_DemonstracaoKey_UC();
            f.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Desmonstração Key " + controleDemonstracao;
            tb.Text = "Desmonstração Key " + controleDemonstracao;
            tb.ImageIndex = 0;
            tb.Controls.Add(f);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controleHelloWorld++;

            Frm_HelloWorld_UC f = new Frm_HelloWorld_UC();
            f.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Hello World " + controleHelloWorld;
            tb.Text = "Hello World " + controleHelloWorld;
            tb.ImageIndex = 1;
            tb.Controls.Add(f);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void máscaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controleMascara++;

            Frm_Mascara_UC f = new Frm_Mascara_UC();
            f.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Máscara " + controleMascara;
            tb.Text = "Máscara " + controleMascara;
            tb.ImageIndex = 2;
            tb.Controls.Add(f);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void validaCPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controleValidaCPF++;

            Frm_ValidaCPF_UC f = new Frm_ValidaCPF_UC();
            f.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida CPF " + controleValidaCPF;
            tb.Text = "Valida CPF " + controleValidaCPF;
            tb.ImageIndex = 3;
            tb.Controls.Add(f);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void validaCPF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controleValidaCPF2++;

            Frm_ValidaCPF2_UC f = new Frm_ValidaCPF2_UC();
            f.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida CPF 2 " + controleValidaCPF2;
            tb.Text = "Valida CPF 2 " + controleValidaCPF2;
            tb.ImageIndex = 4;
            tb.Controls.Add(f);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void validaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controleValidaSenha++;

            Frm_ValidaSenha_UC f = new Frm_ValidaSenha_UC();
            f.Dock = DockStyle.Fill;
            TabPage tb = new TabPage();
            tb.Name = "Valida Senha " + controleValidaSenha;
            tb.Text = "Valida Senha " + controleValidaSenha;
            tb.ImageIndex = 5;
            tb.Controls.Add(f);
            Tbc_Aplicacoes.TabPages.Add(tb);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void apagarAbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(Tbc_Aplicacoes.SelectedTab == null))
            {
                Tbc_Aplicacoes.TabPages.Remove(Tbc_Aplicacoes.SelectedTab);
            }
        }

        private void abrirImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Db = new OpenFileDialog();
            Db.InitialDirectory = "D:\\Windows Forms com C# - Menus, Outros Formulários e Validação com Login e Senha\\CursoWindowsForms\\Imagens";
            Db.Filter = "PNG|*.PNG";
            Db.Title = "Escolha a Imamgem";

            if (Db.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivoImamgem = Db.FileName;

                controleArquivoImagem++;
                Frm_ArquivoImagem_UC f = new Frm_ArquivoImagem_UC(nomeArquivoImamgem);
                f.Dock = DockStyle.Fill;
                TabPage tb = new TabPage();
                tb.Name = "Arquivo Imagem " + controleArquivoImagem;
                tb.Text = "Arquivo Imagem " + controleArquivoImagem;
                tb.ImageIndex = 6;
                tb.Controls.Add(f);
                Tbc_Aplicacoes.TabPages.Add(tb);
            }
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login f = new Frm_Login();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string login = f.login;
                string senha = f.senha;

                if (Cls_Uteis.ValidaSenhaLogin(senha) == true)
                {
                    novoToolStripMenuItem.Enabled = true;
                    apagarAbaToolStripMenuItem.Enabled = true;
                    abrirImagemToolStripMenuItem.Enabled = true;
                    desconectarToolStripMenuItem.Enabled = true;
                    conectarToolStripMenuItem.Enabled = false;
                    MessageBox.Show($"Bem vindo {login}!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Senha inválida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Questao f = new Frm_Questao("icons8_question_mark_96", "Você deseja se desconectar?");
            if (f.ShowDialog() == DialogResult.Yes)
            {
                if (Tbc_Aplicacoes.TabPages.Count > 0)
                {
                    foreach (TabPage tabPage in Tbc_Aplicacoes.TabPages)
                    {
                        Tbc_Aplicacoes.TabPages.Remove(tabPage);
                    }
                }
            
                novoToolStripMenuItem.Enabled = false;
                apagarAbaToolStripMenuItem.Enabled = false;
                abrirImagemToolStripMenuItem.Enabled = false;
                desconectarToolStripMenuItem.Enabled = false;
                conectarToolStripMenuItem.Enabled = true;
            }            
        }
    }
}
