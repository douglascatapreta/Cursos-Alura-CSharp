using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.String;
using static System.DateTime;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;

namespace CSharp6.R10
{
    class Programa
    {
        public async void Main()
        {
            WriteLine("10. Inicializadores De Índice");

            StreamWriter logAplicacao = new StreamWriter("LogAplicacao.txt");

            try
            {
                await logAplicacao.WriteLineAsync("Aplicação está iniciando...");
                Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12))
                {
                    Endereco = "9303 Lyon Drive Hill Valley CA",
                    Telefone = "555-4385"
                };

                await logAplicacao.WriteLineAsync("Aluno Marty McFly foi criado...");

                WriteLine(aluno.Nome);
                WriteLine(aluno.Sobrenome);

                WriteLine(aluno.NomeCompleto);
                WriteLine("Idade: {0}", aluno.GetIdade());
                WriteLine(aluno.DadosPessoais);

                //aluno.AdicionarAvaliacao(new Avaliacao(1, "Geografia", 8));
                aluno.AdicionarAvaliacao(new Avaliacao(1, "GEO", 8));
                //aluno.AdicionarAvaliacao(new Avaliacao(1, "Matemática", 7));
                aluno.AdicionarAvaliacao(new Avaliacao(1, "MAT", 7));
                //aluno.AdicionarAvaliacao(new Avaliacao(1, "História", 9));
                aluno.AdicionarAvaliacao(new Avaliacao(1, "HIS", 9));
                ImprimirMelhorNota(aluno);

                foreach (var avaliacao in aluno.Avaliacoes)
                {
                    WriteLine(avaliacao.ToString());
                }

                Aluno aluno2 = null;
                ImprimirMelhorNota(aluno2);

                Aluno aluno3 = new Aluno("Bart", "Simpson");

                await logAplicacao.WriteLineAsync("Aluno Bart Simpson foi criado...");
                
                ImprimirMelhorNota(aluno3);

                aluno.PropertyChanged += Aluno_PropertyChanged;

                aluno.Endereco = "Rua Vergueiro, 3185";
                aluno.Telefone = "555-1234";

                Aluno aluno4 = new Aluno("Charlie Brown", "");
                
                await logAplicacao.WriteLineAsync("Aluno Charlie Brown foi criado...");
            }
            catch (ArgumentException exc) when (exc.Message.Contains("não informado"))
            {
                string msg = $"Parâmetro {exc.ParamName} não foi informado!";
                logAplicacao.WriteLine(msg);
                WriteLine(msg);
            }
            catch (ArgumentException)
            {
                const string msg = "Parâmetro com problema!";
                await logAplicacao.WriteLineAsync(msg);
                WriteLine(msg);
            }
            catch (Exception exc)
            {
                await logAplicacao.WriteLineAsync(exc.ToString());
                Write(exc.ToString());
            }
            finally
            {
                await logAplicacao.WriteLineAsync("Aplicação terminou.");
                logAplicacao.Dispose();
            }
        }

        private void Aluno_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WriteLine($"Propriedade {e.PropertyName} foi alterada!");
        }

        private static void ImprimirMelhorNota(Aluno aluno)
        {
            WriteLine("Melhor nota: {0}", aluno?.MelhorAvaliacao?.Nota);
        }
    }

    class Aluno : INotifyPropertyChanged
    {
        public string Nome { get; }

        public string Sobrenome { get; }

        private string endereco;

        public string Endereco
        {
            get { return endereco; }
            set 
            { 
                if (endereco != value)
                {
                    endereco = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DadosPessoais));
                }
            }
        }

        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set 
            { 
                if (telefone != value)
                {
                    telefone = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DadosPessoais));
                }                
            }
        }

        public string DadosPessoais => $"Nome: {NomeCompleto}, Endereco: {Endereco}, Telefone: {Telefone}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}";

        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

        public string NomeCompleto => Nome + " " + Sobrenome;

        public int GetIdade()
            => (int)(((Now - DataNascimento).TotalDays) / 365.242199);

        public Aluno(string nome, string sobrenome)
        {
            VerificarParametroPreenchido(nome, nameof(nome));
            VerificarParametroPreenchido(sobrenome, nameof(sobrenome));

            Nome = nome;
            Sobrenome = sobrenome;
        }

        private static void VerificarParametroPreenchido(string valorParamentro, string nomeParamentro)
        {
            if (IsNullOrEmpty(valorParamentro))
            {
                throw new ArgumentException("Parâmentro não informado!", nomeParamentro);
            }
        }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento) :
            this(nome, sobrenome)
        {
            this.DataNascimento = dataNascimento;
        }

        private IList<Avaliacao> avaliacoes = new List<Avaliacao>();

        public IReadOnlyCollection<Avaliacao> Avaliacoes
            => new ReadOnlyCollection<Avaliacao>(avaliacoes);

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            avaliacoes.Add(avaliacao);
        }

        public Avaliacao MelhorAvaliacao =>
            avaliacoes.OrderBy(a => a.Nota).LastOrDefault();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class Avaliacao
    {
        public int Bimestre { get; }
        public string CodigoMateria { get; }
        public double Nota { get; }

        //Dictionary<string, string> materias = new Dictionary<string, string>();
        Dictionary<string, string> materias = new Dictionary<string, string>()
        {
            ["MAT"] = "Matemática",
            ["LPL"] = "Língua Portuguesa",
            ["FIS"] = "Física",
            ["HIS"] = "História",
            ["GEO"] = "Geografia",
            ["QUI"] = "Química",
            ["BIO"] = "Biologia"
        };

        public Avaliacao(int bimestre, string codigoMateria, double nota)
        {
            Bimestre = bimestre;
            CodigoMateria = codigoMateria;
            Nota = nota;

            //materias.Add("MAT", "Matemática");
            //materias.Add("LPL", "Língua Portuguesa");
            //materias.Add("FIS", "Física");
            //materias.Add("HIS", "História");
            //materias.Add("GEO", "Geografia");
            //materias.Add("QUI", "Química");
            //materias.Add("BIO", "Biologia");
        }

        public override string ToString()
        {
            return $"Bimestre: {Bimestre}, Matéria: {materias[CodigoMateria]}, Nota: {Nota}";
        }
    }
}
