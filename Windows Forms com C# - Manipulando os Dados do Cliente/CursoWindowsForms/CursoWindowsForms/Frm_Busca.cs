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
    public partial class Frm_Busca : Form
    {
        List<List<string>> _listaBusca = new List<List<string>>();

        public string IdSelected { get; set; }

        public Frm_Busca(List<List<string>> listaBusca)
        {
            _listaBusca = listaBusca;
            InitializeComponent();
            this.Text = "Busca";
            Tls_Principal.Items[0].ToolTipText = "Salvar a seleção";
            Tls_Principal.Items[1].ToolTipText = "Fechar a seleção";

            PreencherLista();
            Lst_Busca.Sorted = true;
        }

        private void PreencherLista()
        {
            Lst_Busca.Items.Clear();

            foreach (var item in _listaBusca)
            {
                Lst_Busca.Items.Add(new ItemBox { Id = item[0], Nome = item[1] });
            }
        }

        private void apagarToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            IdSelected = ((ItemBox)Lst_Busca.Items[Lst_Busca.SelectedIndex]).Id;
            this.Close();
        }

        private class ItemBox
        {
            public string Id { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
                return this.Nome;
            }
        }
    }
}
