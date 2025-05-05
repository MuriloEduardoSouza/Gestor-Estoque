using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoquePOO
{
    [System.Serializable]
        class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no Estoque do produto {nome} ");
            Console.WriteLine("Digite a quantidade que voce quer dar entrada: ");
            int entrada =int.Parse(Console.ReadLine());
            estoque = estoque + entrada;

            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar Saida no Estoque do produto {nome} ");
            Console.WriteLine("Digite a quantidade que voce quer dar Saida: ");
            int saida = int.Parse(Console.ReadLine());
            estoque = estoque - saida;

            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preco: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("===========================");

        }
    }
}
