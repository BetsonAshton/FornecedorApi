using AutoMapper;
using FornecedorApi.Application.Models.Requests.Endereco;
using FornecedorApi.Application.Models.Requests.Fornecedor;
using FornecedorApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Application.Mappings
{
    public class ModelToEntityMap:Profile
    {
        public ModelToEntityMap()
        {
            CreateMap<FornecedorCreateRquest, Fornecedor>()
                .AfterMap((src, dest) =>
                {
                    dest.IdFornecedor = Guid.NewGuid();

                });

            CreateMap<FornecedorUpdateRequest, Fornecedor>();

            CreateMap<EnderecoCreateRequest, Endereco>()
                 .AfterMap((src, dest) =>
                {
                    dest.IdEndereco = Guid.NewGuid();

                });

            CreateMap<EnderecoUpdateRequest, Endereco>();
        }
    }
}
