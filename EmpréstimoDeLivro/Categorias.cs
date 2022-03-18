using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoDeLivro
{
    internal class Categorias
    {
        public string nome;
        public int diasDeEmprestimo;
        public Revista qualrevista;
        public int contadorDeRevistasNaCategoria = 0;
        Revista[] revistasNaCategoria = new Revista[20];

        public void InserirRevistaNaCategoria(Revista registroDeRevista )
        {
            revistasNaCategoria[contadorDeRevistasNaCategoria] = registroDeRevista;
            contadorDeRevistasNaCategoria++;
             
        }
    }
}
