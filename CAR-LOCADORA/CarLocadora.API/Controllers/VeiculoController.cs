﻿using CarLocadora.Modelo;
using CarLocadora.Negocio.Veiculo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoNegocio _veiculoNegocio;

        public VeiculoController(IVeiculoNegocio veiculo)
        {
            _veiculoNegocio = veiculo;
        }

        [HttpGet("ObterLista")]

        public async Task<List<VeiculoModel>> Get()
        {

            return await _veiculoNegocio.ObterLista();

        }


        [HttpGet("ObterDados")]

        public async Task<VeiculoModel> Get([FromQuery] int placa)
        {

            return await _veiculoNegocio.Obter(placa);
        }

        [HttpPost()]
        public async Task Post([FromBody] VeiculoModel veiculo)
        {
            veiculo.DataInclusao = DateTime.Now;
            veiculo.DataAlteracao = null;
            await _veiculoNegocio.Inserir(veiculo);
        }


        [HttpPut()]
        public async Task Put([FromBody] VeiculoModel veiculo)
        {
            veiculo.DataAlteracao = DateTime.Now;
            await _veiculoNegocio.Alterar(veiculo);
        }

        [HttpDelete()]
        public async Task Delete([FromQuery] int placa)
        {

            await _veiculoNegocio.Excluir(placa);
        }

    }
}