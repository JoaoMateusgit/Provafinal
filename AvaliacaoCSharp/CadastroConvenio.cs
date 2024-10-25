using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoCSharp
{
    public class CadastroConvenio
    {
        private string caminhoBancoDados { get; set; }
        private List<Convenio> listaConvenios = new List<Convenio>();

        Validações validar = new Validações();
        Convenio convenio = new Convenio();

        public CadastroConvenio(string caminhoBancoDados)
        {
            //Construtor
        }

        public CadastroConvenio()
        {
        }
        #region Adicionar Convênio
        public void AdicionarConvenio(string cnpj, string razaoSocial, string qtdEmpregados, string status, string dtAtuStatus)
        {
            Console.Write("Digite o CNPJ: ");
            cnpj = Console.ReadLine();
            ValidarCnpjJaCadastrado(cnpj);
            ValidarCnpjFormatoInválido(cnpj);
            Console.WriteLine("Digite a Razão Social: ");
            razaoSocial = Console.ReadLine();
            ValidarRazaoSocialTresCaracteres(razaoSocial);
            Console.WriteLine("Digite a Quantidade de empregados: ");
            qtdEmpregados = Console.ReadLine();
            ValidarEmpregadosMaiorQueZero(qtdEmpregados);
            Console.WriteLine("Digite o Status: ");
            status = Console.ReadLine();
            Console.WriteLine("Digite data de atualização do status: ");
            dtAtuStatus = Console.ReadLine();
            ValidarDataAtualizacao(dtAtuStatus);
            ValidarDataFutura(dtAtuStatus);
        }
        #endregion

        #region Remover Convênio
        public void RemoverConvenio(string cnpj)
        {
            Console.Write("Digite o CNPJ a ser removido: ");
            cnpj = Console.ReadLine();
            ValidarCnpjFormatoInválido(cnpj);
        }
        #endregion

        #region Listar Convenios
        public void ListarConvenios(string chave)
        {
            foreach (var item in listaConvenios)
            {
                if (listaConvenios != null)
                {
                    Console.Clear();
                    Console.WriteLine($"CNPJ: {item.Cnpj}\n" +
                        $"Razão Social: {item.RazaoSocial}\n" +
                        $"quantidade de empregados: {item.QtdEmpregados}\n" +
                        $"Status: {item.Status}\n" +
                        $"Data da Atualização: {item.DtAtuStatus}");
                    Console.WriteLine(new Retorno(true, 0, "Sucesso."));
                }
                else
                {
                    Console.WriteLine(new Retorno(false, 30, "30 - Não há dados para ser Exibido!"));
                }
            }
        }
        #endregion
        public void SalvarConvenios()
        {
            //Falta Implementar
        }

        //Validar se o CNPJ é válido através da expressão regular “^[1-9]\\d{2,13}$” (código 10);
        public Retorno ValidarCnpjFormatoInválido(string chave)
        {
            String regex = "^[1-9]\\d{2,13}$";
            if (System.Text.RegularExpressions.Regex.IsMatch(chave, regex))
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else
            {
                return new Retorno(false, 10, "10 - Cnpj inválido.");
            }
        }

        //Validar se o CNPJ já Existe (código 11);
        public Retorno ValidarCnpjJaCadastrado(string chave)
        {
            if (chave != convenio.Cnpj)
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else
            {
                return new Retorno(false, 10, "11 - Cnpj já existe na lista!.");
            }

        }

        //Validar se a razão social possui pelo menos 3 caracteres (código 12);
        public Retorno ValidarRazaoSocialTresCaracteres(string chave)
        {
            int qtd = 3;
            if (chave.Length > qtd)
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else
            {
                return new Retorno(false, 12, "12 - A razão Social deve ter 3 ou mais carcteres");
                throw new Exception("12 - A razão Social deve ter 3 ou mais carcteres");
            }
        }
        //Validar se a quantidade de empregados é do tipo inteiro (código 13);
        public Retorno ValidarTipoInteiro(string chave)
        {
            int qtd = 0;
            bool canConvert = int.TryParse(chave, out qtd);
            if (canConvert == true)
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else
            {
                return new Retorno(false, 13, "13 - O valor deve ser numerico");
            }
        }
        //Validar se a quantidade de empregados é mairo que zero (código 14);
        public Retorno ValidarEmpregadosMaiorQueZero(string chave)
        {
            int qtd = 0;
            if (Convert.ToInt32(chave) > qtd)
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else
            {
                return new Retorno(false, 14, "14 - O numero de empregados deve ser maior que zero!");
            }
        }

        //Validar se o status é inválido(código 15);
        //public Retorno validarStatus(string chave)
        //{
        //    StatusConvenio status = new StatusConvenio();
        //       if ()
        //    {
        //        return new Retorno(true, 0, "Sucesso.");
        //    }
        //    else
        //    {
        //        return new Retorno(false, 40, "40 - CPF inválido.");
        //    }
        //}

        //Validar se a data de atualização é valida(código 16);
        public Retorno ValidarDataAtualizacao(string chave)
        {
            string regex = (@"(\d{2}\/\d{2}\/\d{4})");
            if (convenio.DtAtuStatus.ToString() == regex)
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else
            {
                return new Retorno(false, 16, "16 -A data tem que estar no formato dd/mm/yyyy!");
            }
        }

        //Validar se a data de atualização é uma data futura(código 17);
        public Retorno ValidarDataFutura(string chave)
        {
            convenio.DtAtuStatus = DateTime.Now;
            if (convenio.DtAtuStatus.ToString() != chave)
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else
            {
                return new Retorno(false, 17, "17 - A data não pode ser futura!");
            }
        }

        //Validar se o CNPJ já está na lista para remover(código 20);
        public Retorno ValidarCnpjNaListaParaRemover(string chave)
        {
            String regex = "^[1-9]\\d{2,13}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(chave, regex))
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else if (chave == convenio.Cnpj)
            {
                return new Retorno(true, 0, "Sucesso.");
            }
            else
            {
                return new Retorno(false, 20, "20 - CNPJ Não encontrado! ");
            }
        }
    }
}

