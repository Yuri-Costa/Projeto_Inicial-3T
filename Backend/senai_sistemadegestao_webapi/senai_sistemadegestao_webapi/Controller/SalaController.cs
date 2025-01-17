﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_sistemadegestao_webapi.Domains;
using senai_sistemadegestao_webapi.Interfaces;
using senai_sistemadegestao_webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi.Controller
{
    //Define que  aresposta vai ser em json
    [Produces("application/json")]

    //passa a rota da api
    [Route("api/[controller]")]

    //Define que é um controlador
    [ApiController]
    public class SalaController : ControllerBase
    {
        private ISalaRepository _salaRepository { get; set; }

        public SalaController()
        {
            _salaRepository = new SalaRepository();
        }

        /// <summary>
        /// Faz a listagem das salas
        /// </summary>
        /// <returns>Todas as salas com suas informações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_salaRepository.ListarTodos());
        }

        /// <summary>
        /// Faz a busca pelo identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>O objeto com suas informações</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_salaRepository.BuscarPorId(id));
                
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Faz o cadastro de uma sala
        /// </summary>
        /// <param name="novaSala">Nomenclatura de cadastro</param>
        /// <returns>Objeto cadastrado com suas informações</returns>
        [HttpPost]
        public IActionResult Post(Sala novaSala)
        {
            try
            {
                // Faz a chamada para o método
                _salaRepository.Cadastrar(novaSala);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// Faz a atualizaçaõ de uma sala
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="salaAtualizada">Nomenclatura do objeto atualizado</param>
        /// <returns>Objeto com suas informações atualizadas</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Sala salaAtualizada)
        {
            try
            {
                // Faz a chamada para o método
                _salaRepository.Atualizar(id, salaAtualizada);
                

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

           
        }

        /// <summary>
        /// Faz a exclusão de uma sala
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Objeto excluído</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _salaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
