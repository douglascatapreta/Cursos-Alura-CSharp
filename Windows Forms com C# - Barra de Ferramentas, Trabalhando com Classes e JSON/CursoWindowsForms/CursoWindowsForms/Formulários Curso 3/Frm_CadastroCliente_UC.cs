using CursoWindowsFormsBiblioteca;
using CursoWindowsFormsBiblioteca.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace CursoWindowsForms
{
    public partial class Frm_CadastroCliente_UC : UserControl
    {
        public Frm_CadastroCliente_UC()
        {
            InitializeComponent();
            Grp_Codigo.Text = "Código";
            Grp_DadosPessoais.Text = "Dados Pessoais";
            Grp_Endereco.Text = "Endereço";
            Grp_Outros.Text = "Outros";
            Lbl_Bairro.Text = "Bairro";
            Lbl_CEP.Text = "CEP";
            Lbl_Complemento.Text = "Complemento";
            Lbl_CPF.Text = "CPF";
            Lbl_Estado.Text = "Estado";
            Lbl_Logradouro.Text = "Logradouro";
            Lbl_NomeCliente.Text = "Nome";
            Lbl_NomeMae.Text = "Nome da Mãe";
            Lbl_NomePai.Text = "Nome do Pai";
            Lbl_Profissao.Text = "Profissão";
            Lbl_RendaFamiliar.Text = "Renda Familiar";
            Lbl_Telefone.Text = "Telefone";
            Lbl_Cidade.Text = "Cidade";
            Chk_TemPai.Text = "Pai desconhecido";
            Rdb_Masculino.Text = "Masculino";
            Rdb_Feminino.Text = "Feminino";
            Rdb_Indefinido.Text = "Indefinido";
            Grp_Genero.Text = "Genero";

            Cmb_Estados.Items.Clear();
            Cmb_Estados.Items.Add("Acre (AC)");
            Cmb_Estados.Items.Add("Alagoas (AL)");
            Cmb_Estados.Items.Add("Amapá (AP)");
            Cmb_Estados.Items.Add("Amazonas (AM)");
            Cmb_Estados.Items.Add("Bahia (BA)");
            Cmb_Estados.Items.Add("Ceará (CE)");
            Cmb_Estados.Items.Add("Distrito Federal (DF)");
            Cmb_Estados.Items.Add("Espírito Santo (ES)");
            Cmb_Estados.Items.Add("Goiás (GO)");
            Cmb_Estados.Items.Add("Maranhão (MA)");
            Cmb_Estados.Items.Add("Mato Grosso (MT)");
            Cmb_Estados.Items.Add("Mato Grosso do Sul (MS)");
            Cmb_Estados.Items.Add("Minas Gerais (MG)");
            Cmb_Estados.Items.Add("Pará (PA)");
            Cmb_Estados.Items.Add("Paraíba (PB)");
            Cmb_Estados.Items.Add("Paraná (PR)");
            Cmb_Estados.Items.Add("Pernambuco (PE)");
            Cmb_Estados.Items.Add("Piauí (PI)");
            Cmb_Estados.Items.Add("Rio de Janeiro (RJ)");
            Cmb_Estados.Items.Add("Rio Grande do Norte (RN)");
            Cmb_Estados.Items.Add("Rio Grande do Sul (RS)");
            Cmb_Estados.Items.Add("Rondônia (RO)");
            Cmb_Estados.Items.Add("Roraima (RR)");
            Cmb_Estados.Items.Add("Santa Catarina (SC)");
            Cmb_Estados.Items.Add("São Paulo (SP)");
            Cmb_Estados.Items.Add("Sergipe (SE)");
            Cmb_Estados.Items.Add("Tocantins (TO)");

            Tls_Principal.Items[0].ToolTipText = "Inlcuir na base de dados um novo cliente";
            Tls_Principal.Items[1].ToolTipText = "Capturar um cliente já cadastrado na base";
            Tls_Principal.Items[2].ToolTipText = "Atualizar o cliente já existente";
            Tls_Principal.Items[3].ToolTipText = "Apagar o cliente selecionado";
            Tls_Principal.Items[4].ToolTipText = "Limpa dados da tela de entrada de dados";
        }

        private void Chk_TemPai_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_TemPai.Checked)
            {
                Txt_NomePai.Enabled = false;
            }
            else
            { 
                Txt_NomePai.Enabled = true;
            }
        }

        private void novoToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit c = LeituraFormulario();
                c.ValidaClasse();
                c.ValidaComplemento();
                MessageBox.Show("Classe foi inicializada sem erros.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Efetuei um clique sobre o botão ABRIR");
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Efetuei um clique sobre o botão SALVAR");
        }

        private void apagarToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Efetuei um clique sobre o botão EXCLUIR");
        }

        private void limparStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Efetuei um clique sobre o botão LIMPAR");
        }

        private Cliente.Unit LeituraFormulario()
        {
            return new Cliente.Unit
            {
                Id = Txt_Codigo.Text,
                Nome = Txt_NomeCliente.Text,
                NomeMae = Txt_NomeMae.Text,
                NomePai = Txt_NomePai.Text,
                NaoTemPai = Chk_TemPai.Checked,
                Genero = Rdb_Masculino.Checked ? 0 : Rdb_Feminino.Checked ? 1 : 2,
                CPF = Txt_CPF.Text,
                CEP = Txt_CEP.Text,
                Logradouro = Txt_Logradouro.Text,
                Complemento = Txt_Complemento.Text,
                Bairro = Txt_Bairro.Text,
                Cidade = Txt_Cidade.Text,
                Estado = Cmb_Estados.SelectedIndex < 0 ? "" : Cmb_Estados.Items[Cmb_Estados.SelectedIndex].ToString(),
                Telefone = Txt_Telefone.Text,
                Profissao = Txt_Profissao.Text,
                RendaFamiliar = Information.IsNumeric(Txt_RendaFamiliar.Text) ? Convert.ToDouble(Txt_RendaFamiliar.Text) < 0 ? 0 : Convert.ToDouble(Txt_RendaFamiliar.Text) : Double.NaN,
            };
        }

        private void Txt_CEP_Leave(object sender, EventArgs e)
        {
            string vCEP = Txt_CEP.Text;

            if (vCEP != "" && vCEP.Length == 8 && Information.IsNumeric(vCEP))
            {
                var vJson = Cls_Uteis.GeraJSONCEP(vCEP);
                var Cep = CEP.DeserializedClassUnit(vJson);
            
                Txt_Logradouro.Text = Cep.Logradouro;
                Txt_Bairro.Text = Cep.Bairro;
                Txt_Cidade.Text = Cep.Localidade;

                Cmb_Estados.SelectedIndex = -1;
                for (int i = 0; i < Cmb_Estados.Items.Count - 1; i++)
                {
                    if (Strings.InStr(Cmb_Estados.Items[i].ToString(), $"({Cep.UF})") > 0)
                    {
                        Cmb_Estados.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
    }
}
