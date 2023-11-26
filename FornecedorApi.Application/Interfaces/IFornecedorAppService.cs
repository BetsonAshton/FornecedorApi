using FornecedorApi.Application.Models.Requests.Fornecedor;
using FornecedorApi.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Application.Interfaces
{
    public interface IFornecedorAppService
    {
        FornecedorResponse Create(FornecedorCreateRquest request);
        FornecedorResponse Update(FornecedorUpdateRequest request);
        FornecedorResponse Delete(Guid id);
        List<FornecedorResponse> GetAll();
        FornecedorResponse GetById(Guid id);

    }
}
