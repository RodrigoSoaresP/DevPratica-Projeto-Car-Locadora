using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Modelo
{
    public class VistoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id é obrigatório.")]
        public int Id { get; set; }

        [Display(Name = "Locação ID")]
        [Required(ErrorMessage = "Locação ID é obrigatório.")]
        public int LocacaoID { get; set; } 
    

        [Display(Name = "KM Saída")]
        [Required(ErrorMessage = "KM saída é obrigatório.")]
        public long KmSaida { get; set; }

        [Display(Name = "Combustível Saída")]
        [Required(ErrorMessage = "Combustível saída é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Preenchimento mínimo de 1 caracter e máximo 50")]
        public string CombustivelSaida { get; set; } = "";

        [Display(Name = "Observação Saída")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Preenchimento mínimo de 1 caracter e máximo 2000")]
        public string? ObservacaoSaida { get; set; }

        [Display(Name = "Data da Retirada")]
        [Required(ErrorMessage = "Data da retirada é obrigatório.")]
        public DateTime DataHoraRetiradaPatio { get; set; }

        [Display(Name = "KM Entrada")]
        public long? KmEntrada { get; set; }

        [Display(Name = "Combustível Entrada")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Preenchimento mínimo de 1 caracter e máximo 50")]
        public string? CombustivelEntrada { get; set; }

        [Display(Name = "Observação Entrada")]
        [StringLength(2000, MinimumLength = 1, ErrorMessage = "Preenchimento mínimo de 1 caracter e máximo 2000")]
        public string? ObservacaoEntrada { get; set; }

        [Display(Name = "Data da Devolução")]
        public DateTime? DataHoraDevolucaoPatio { get; set; }

        [Display(Name = "Data de Inclusão")]
        [Required(ErrorMessage = "Data de Inclusão é obrigatória.")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }

    }
}