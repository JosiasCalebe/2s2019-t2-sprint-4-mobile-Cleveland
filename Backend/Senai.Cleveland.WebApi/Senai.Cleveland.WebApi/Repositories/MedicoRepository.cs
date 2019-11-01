using Microsoft.EntityFrameworkCore;
using Senai.Cleveland.WebApi.Domains;
using Senai.Cleveland.WebApi.Interfaces;
using Senai.Cleveland.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Cleveland.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private string Conexao = "Data Source=.\\SqlExpress; initial catalog=M_Cleveland; User Id=sa;Pwd=132";

        public List<Medicos> Listar()
        {
            using (ClevelandContext ctx = new ClevelandContext())
            {
                return ctx.Medicos.Include(x => x.IdEspecialidadeNavigation).ToList();
            }
        }

        public List<MedicoViewModel> ListarMedicoViewModel()
        {
            List<MedicoViewModel> medicos = new List<MedicoViewModel>();
            string Query = "SELECT * FROM vmMedicosEspecialidades";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        MedicoViewModel medico = new MedicoViewModel
                        {
                            IdMedico = Convert.ToInt32(sdr["IdMedico"]),
                            Nome = sdr["Nome"].ToString(),
                            Especialidade = sdr["Especialidade"].ToString(),
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            DataDeNascimento = Convert.ToDateTime(sdr["DataDeNascimento"]),
                            Crm = Convert.ToInt32(sdr["Crm"])
                        };

                        medicos.Add(medico);
                    }
                }
            }
            return medicos;
        }

    }
}
