using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoCSharp
{
    public class Program
    {
        CadastroConvenio c = new CadastroConvenio();
        static void Main(string[] args)
        {
            montarMenu();
        }
        static void montarMenu()
        {
            Int16 opt = 0;
            while (opt != 5)
            {
                Console.Clear();
                Console.WriteLine("Cadastro de convênios para crédito consignado");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1.Adicionar convênio");
                Console.WriteLine("2.Remover convênio");
                Console.WriteLine("3.Listar convênios");
                Console.WriteLine("4.Salvar convênios");
                Console.WriteLine("5.Sair");
                Console.WriteLine("");
                Console.Write("Informe a opção desejada: ");
                String key = Console.ReadLine().Trim();
                Console.WriteLine("");

                try
                {
                    opt = Convert.ToInt16(key);
                }
                catch (Exception e)
                {
                    opt = 0;
                }

                if (opt >= 1 && opt <= 5)
                {
                    executarOpcao(opt);
                }
                else if (opt != 5)
                {
                    Console.WriteLine("Opção iválida!");
                    fimAcao();
                }
            }
        }
        static void executarOpcao(Int16 opt)
        {
            CadastroConvenio c = new CadastroConvenio();
            switch (opt)
            {
                case 1:
                    c.AdicionarConvenio("0", "0", "0", "0", "0");
                    Console.ReadLine();
                    break;
                case 2:
                    c.RemoverConvenio("0");
                    Console.ReadLine();
                    break;
                case 3:
                    c.ListarConvenios("0");
                    Console.ReadLine();
                    break;
                case 4:
                    c.SalvarConvenios();
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Finalizando o programa, tenha um bom dia!");
                    Console.ReadLine();
                    break;
            }
        }
        private static void fimAcao()
        {
            Console.WriteLine("");
            Console.WriteLine("<<Pressione Enter>>");
            Console.ReadKey();
        }
    }
}
