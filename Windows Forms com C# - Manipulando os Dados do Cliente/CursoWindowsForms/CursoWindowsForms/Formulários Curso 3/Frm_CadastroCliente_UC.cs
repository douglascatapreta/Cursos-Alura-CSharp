using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursoWindowsFormsBiblioteca.Classes;
using CursoWindowsFormsBiblioteca.Databases;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using CursoWindowsFormsBiblioteca;

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

            Tls_Principal.Items[0].ToolTipText = "Incluir na base de dados um novo cliente";
            Tls_Principal.Items[1].ToolTipText = "Capturar um cliente já cadastrado na base";
            Tls_Principal.Items[2].ToolTipText = "Atualize o cliente já existente";
            Tls_Principal.Items[3].ToolTipText = "Apaga o cliente selecionado";
            Tls_Principal.Items[4].ToolTipText = "Limpa dados da tela de entrada de dados";

            Btn_Busca.Text = "Buscar";

            LimparFormulario();
        }

        private void LimparFormulario()
        {
            Txt_Codigo.Text = "";
            Txt_NomeCliente.Text = "";
            Txt_NomeMae.Text = "";
            Txt_CPF.Text = "";
            Txt_NomePai.Text = "";
            Chk_TemPai.Checked = false;
            Rdb_Masculino.Checked = true;
            Txt_CEP.Text = "";
            Txt_Logradouro.Text = "";
            Txt_Complemento.Text = "";
            Txt_Bairro.Text = "";
            Txt_Cidade.Text = "";
            Cmb_Estados.SelectedIndex = -1;
            Txt_Telefone.Text = "";
            Txt_Profissao.Text = "";
            Txt_RendaFamiliar.Text = "";
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

        private Cliente.Unit LeituraFormulario()
        {
            Cliente.Unit C = new Cliente.Unit();
            C.Id = Txt_Codigo.Text;
            C.Nome = Txt_NomeCliente.Text;
            C.NomeMae = Txt_NomeMae.Text;
            C.NomePai = Txt_NomePai.Text;
            if (Chk_TemPai.Checked)
            {
                C.NaoTemPai = true;
            }
            else
            {
                C.NaoTemPai = false;
            }
            if (Rdb_Masculino.Checked)
            {
                C.Genero = 0;
            }
            if (Rdb_Feminino.Checked)
            {
                C.Genero = 1;
            }
            if (Rdb_Indefinido.Checked)
            {
                C.Genero = 2;
            }
            C.Cpf = Txt_CPF.Text;

            C.Cep = Txt_CEP.Text;
            C.Logradouro = Txt_Logradouro.Text;
            C.Complemento = Txt_Complemento.Text;
            C.Cidade = Txt_Cidade.Text;
            C.Bairro = Txt_Bairro.Text;

            if (Cmb_Estados.SelectedIndex < 0)
            {
                C.Estado = "";
            }
            else
            {
                C.Estado = Cmb_Estados.Items[Cmb_Estados.SelectedIndex].ToString();
            }

            C.Telefone = Txt_Telefone.Text;
            C.Profissao = Txt_Profissao.Text;

            if (Information.IsNumeric(Txt_RendaFamiliar.Text))
            {
                Double vRenda = Convert.ToDouble(Txt_RendaFamiliar.Text);
                if (vRenda < 0)
                {
                    C.RendaFamiliar = 0;
                }
                else
                {
                    C.RendaFamiliar = vRenda;
                }
            }

            return C;
        }

        private void EscreveFormulario(Cliente.Unit cliente)
        {
            Txt_Codigo.Text = cliente.Id;
            Txt_NomeCliente.Text = cliente.Nome;
            Txt_NomeMae.Text = cliente.NomeMae;
            Txt_NomePai.Text = cliente.NomePai;
            Chk_TemPai.Checked = cliente.NaoTemPai;
            Rdb_Masculino.Checked = cliente.Genero == 0;
            Rdb_Feminino.Checked = cliente.Genero == 1;
            Rdb_Indefinido.Checked = cliente.Genero == 2;
            Txt_CPF.Text = cliente.Cpf;
            Txt_CEP.Text = cliente.Cep;
            Txt_Logradouro.Text = cliente.Logradouro;
            Txt_Complemento.Text = cliente.Complemento;
            Txt_Cidade.Text = cliente.Cidade;
            Txt_Bairro.Text = cliente.Bairro;
            Txt_Telefone.Text = cliente.Telefone;
            Txt_Profissao.Text = cliente.Profissao;
            Cmb_Estados.SelectedIndex = Cmb_Estados.Items.IndexOf(cliente.Estado);
            Txt_RendaFamiliar.Text = cliente.RendaFamiliar.ToString();
        }

        private void novoToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit C = new Cliente.Unit();
                C = LeituraFormulario();
                C.ValidaClasse();
                C.ValidaComplemento();
                C.IncluirFichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                MessageBox.Show($"OK: Identificador incluido com sucesso.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //string clienteJson = Cliente.SerializeClassUnit(C);
                //Fichario f = new Fichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                //if (f.Status)
                //{
                //    f.Incluir(C.Id, clienteJson);

                //    if (f.Status)
                //    {
                //        MessageBox.Show($"OK: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (ValidationException Ex)
            {
                MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            string codigoCliente = Txt_Codigo.Text;

            if (codigoCliente == "")
            {
                MessageBox.Show("Código do Cliente vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Cliente.Unit cliente = new Cliente.Unit();
                    cliente = cliente.BuscarFichario(codigoCliente, "D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                    EscreveFormulario(cliente);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Fichario f = new Fichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                //if (f.Status)
                //{
                //    string clienteJson = f.Buscar(codigoCliente);
                //    if (f.Status)
                //    {
                //        Cliente.Unit cliente = Cliente.DeserializeClassUnit(clienteJson);
                //        EscreveFormulario(cliente);
                //    }
                //    else
                //    {
                //        MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            string codigoCliente = Txt_Codigo.Text;

            if (codigoCliente == "")
            {
                MessageBox.Show("Código do Cliente vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Cliente.Unit C = new Cliente.Unit();
                    C = LeituraFormulario();
                    C.ValidaClasse();
                    C.ValidaComplemento();
                    C.AlterarFichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                    MessageBox.Show($"OK: Identificador alterado com sucesso.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //string clienteJson = Cliente.SerializeClassUnit(C);
                    //Fichario f = new Fichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                    //if (f.Status)
                    //{
                    //    f.Alterar(C.Id, clienteJson);

                    //    if (f.Status)
                    //    {
                    //        MessageBox.Show($"OK: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                catch (ValidationException Ex)
                {
                    MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ApagatoolStripButton_Click(object sender, EventArgs e)
        {
            string codigoCliente = Txt_Codigo.Text;

            if (codigoCliente == "")
            {
                MessageBox.Show("Código do Cliente vazio.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Cliente.Unit cliente = new Cliente.Unit();
                    cliente = cliente.BuscarFichario(codigoCliente, "D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");

                    if (cliente == null)
                    {
                        MessageBox.Show("Identificador não encontrado.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        EscreveFormulario(cliente);
                        Frm_Questao db = new Frm_Questao("icons8-question-mark-96", "Excluir o cliente?");
                        if (db.ShowDialog() == DialogResult.Yes)
                        {
                            try
                            {
                                cliente.ApagarFichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                                LimparFormulario();
                                MessageBox.Show($"OK: Identificador apagado com sucesso.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Fichario f = new Fichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                //if (f.Status)
                //{
                //    string clienteJson = f.Buscar(codigoCliente);
                //    if (f.Status)
                //    {
                //        Cliente.Unit cliente = Cliente.DeserializeClassUnit(clienteJson);
                //        EscreveFormulario(cliente);

                //        Frm_Questao db = new Frm_Questao("icons8-question-mark-96", "Excluir o cliente?");
                //        if (db.ShowDialog() == DialogResult.Yes)
                //        {
                //            f.Apagar(codigoCliente);

                //            if (f.Status)
                //            {
                //                LimparFormulario();
                //                MessageBox.Show($"OK: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            }
                //            else
                //            {
                //                MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }                    
                //}
                //else
                //{
                //    MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void LimpartoolStripButton_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void Txt_CEP_Leave(object sender, EventArgs e)
        {
            string vCep = Txt_CEP.Text;
            if (vCep != "")
            {
                if (vCep.Length == 8)
                {
                    if (Information.IsNumeric(vCep))
                    {
                        var vJson = Cls_Uteis.GeraJSONCEP(vCep);
                        Cep.Unit CEP = new Cep.Unit();
                        CEP = Cep.DesSerializedClassUnit(vJson);
                        Txt_Logradouro.Text = CEP.logradouro;
                        Txt_Bairro.Text = CEP.bairro;
                        Txt_Cidade.Text = CEP.localidade;

                        Cmb_Estados.SelectedIndex = -1;
                        for (int i = 0; i <= Cmb_Estados.Items.Count - 1; i++)
                        {
                            var vPos = Strings.InStr(Cmb_Estados.Items[i].ToString(), "(" + CEP.uf + ")");
                            if (vPos > 0)
                            {
                                Cmb_Estados.SelectedIndex = i;
                            }
                        }
                    }
                }
            }
        }

        private void Btn_Busca_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.Unit cliente = new Cliente.Unit();
                List<string> lista = cliente.ListaFichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");

                if (lista.Count == 0)
                {
                    MessageBox.Show("Base de dados vazia. Nenhum identificador cadastrado.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    List<List<string>> ListaBusca = new List<List<string>>();
                    foreach (var item in lista)
                    {
                        cliente = Cliente.DeserializeClassUnit(item);
                        ListaBusca.Add(new List<string> { cliente.Id, cliente.Nome });
                    }

                    Frm_Busca form = new Frm_Busca(ListaBusca);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        cliente = cliente.BuscarFichario(form.IdSelected, "D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
                        if (cliente == null)
                        {
                            MessageBox.Show("Identificador não encontrado.", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        { 
                            EscreveFormulario(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Fichario f = new Fichario("D:\\Windows Forms com C# - Manipulando os Dados do Cliente\\CursoWindowsForms\\Fichario");
            //if (f.Status)
            //{
            //    List<string> lista = f.BuscarTodos();
            //    if (f.Status)
            //    {
            //        List<List<string>> ListaBusca = new List<List<string>>();

            //        foreach (var item in lista)
            //        {
            //            Cliente.Unit cliente = Cliente.DeserializeClassUnit(item);
            //            ListaBusca.Add(new List<string> { cliente.Id, cliente.Nome });
            //        }

            //        Frm_Busca form = new Frm_Busca(ListaBusca);
            //        if (form.ShowDialog() == DialogResult.OK)
            //        {
            //            string clienteJson = f.Buscar(form.IdSelected);
            //            if (f.Status)
            //            {
            //                Cliente.Unit cliente = Cliente.DeserializeClassUnit(clienteJson);
            //                EscreveFormulario(cliente);
            //            }
            //            else
            //            {
            //                MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show($"ERR: {f.Mensagem}", "ByteBank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
