using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Modelo
{
    public class FormaPagamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "ID é obrigatório.")]
        public int ID { get; set; }


        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatório.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Preenchimento mínmo de 2 caracteres e máximo de 150")]
        public string Descrição { get; set; } = string.Empty;


        [Required(ErrorMessage = "Ativo é obrigatório.")]
        public bool Ativo { get; set; } = true;

        [Display(Name = "Data de Inclusão")]
        [Required(ErrorMessage = "Data de Inclusão é obrigatório.")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }





    }
}