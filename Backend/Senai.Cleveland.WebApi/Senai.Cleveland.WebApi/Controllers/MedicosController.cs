using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Cleveland.WebApi.Domains;
using Senai.Cleveland.WebApi.Interfaces;
using Senai.Cleveland.WebApi.Repositories;

namespace Senai.Cleveland.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository MedicoRepository { get; set; }

        public MedicosController()
        {
            MedicoRepository = new MedicoRepository();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Listar()
        {
            try
            {
                if (MedicoRepository.ListarMedicoViewModel() == null)
                    return NotFound(new { mensagem = "Médicos não encontradas!" });
                return Ok(MedicoRepository.ListarMedicoViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(Medicos medico)
        {
            try
            {
                MedicoRepository.Cadastrar(medico);
                return Ok(medico);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}