using AutoMapper;
using FornecedorApi.Application.Interfaces;
using FornecedorApi.Application.Models.Requests.Fornecedor;
using FornecedorApi.Application.Models.Responses;
using FornecedorApi.Domain.Entities;
using FornecedorApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Application.Services
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IFornecedorDomainService _fornecedorDomainService;
        private readonly IMapper _mapper;
        private readonly  IEnderecoDomainService _enderecoDomainService;

        public FornecedorAppService(IFornecedorDomainService fornecedorDomainService, IMapper mapper, IEnderecoDomainService enderecoDomainService)
        {
            _fornecedorDomainService = fornecedorDomainService;
            _mapper = mapper;
            _enderecoDomainService = enderecoDomainService;
        }

        public FornecedorResponse Create(FornecedorCreateRquest request)
        {
            var fornecedor = _mapper.Map<Fornecedor>(request);
            _fornecedorDomainService.Create(fornecedor);

            fornecedor.Endereco = _enderecoDomainService.GetById(fornecedor.IdEndereco.Value);
            return _mapper.Map<FornecedorResponse>(fornecedor);
        }

        public FornecedorResponse Update(FornecedorUpdateRequest request)
        {
            // Obtenha o fornecedor existente pelo IdFornecedor
            var fornecedor = _fornecedorDomainService.GetById((Guid)request.IdFornecedor);

            if (fornecedor != null)
            {
                // Atualize as propriedades do fornecedor com base nas informações fornecidas em request
                fornecedor.Nome = request.Nome;
                fornecedor.Cnpj = request.Cnpj;
                fornecedor.Telefone = request.Telefone;
                fornecedor.IdEndereco = request.IdEndereco;

                // Chame um método para atualizar o registro no banco de dados (por exemplo, usando o SaveChanges do Entity Framework)
                // Certifique-se de que o seu _fornecedorDomainService tenha um método para atualizar o registro no banco de dados
                _fornecedorDomainService.Update(fornecedor); // Isso deve salvar as alterações no banco de dados

                // Verifique se o fornecedor tem um IdEndereco válido
                if (fornecedor.IdEndereco.HasValue)
                {
                    // Obtenha o endereço associado ao fornecedor
                    fornecedor.Endereco = _enderecoDomainService.GetById(fornecedor.IdEndereco.Value);
                }

                // Mapeie o fornecedor atualizado para FornecedorResponse
                return _mapper.Map<FornecedorResponse>(fornecedor);
            }

            return null; // Ou lance uma exceção ou retorne um valor padrão
        }




        public FornecedorResponse Delete(Guid id)
        {
            var fornecedor = _fornecedorDomainService.GetById(id);

            fornecedor.Endereco = _enderecoDomainService.GetById(fornecedor.IdEndereco.Value);

            _fornecedorDomainService.Delete(id);

            return _mapper.Map<FornecedorResponse>(fornecedor);

        }

        public List<FornecedorResponse> GetAll()
        {
            var fornecedores = _fornecedorDomainService.GetAll(); 

            // Mapeando cada fornecedor e associando a seu endereço
            var fornecedoresComEnderecos = fornecedores.Select(fornecedor =>
            {
                fornecedor.Endereco = _enderecoDomainService.GetById(fornecedor.IdEndereco.Value);
                return _mapper.Map<FornecedorResponse>(fornecedor);
            }).ToList();

            return fornecedoresComEnderecos;
        }


        public FornecedorResponse GetById(Guid id)
        {
            var fornecedor = _fornecedorDomainService.GetById(id);

            if (fornecedor != null)
            {
                // Verifica se o fornecedor possui um ID de endereço válido
                if (fornecedor.IdEndereco.HasValue)
                {
                    // Obtém o endereço associado ao fornecedor
                    fornecedor.Endereco = _enderecoDomainService.GetById(fornecedor.IdEndereco.Value);
                }
                // Mapeia o fornecedor para um FornecedorResponse
                return _mapper.Map<FornecedorResponse>(fornecedor);
            }

            return null; // Ou lançar uma exceção ou retornar um valor padrão
        }

    }
}
