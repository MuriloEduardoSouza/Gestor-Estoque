using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoquePOO
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar Vagas no curso {nome} ");
            Console.WriteLine("Digite a quantidade que voce quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas = vagas + entrada;

            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Remover vagas do curso {nome} ");
            Console.WriteLine("Digite a quantidade que voce quer dar Saida: ");
            int saida = int.Parse(Console.ReadLine());
            vagas = vagas - saida;

            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"autor: {autor}");
            Console.WriteLine($"Preco: {preco}");
            Console.WriteLine($"Vagas Restantes: {vagas}");
            Console.WriteLine("===========================");
            
        }
    }
}
