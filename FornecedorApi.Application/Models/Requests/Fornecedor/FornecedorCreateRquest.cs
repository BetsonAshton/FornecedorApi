using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Application.Models.Requests.Fornecedor
{
    public class FornecedorCreateRquest
    {
        [Required(ErrorMessage = "Nome do Fornecedor  é obrigatório.")]
        [RegularExpression(pattern: "^[A-Za-zÀ-Üà-ü\\s]{6,150}$", ErrorMessage = "Informe um nome válido de 6 a 150 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Cnpj do fornecedor é obrigatório.")]
        public string? Cnpj { get; set; }

        [Required(ErrorMessage = "Telefone do cliente é obrigatório.")]
        [RegularExpression(pattern: "[() 0-9]{5,20}$",
         ErrorMessage = "Informe um telefone no formato '(00)000000000'.")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do endereco.")]
        public Guid? IdEndereco { get; set; }

    }
}
