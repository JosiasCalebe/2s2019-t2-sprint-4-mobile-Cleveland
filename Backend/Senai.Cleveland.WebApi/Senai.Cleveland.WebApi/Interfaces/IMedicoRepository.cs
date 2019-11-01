using Senai.Cleveland.WebApi.Domains;
using Senai.Cleveland.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Cleveland.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medicos> Listar();

        List<MedicoViewModel> ListarMedicoViewModel();
    }
}
