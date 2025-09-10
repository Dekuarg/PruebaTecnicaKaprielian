using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaKaprielian.Dtos;
using PruebaTecnicaKaprielian.Extensions;
using PruebaTecnicaKaprielian.Helpers;
using PruebaTecnicaKaprielian.Interfaces;
using PruebaTecnicaKaprielian.Repositories;
using PruebaTecnicaKaprielian.Validations;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaKaprielian.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        protected IUnitOfWork _unitOfWork;
        public ClientesController( IUnitOfWork unitOfWork, ILogger<ClientesController> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await ClientesHelper.GetAll(_unitOfWork));
        }

        [HttpGet("{id}/GetById")]
        public async Task<ActionResult> GetById([Required] int id)
        {
            if (id == 0)
                return BadRequest("ID es requerido");

            return Ok(await ClientesHelper.Get(_unitOfWork,id));

        }


        [HttpGet("{name}/GetByName")]
        public async Task<ActionResult> GetByName([Required]string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Ingrese un valor");

            return Ok(await ClientesHelper.GetByName(_unitOfWork,name));

        }

        [HttpPost]
        public async Task<ActionResult> Create(ClientesDto data)
        {
            ClientesValidations validator = new();

            validator.ValidateAndThrow(data);

            return Ok(await ClientesHelper.Create(_unitOfWork, data));

        }

        [HttpPut]
        public async Task<ActionResult> Update( ClienteUpdateDto data)
        {
            ClientUpdateValidation validator = new();

            validator.ValidateAndThrow(data);

            return Ok(await ClientesHelper.Update(_unitOfWork, data));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest("ID es requerido");

            return Ok(await ClientesHelper.Delete(_unitOfWork, id));

        }
    }
}
