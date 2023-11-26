using FornecedorApi.Application.Models.Requests.Endereco;
using FornecedorApi.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Application.Interfaces
{
    public interface IEnderecoAppService
    {
        EnderecoResponse Create(EnderecoCreateRequest request);
        EnderecoResponse Update(EnderecoUpdateRequest request);

        EnderecoResponse Delete(Guid id);

        List<EnderecoResponse> GetAll();
        EnderecoResponse GetById(Guid id);
    }
}
