using Azure.Core;
using FornecedorApi.Application.Interfaces;
using FornecedorApi.Application.Models.Requests.Endereco;
using FornecedorApi.Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FornecedorApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoAppService _enderecoAppService;

        public EnderecoController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }

        [HttpPost]
       
        public IActionResult Post(EnderecoCreateRequest request)
        {
            return StatusCode(201, new
            {
                mensagem = "Endereco cadastrado com sucesso.",
                endereco = _enderecoAppService.Create(request)
            });
        }

        [HttpPut]
        public IActionResult Put(EnderecoUpdateRequest request)
        {
            return StatusCode(200, new
            {
                mensagem = "Endereco atualizado com sucesso.",
                endereco = _enderecoAppService.Update(request)
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, new
            {
                mensagem = "O seguinte endereco foi excluído como sucesso.",
                endereco = _enderecoAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EnderecoResponse>), 200)]
        public IActionResult GetAll() 
        {
            return StatusCode(200, _enderecoAppService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EnderecoResponse), 200)]
        public IActionResult GetById(Guid id)
        {
            return StatusCode(200, _enderecoAppService.GetById(id));
        }

    }
}
