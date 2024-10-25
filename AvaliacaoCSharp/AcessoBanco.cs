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
        public void Save(Convenio chaves)
        {
            try
            {
                acesso.Abrir();
                string sql = "INSERT INTO CONVENIO (CNPJ, RAZAO_SOCIAL, QTD_EMPREGADOS,STATUS,DT_ATU_STATUS) VALUES (@Cnpj, @RazaoSocial,@qtd_empregados,@Status,@Dt_Atu_status)";

                //Passando parâmetros de forma segura
                SqlCommand command = new SqlCommand(sql);

                var Cnpj = new SqlParameter("@Cnpj", System.Data.DbType.String);
                Cnpj.Value = chaves.Cnpj;
                var Razaosocial = new SqlParameter("@RazaoSocial", System.Data.DbType.String);
                Razaosocial.Value = chaves.RazaoSocial;
                var qtd_Empregados = new SqlParameter("@qtd_empregados", System.Data.DbType.String);
                qtd_Empregados.Value = chaves.QtdEmpregados;
                var Status = new SqlParameter("@Status", System.Data.DbType.String);
                Status.Value = chaves.Status;
                var Dt_Atu_status = new SqlParameter("@Dt_Atu_status", System.Data.DbType.String);
                Dt_Atu_status.Value = chaves.DtAtuStatus;

                command.Parameters.Add(Cnpj);
                command.Parameters.Add(Razaosocial);
                command.Parameters.Add(qtd_Empregados);
                command.Parameters.Add(Status);
                command.Parameters.Add(Dt_Atu_status);



                acesso.ExecutarInsert(command.GetGeneratedQuery());
                acesso.EfetivarComandos();
                acesso.Dispose();
            }
            catch(Exception e)
            {
                new Retorno(false,41, "41 - Erro ao interagir com o banco de dados...");
            }
        }

        }
    }
