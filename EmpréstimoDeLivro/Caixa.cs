using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoDeLivro
{
    internal class Caixa
    {

        public string cor;
        public string etiquieta;
        public int numero;
        public int contadorDeRevistasNaCaixa = 0;
        Revista[] revistasNaCaixa = new Revista[10];


        public void InserirRevistaNaCaixa(Revista registroDeRevista)
        {
            revistasNaCaixa[contadorDeRevistasNaCaixa] = registroDeRevista;
            contadorDeRevistasNaCaixa++;

        }

        public void MostrarRevistasNaCaixa()
        {
            for (int i = 0; i < contadorDeRevistasNaCaixa; i++)
            {
                Console.WriteLine("coleção da revista: " + revistasNaCaixa[i].colecao);
            }
        }
    }
}
