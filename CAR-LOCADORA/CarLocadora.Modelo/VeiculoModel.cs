using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Modelo
{
    public class VeiculoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Placa é obrigatório.")]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "Preenchimento mínimo de 7 caracteres e máximo de 8")]
        public string Placa { get; set; } = string.Empty;


        [StringLength(100, MinimumLength = 5, ErrorMessage = "Preenchimento mínimo de 5 caracteres e máximo de 100")]
        public string Chassi { get; set; } = string.Empty;


        [Required(ErrorMessage = "Marca é obrigatório.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Preenchimento mínimo de 4 caracteres e máximo de 100")]
        public string Marca { get; set; } = string.Empty;


        [Required(ErrorMessage = "Modelo é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Preenchimento mínimo de 5 caracteres e máximo de 150")]
        public string Modelo { get; set; }


        [Required(ErrorMessage = "Combustível é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Preenchimento mínimo de 1 caracter e máximo de 100")]
        public string Combustivel { get; set; }


        [Required(ErrorMessage = "Cor é obrigatório.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Preenchimento mínimo de 4 caracteres e máximo de 100")]
        public string Cor { get; set; } 

        public string? Opcionais { get; set; }


        [Required(ErrorMessage = "Ativo é obrigatório.")]
        public bool Ativo { get; set; } = true;


        [Required(ErrorMessage = "Data de Inclusão é obrigatória.")]
        [Display(Name = "Data de Inclusão")]
        public DateTime DataInclusao { get; set; }


        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }



    }
}