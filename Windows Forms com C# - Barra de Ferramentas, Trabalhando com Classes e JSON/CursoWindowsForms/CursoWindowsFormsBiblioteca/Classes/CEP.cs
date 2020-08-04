using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Classes
{
    public class CEP
    {
        public class Unit
        {
            public string CEP { get; set; }
            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            public string UF { get; set; }
            public string Unidade { get; set; }
            public string IBGE { get; set; }
            public string GIA { get; set; }
        }

        public static Unit DeserializedClassUnit(string vJson)
        {
            return JsonConvert.DeserializeObject<Unit>(vJson);
        }
    }
}
