using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorApi.Application.Models.Requests.Endereco
{
    public class EnderecoCreateRequest
    {
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        [RegularExpression(pattern: "^[A-Za-zÀ-Üà-ü\\s]{6,150}$",
            ErrorMessage = "Informe um logradouro válido de 6 a 150 caracteres.")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "Complemento é obrigatório.")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Numero é obrigatório.")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório.")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório.")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório.")]
        public string? Cep { get; set; }

    }
}
