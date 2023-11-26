using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Application.Models.Responses
{
    public class FornecedorResponse
    {
        public Guid? IdFornecedor { get; set; }

        public string? Nome { get; set; }

        public string? Cnpj { get; set; }

        public string? Telefone { get; set; }

        public EnderecoResponse Endereco { get; set; }
    }
}
