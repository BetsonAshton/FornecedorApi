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
    public class FornecedorDomainService:IFornecedorDomainService
    {
        private readonly IFornecedorRepository _fornecedorRepository ;

        public FornecedorDomainService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public void Create(Fornecedor entity)
        {
            entity.IdFornecedor = Guid.NewGuid();
            entity.Nome = entity.Nome;
            entity.Cnpj = entity.Cnpj;
            entity.Telefone = entity.Telefone;
            entity.Endereco = entity.Endereco;
            _fornecedorRepository.Create(entity);
        }

        public void Update(Fornecedor entity)
        {
            
            _fornecedorRepository.Update(entity);

        }

        public void Delete(Guid id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            _fornecedorRepository.Delete(fornecedor);

        }

        public List<Fornecedor> GetAll()
        {
            return _fornecedorRepository.GetAll();
        }

        public Fornecedor GetById(Guid id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            return _fornecedorRepository.GetById(id);
        }
    }
}
