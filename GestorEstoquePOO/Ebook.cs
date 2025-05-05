using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoquePOO
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é Possivel dar entrada no estoque de um E-Book, pois é um produto Digital ");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine("Não é Possivel dar saida no estoque de um E-Book, pois é um produto Digital ");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"autor: {autor}");
            Console.WriteLine($"Preco: {preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("===========================");

        }
    }
}
