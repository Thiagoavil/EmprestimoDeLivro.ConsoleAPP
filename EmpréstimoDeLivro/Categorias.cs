﻿using System;
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

        public void MostrarRevistasNaCategoria()
        {
            for(int i = 0;i<contadorDeRevistasNaCategoria; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("coleção da revista: " + revistasNaCategoria[i].colecao);
                Console.WriteLine("");
            }
            Console.ResetColor();
            Console.WriteLine("Pressione enter para continuar");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
