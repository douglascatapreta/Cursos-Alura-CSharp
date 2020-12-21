using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class FicharioDB
    {
        public string mensagem;
        public bool status;
        public string tabela;
        public LocalDBClass db;

        public FicharioDB(string tabela)
        {
            status = true;

            try
            {
                db = new LocalDBClass();
                this.tabela = tabela;
                mensagem = "Conexão com a tabela criada com sucesso.";
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com a Tabela com erro: " + ex.Message;
            }
        }

        public void Incluir(String id, string jsonUnit)
        {
            status = true;

            try
            {
                var SQL = $"INSERT INTO {this.tabela} (Id, Json) VALUES ('{id}', '{jsonUnit}')";
                db.SQLCommand(SQL);
                mensagem = "Inclusão efetuada com sucesso. Identificador: " + id;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
        }

        public string Buscar(string id)
        {
            status = true;

            try
            {
                var SQL = $"SELECT Id, Json FROM {this.tabela} WHERE Id = '{id}'";
                var dt = db.SQLQuery(SQL);
                
                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["Json"].ToString();
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existente: " + id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return "";
        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();

            try
            {
                var SQL = $"SELECT Id, Json FROM {this.tabela}";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["Json"].ToString();
                        List.Add(conteudo);
                    }
                    return List;
                }
                else
                {
                    status = false;
                    mensagem = "Não existem clientes na base de dados";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return List;
        }

        public void Apagar(string id)
        {
            status = true;

            try
            {
                var SQL = $"SELECT Id FROM {this.tabela} WHERE Id = '{id}'";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    SQL = $"DELETE FROM {this.tabela} WHERE Id = '{id}'";
                    db.SQLCommand(SQL);
                    mensagem = "Exclusão efetuada com sucesso. Identificador: " + id;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existente: " + id;
                }                
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
        }

        public void Alterar(string id, string jsonUnit)
        {
            status = true;

            try
            {
                var SQL = $"SELECT Id FROM {this.tabela} WHERE Id = '{id}'";
                var dt = db.SQLQuery(SQL);

                if (dt.Rows.Count > 0)
                {
                    SQL = $"UPDATE {this.tabela} SET Json = '{jsonUnit}' WHERE Id = '{id}'";
                    db.SQLCommand(SQL);
                    mensagem = "Alteração efetuada com sucesso. Identificador: " + id;
                }
                else
                {
                    status = false;
                    mensagem = "Alteração não permitida porque o identificador não existe: " + id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
        }
    }
}
