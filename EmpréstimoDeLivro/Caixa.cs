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
            if(contadorDeRevistasNaCaixa==0)
            {
                Console.WriteLine("Não existem revistas na caixa");
                return;
            }
            for (int i = 0; i < contadorDeRevistasNaCaixa; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("coleção da revista: " + revistasNaCaixa[i].colecao);
                Console.WriteLine("");
            }
            Console.ResetColor();
            Console.WriteLine("Pressione enter para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
