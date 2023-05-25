using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Console_MVC.Model;

namespace Console_MVC.View
{
    public class ProdutoView
    {
        //metodo para exibir os dados da lista no console
        public void Listar(List<Produto> produto)
        {
            foreach (var item in produto)
            {
                Console.WriteLine($"Código: {item.Codigo}");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Preço: {item.Preco}");
                
            }
        }

         public Produto Cadastrar()
         {
            Produto novoProduto = new Produto();

            Console.WriteLine($"Informe o codigo");
            novoProduto.Codigo = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Informe o nome");
            novoProduto.Nome = Console.ReadLine();
            
            Console.WriteLine($"Informe o preço");
            novoProduto.Preco = float.Parse(Console.ReadLine()!);
            
            return novoProduto;
         }
    }
}