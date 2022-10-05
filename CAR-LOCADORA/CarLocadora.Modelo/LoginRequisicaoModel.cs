using System.ComponentModel.DataAnnotations;

namespace CarLocadora.Modelo
{
    public class LoginRequisicaoModel
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
