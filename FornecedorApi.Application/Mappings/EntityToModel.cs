using AutoMapper;
using FornecedorApi.Application.Models.Responses;
using FornecedorApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Application.Mappings
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<Endereco, EnderecoResponse>();
            CreateMap<Fornecedor, FornecedorResponse>();
        }
    }

}
