using FluentAssertions;
using MapL.Controllers;
using MapL.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLTeste.UnitTestes
{
    public class PutProjetoTest : IClassFixture<ProjetoUnitTestController>
    {
        private readonly ProjetoController _controller;

        public PutProjetoTest(ProjetoUnitTestController controller)
        {
            _controller = new ProjetoController(controller.repository, controller.mapper);
        }

        [Fact]
        public async Task ProjetoPutOkResult()
        {
            var prodId = 14;

            var updateProjetoDTO = new ProjetoDTO
            {
                Id = prodId,
                Titulo = "Teste"
            };

           var result = await _controller.Put(prodId, updateProjetoDTO);
            
            result.Should().NotBeNull(); // Verifica se não é null.
            result.Result.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200); // Verifica se o resultado é um http 200
        }

        [Fact]  
        public async Task ProjetoPutBadRequest()
        {
            var prodId = 33;

            var updateProjetoDTO = new ProjetoDTO
            {
                Id = 15,
                Titulo = "Testes"
            };

            var result = await _controller.Put(prodId, updateProjetoDTO);
            result.Result.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be(400);
        }




    }
}
