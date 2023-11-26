using AutoMapper;
using FornecedorApi.Application.Interfaces;
using FornecedorApi.Application.Models.Requests.Endereco;
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
    public class EnderecoAppService: IEnderecoAppService
    {
        private readonly IEnderecoDomainService _enderecoDomainService;
        private readonly IMapper _mapper;

        public EnderecoAppService(IEnderecoDomainService enderecoDomainService, IMapper mapper)
        {
            _enderecoDomainService = enderecoDomainService;
            _mapper = mapper;
        }

        public EnderecoResponse Create(EnderecoCreateRequest request)
        {
            var endereco = _mapper.Map<Endereco>(request);
            _enderecoDomainService.Create(endereco);
            return _mapper.Map<EnderecoResponse>(endereco);
        }

        public EnderecoResponse Update(EnderecoUpdateRequest request)
        {
            var endereco = _mapper.Map<Endereco>(request);
            _enderecoDomainService.Update(endereco);

            return _mapper.Map<EnderecoResponse>(endereco);

        }

        public EnderecoResponse Delete(Guid id)
        {
            var endereco = _enderecoDomainService.GetById(id);
            _enderecoDomainService.Delete(id);
            return _mapper.Map<EnderecoResponse>(endereco);
        }

        public List<EnderecoResponse> GetAll()
        {
            var endereco = _enderecoDomainService.GetAll();
            return _mapper.Map<List<EnderecoResponse>>(endereco);
        }

        public EnderecoResponse GetById(Guid id)
        {
            var endereco = _enderecoDomainService.GetById(id);
            return _mapper.Map<EnderecoResponse>(endereco);
        }
    }
}
