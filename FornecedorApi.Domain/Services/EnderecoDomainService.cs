using FornecedorApi.Domain.Entities;
using FornecedorApi.Domain.Interfaces.Repositories;
using FornecedorApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Domain.Services
{
    public class EnderecoDomainService: IEnderecoDomainService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoDomainService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void Create(Endereco entity)
        {
            _enderecoRepository.Create(entity);
        }

        public void Update(Endereco entity)
        {
            _enderecoRepository.Update(entity);
        }


        public void Delete(Guid id)
        {
            var endereco = _enderecoRepository.GetById(id);
            _enderecoRepository.Delete(endereco);

        }

        public List<Endereco> GetAll()
        {
            var endereco = _enderecoRepository.GetAll();
            return endereco;
        }

        public Endereco GetById(Guid id)
        {
            var endereco = _enderecoRepository.GetById(id);
            return endereco;
        }
    }
}
