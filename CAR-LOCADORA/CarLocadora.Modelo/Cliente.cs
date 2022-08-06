using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Modelo
{

    public class Cliente : Endereco
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "CPF é obrigatorio.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "caracteres mínimos 14")]
        public string CPF { get; set; } = string.Empty;


        [Required(ErrorMessage = "CNH é obrigatorio.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "caracteres máximo de 12")]
        public string CNH { get; set; } = string.Empty;



        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "Nome completo é obrigatorio.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "caracteres mínimo 5 máximo de 150")]
        public string Nome { get; set; } = string.Empty;


        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento é obrigatorio.")]
        public DateTime DataNascimento { get; set; }


        [StringLength(15, MinimumLength = 0, ErrorMessage = "caracteres mínimo 0 máximo de 15")]
        public string? Telefone { get; set; }


        [Required(ErrorMessage = "Celular é obrigatorio.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "caracteres mínimo 15 máximo de 15")]
        public string Celular { get; set; } = string.Empty;


        [Required(ErrorMessage = "Ativo é obrigatório.")]
        public bool Ativo { get; set; } = true;


        [Required(ErrorMessage = "Data de Inclusão é obrigatoria.")]
        public DateTime DataInclusao { get; set; }


        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }

    }

}