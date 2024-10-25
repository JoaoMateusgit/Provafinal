using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoCSharp
{
    public class Convenio
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public int QtdEmpregados { get; set; }
        public StatusConvenio Status { get; set; }
        public DateTime DtAtuStatus { get; set; }
    }
}
