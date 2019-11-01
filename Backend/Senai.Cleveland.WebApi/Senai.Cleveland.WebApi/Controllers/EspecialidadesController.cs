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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadeRepository EspecialidadeRepository { get; set; }
        public EspecialidadesController()
        {
            EspecialidadeRepository = new EspecialidadeRepository();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Listar()
        {
            try
            {
                if(EspecialidadeRepository.Listar() == null) return NotFound();
                return Ok(EspecialidadeRepository.Listar());

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(Especialidades especialidade)
        {
            try
            {
                EspecialidadeRepository.Cadastrar(especialidade);
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}