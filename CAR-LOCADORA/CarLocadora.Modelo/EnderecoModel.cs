using System.ComponentModel.DataAnnotations;

namespace CarLocadora.Modelo
{
    public class EnderecoModel
    {
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Preenchimento mínimo de 5 caracteres e máximo de 50")]
        public string Logradouro { get; set; } = string.Empty;



        [Required(ErrorMessage = "Numero é obrigatório.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Preenchimento mínimo de 1 caracter e máximo de 20")]
        public string Numero { get; set; } = string.Empty;


        public string? Complemento { get; set; }


        [Required(ErrorMessage = "Cidade é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Preenchimento mínimo de 5 caracteres e máximo de 50")]
        public string Cidade { get; set; } = string.Empty;



        [Required(ErrorMessage = "Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "UF obrigatório")]
        public string Estado { get; set; } = string.Empty;
    }
}