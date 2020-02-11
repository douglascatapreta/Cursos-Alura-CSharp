using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class ClasseTeste
    {
        public ClasseTeste()
        {
            ModificadoresTeste teste = new ModificadoresTeste();

            teste.MetodoPublico();
            // teste.MetodoProtegido();
            teste.MetodoInterno();
        }
    }

    class ClasseDerivada : ModificadoresTeste
    {
        public ClasseDerivada()
        {
            MetodoProtegido();
        }
    }

    public class ModificadoresTeste
    {
        public void MetodoPublico()
        {
            // Visível fora da classe "ModificadoresTeste"
        }

        private void MetodoPrivate()
        {
            // Visível apenas na classe "ModificadoresTeste"
        }

        protected void MetodoProtegido()
        {
            // Visível apenas na classe "ModificadoresTeste" e derivadas
        }

        internal void MetodoInterno()
        {
            // Visível apenas para o projeto "ByteBank.Modelos"
        }
    }
}
