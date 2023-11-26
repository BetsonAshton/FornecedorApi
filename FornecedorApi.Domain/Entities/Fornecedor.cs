using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Domain.Entities
{
    public class Fornecedor
    {
        private Guid? _idFornecedor;
        private string? _nome;
        private string? _cnpj;
        private string? _telefone;
        private Guid? _idEndereco;
        private Endereco? _endereco;

        public Guid? IdFornecedor { get => _idFornecedor; set => _idFornecedor = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Cnpj { get => _cnpj; set => _cnpj = value; }
        public string? Telefone { get => _telefone; set => _telefone = value; }
        public Guid? IdEndereco { get => _idEndereco; set => _idEndereco = value; }
        public Endereco? Endereco { get => _endereco; set => _endereco = value; }
        
    }
}
