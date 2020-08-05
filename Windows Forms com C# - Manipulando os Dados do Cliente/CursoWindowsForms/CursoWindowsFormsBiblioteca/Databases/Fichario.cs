using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class Fichario
    {
        public string Diretorio { get; set; }
        public string Mensagem { get; set; }
        public bool Status { get; set; }

        public Fichario (string diretorio)
        {
            Status = true;

            try
            {
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }
                
                Diretorio = diretorio;
                Mensagem = "Conexão com o fichário criada com sucesso.";
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = $"Conexão com o ficheiro com erro: {ex.Message}";
            }
        }

        public void Incluir(string id, string jsonUnit)
        {
            Status = true;
            string path = $"{Diretorio}\\{id}.json";

            try
            {
                if (File.Exists(path))
                {
                    Status = false;
                    Mensagem = $"Inclusão não permitida porque o identificador já existe: {id}";
                }
                else
                {
                    File.WriteAllText(path, jsonUnit);
                    Mensagem = $"Inclusão efetuada com sucesso. Identificador: {id}";
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = $"Conexão com o ficheiro com erro: {ex.Message}";
            }
        }

        public string Buscar(string id)
        {
            Status = true;
            string path = $"{Diretorio}\\{id}.json";

            try
            {
                if (!File.Exists(path))
                {
                    Status = false;
                    Mensagem = $"Identificador não existente: {id}";
                }
                else
                {
                    string conteudo = File.ReadAllText(path);
                    return conteudo;
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = $"Conexão com o ficheiro com erro: {ex.Message}";
            }
            return "";
        }

        public List<string> BuscarTodos()
        {
            Status = true;
            List<string> lista = new List<string>();

            try
            {
                string[] arquivos = Directory.GetFiles(Diretorio, "*.json");

                foreach (var arquivo in arquivos)
                {
                    string conteudo = File.ReadAllText(arquivo);
                    lista.Add(conteudo);
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = $"Conexão com o ficheiro com erro: {ex.Message}";
            }
            
            return lista;
        }

        public void Apagar(string id)
        {
            Status = true;
            string path = $"{Diretorio}\\{id}.json";

            try
            {
                if (!File.Exists(path))
                {
                    Status = false;
                    Mensagem = $"Identificador não existente: {id}";
                }
                else
                {
                    File.Delete(path);
                    Mensagem = $"Exclusão efetuada com sucesso. Identificador: {id}";
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = $"Conexão com o ficheiro com erro: {ex.Message}";
            }
        }

        public void Alterar(string id, string jsonUnit)
        {
            Status = true;
            string path = $"{Diretorio}\\{id}.json";

            try
            {
                if (!File.Exists(path))
                {
                    Status = false;
                    Mensagem = $"Alteração não permitida porque o identificador não existe: {id}";
                }
                else
                {
                    File.Delete(path);
                    File.WriteAllText(path, jsonUnit);
                    Mensagem = $"Alteração efetuada com sucesso. Identificador: {id}";
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = $"Conexão com o ficheiro com erro: {ex.Message}";
            }
        }
    }
}
