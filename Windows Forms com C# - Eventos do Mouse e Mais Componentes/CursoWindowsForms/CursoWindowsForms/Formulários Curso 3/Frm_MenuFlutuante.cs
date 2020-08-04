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
    public partial class Frm_MenuFlutuante : Form
    {
        public Frm_MenuFlutuante()
        {
            InitializeComponent();
        }

        private void Frm_MenuFlutuante_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //var posicaoX = e.X;
                //var posicaoY = e.Y;
                //MessageBox.Show($"Clique com o botão direito do mouse. A posição relativa foi ({posicaoX}, {posicaoY})");

                var contextMenu = new ContextMenuStrip();
                ToolStripMenuItem toolStrip001 = DesenhaItemMenu("Item do menu 1", "key");
                ToolStripMenuItem toolStrip002 = DesenhaItemMenu("Item do menu 2", "Frm_ValidaSenha");
                toolStrip001.Click += new EventHandler(toolStrip001_Click);
                toolStrip002.Click += new EventHandler(toolStrip002_Click);
                contextMenu.Items.Add(toolStrip001);
                contextMenu.Items.Add(toolStrip002);
                contextMenu.Show(this, new Point(e.X, e.Y));
            }
        }

        void toolStrip001_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item 1 foi clicado.");
        }

        void toolStrip002_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Item 2 foi clicado.");
        }

        private ToolStripMenuItem DesenhaItemMenu(string text, string nomeImagem)
        {
            var vToolTip = new ToolStripMenuItem();
            vToolTip.Text = text;
            vToolTip.Image = (Image)global::CursoWindowsForms.Properties.Resources.ResourceManager.GetObject(nomeImagem);
            return vToolTip;
        }
    }
}

