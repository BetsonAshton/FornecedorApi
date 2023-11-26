using FornecedorApi.Application.Interfaces;
using FornecedorApi.Application.Models.Requests.Fornecedor;
using FornecedorApi.Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FornecedorApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorAppService _fornecedorAppService;

        public FornecedorController(IFornecedorAppService fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        [HttpPost]
        public IActionResult Post(FornecedorCreateRquest request)
        {
            return StatusCode(201, new
            {
                mensagem = "Fornecedor cadastrado com sucesso.",
                fornecedor = _fornecedorAppService.Create(request)
            });
        }

        [HttpPut]
        public IActionResult Put(FornecedorUpdateRequest request)
        {
            return StatusCode(200, new
            {
                mensagem = "Fornecedor atualizado com sucesso.",
                fornecedor = _fornecedorAppService.Update(request)
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, new
            {
                mensagem = "Os seguintes dados do fornecedor foram excluídos como sucesso.",
                fornecedor = _fornecedorAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<FornecedorResponse>), 200)]
        public IActionResult GetAll()
        {
            return Ok(_fornecedorAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FornecedorResponse), 200)]
        public IActionResult GetById(Guid id)
        {
            return Ok(_fornecedorAppService.GetById(id));
        }
    }
}
