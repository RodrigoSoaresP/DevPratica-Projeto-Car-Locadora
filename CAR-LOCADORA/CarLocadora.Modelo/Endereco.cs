using System.ComponentModel.DataAnnotations;

namespace CarLocadora.Modelo
{
    public class Endereco
    {
        [Required(ErrorMessage = "Logradouro é obrigatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "caracteres mínimo 5 máximo de 50")]
        public string Logradouro { get; set; } = string.Empty;



        [Required(ErrorMessage = "Numero é obrigatorio.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "caracteres mínimo 2 máximo de 20")]
        public string Numero { get; set; } = string.Empty;



        [StringLength(50, MinimumLength = 0, ErrorMessage = "caracteres máximo de 50")]
        public string? Complemento { get; set; }


        [Required(ErrorMessage = "Cidade é obrigatorio.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "caracteres mínimo 5 máximo de 50")]
        public string Cidade { get; set; } = string.Empty;



        [Required(ErrorMessage = "Estado é obrigatorio.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "UF obrigatório")]
        public string Estado { get; set; } = string.Empty;
    }
}
