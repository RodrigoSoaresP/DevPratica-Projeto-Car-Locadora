using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Modelo
{

    public class ClienteModel : EnderecoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Preenchimento obrigatório com 14 caracteres")]
        public string CPF { get; set; } = string.Empty;


        [Required(ErrorMessage = "CNH é obrigatório.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Preenchimento obrigatório com 12 caracteres")]
        public string CNH { get; set; } = string.Empty;



        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "Nome completo é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Preenchimento mínimo de 5 caracteres e máximo de 150")]
        public string Nome { get; set; } = string.Empty;


        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [StringLength(15, MinimumLength = 14, ErrorMessage = "Preenchimento mínimo de 14 caracteres e máximo de 15")]
        public string? Telefone { get; set; }


        [Required(ErrorMessage = "Celular é obrigatório.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Preenchimento obrigatório com 15 caracteres")]
        public string Celular { get; set; } = string.Empty;


        [Required(ErrorMessage = "Ativo é obrigatório.")]
        public bool Ativo { get; set; } = true;

        [Display(Name = "Data de Inclusão")]
        [Required(ErrorMessage = "Data de Inclusão é obrigatório.")]
        public DateTime DataInclusao { get; set; }


        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }

        [StringLength(100, ErrorMessage = "Este campo deve ter no maximo 100 caracteres.")]
        public string? Email { get; set; }


        [DefaultValue("false")]
        public bool EmailEnviado { get; set; }

    }

}