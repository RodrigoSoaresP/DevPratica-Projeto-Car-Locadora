using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Modelo
{
    public class UsuarioModel : EnderecoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Preenchimento obrigatório com 14 caracteres")]
        public string CPF { get; set; } = string.Empty;


        [Required(ErrorMessage = "RG é obrigatório.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Preenchimento mínimo de 5 caracteres e máximo de 50")]
        public string RG { get; set; } = string.Empty;



        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "Nome completo é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Preenchimento mínimo de 5 caracteres e máximo de 150")]
        public string Nome { get; set; } = string.Empty;


        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        public string? Telefone { get; set; }


        [Required(ErrorMessage = "Celular é obrigatório.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Preenchimento obrigatório com 15 caracteres")]
        public string Celular { get; set; } = string.Empty;

        [Display(Name = "Senha")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Preenchimento mínimo de 10 caracteres e máximo de 300")]
        public string Senha { get; set; } = string.Empty;


        [Required(ErrorMessage = "Ativo é obrigatório.")]
        public bool Ativo { get; set; } = true;

        [Display(Name = "Data de Inclusão")]
        [Required(ErrorMessage = "Data de Inclusão é obrigatória.")]
        public DateTime DataInclusao { get; set; }


        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}