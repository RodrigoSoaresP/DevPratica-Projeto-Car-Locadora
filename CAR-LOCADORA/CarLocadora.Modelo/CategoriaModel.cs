using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Modelo
{
    public class CategoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID é obrigatório.")]
        public int ID { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Preenchimento mínimo de 1 caracter e máximo 100")]
        public string Descricao { get; set; } = string.Empty;

        [Display(Name = "Valor Diária")]
        [Required(ErrorMessage = "Valor diária é obrigatório.")]
        public decimal ValorDiaria { get; set; }

        [Required(ErrorMessage = "Ativo é obrigatório.")]
        public bool Ativo { get; set; } = true;

        [Display(Name = "Data de Inclusão")]
        [Required(ErrorMessage = "Data de Inclusão é obrigatório.")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }

    }
}