using Senai.Cleveland.WebApi.Domains;
using Senai.Cleveland.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Cleveland.WebApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        public void Cadastrar(Especialidades especialidade)
        {
            using (ClevelandContext ctx = new ClevelandContext())
            {
                ctx.Especialidades.Add(especialidade);
                ctx.SaveChanges();
            }
        }

        public List<Especialidades> Listar()
        {
            using (ClevelandContext ctx = new ClevelandContext())
            {
                var lista = ctx.Especialidades.ToList();
                //foreach (var item in lista)
                //    item.Medicos = null;
                return lista;
            }
        }
    }
}
