using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Cleveland.WebApi.ViewModels
{
    public class MedicoViewModel
    {
        public int IdMedico { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int Crm { get; set; }
        public string Especialidade { get; set; }
        public bool Ativo { get; set; }

    }
}
