using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarLocadora.Modelo
{
    public class LocacaoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id é obrigatório.")]
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Preenchimento obrigatório com 14 caracteres")]
        public string ClienteCPF { get; set; } = "";
      

        [Display(Name = "Forma Pagamento")]
        [Required(ErrorMessage = "Forma Pagamento é obrigatório.")]
        public string FormaPagamentosId { get; set; } = "";
       

        public int? CategoriaId { get; set; }


        [Display(Name = "Data da Reserva")]
        [Required(ErrorMessage = "Data e hora da reserva é obrigatório.")]
        public DateTime DataHoraReserva { get; set; }

        [Display(Name = "Data da Retirada")]
        [Required(ErrorMessage = "Data da retirada é obrigatório.")]
        public DateTime DataHoraRetiradaPrevista { get; set; }

        [Display(Name = "Data da Devolução")]
        [Required(ErrorMessage = "Data da devolução é obrigatório.")]
        public DateTime DataHoraDevolucaoPrevista { get; set; }

        [Display(Name = "Placa")]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "Preenchimento mínimo de 7 caracteres e máximo de 8")]
        public string VeiculoPlaca { get; set; } = "";
  

        [Display(Name = "Data de Inclusão")]
        [Required(ErrorMessage = "Data de Inclusão é obrigatório.")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }

    }
}