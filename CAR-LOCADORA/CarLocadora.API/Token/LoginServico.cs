using CarLocadora.Models;

namespace CarLocadora.Token
{
    public class LoginServico
    {
        public async Task<LoginRespostaModel> Login(LoginRequisicaoModel loginRequisicaoModel)
        {
            LoginRespostaModel loginRespostaModel = new()
            {
                Autenticado = false,
                Usuario = loginRequisicaoModel.Usuario,
                Token = "",
                DataExpiracao = null
            };

            if (loginRequisicaoModel.Usuario == "RodrigoPSCarLocadora" && loginRequisicaoModel.Senha == "ProjetoCarLocadora_RPS")
            {
                loginRespostaModel = new GeradorToken().GerarToken(loginRespostaModel);
            }

            return loginRespostaModel;
        }
    }
}
