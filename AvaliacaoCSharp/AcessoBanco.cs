using Bergs.ProvacSharp.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoCSharp
{
    public class AcessoBanco
    {
        static string connection = "c:\\soft\\pxc\\data\\Pxcz02da.mdb";

        AcessoBancoDados acesso = new AcessoBancoDados(connection);

        cesso.abrir
        static string sql = "INSERT INTO CONVENIO (CNPJ, RAZAO_SOCIAL, QTD_EMPREGADOS,STATUS,DT_ATU_STATUS) VALUES (@Cnpj, @RazaoSocial,@qtd_empregados,@Status,@Dt_Atu_status)";

        // Passando parâmetros de forma segura
        SqlCommand command = new SqlCommand(sql);

        
        //    command.Parameters.Add(tipochave);
        //    command.Parameters.Add(NomeTitular);
        //    command.Parameters.Add(qtde_pix);
        //    command.Parameters.Add(valor_total_pix);
        //    command.Parameters.Add(chave);

        //    acesso.
        //    acesso.ExecutarInsert(command.GetGeneratedQuery());
        //    acesso.EfetivarComandos();

    }
}
