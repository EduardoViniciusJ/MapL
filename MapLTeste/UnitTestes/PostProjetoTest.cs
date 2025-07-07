using FluentAssertions;
using MapL.Controllers;
using MapL.DTOs;
using MapL.DTOs.ComoDTO;
using MapL.DTOs.OQueDTO;
using MapL.DTOs.PorDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLTeste.UnitTestes
{
    public class PostProjetoTest : IClassFixture<ProjetoUnitTestController>
    {
        private readonly ProjetoController _controller;

        public PostProjetoTest(ProjetoUnitTestController controller)
        {
            _controller = new ProjetoController(controller.repository, controller.mapper);
        }

        [Fact]
        public async Task PostProjetoCreated()
        {
            var novoProjetoDto = new ProjetoDTO
            {
                Titulo = "Teste"
            };

            var data = await _controller.Post(novoProjetoDto);

            var createdResult = data.Result.Should().BeOfType<CreatedAtActionResult>();
            createdResult.Subject.StatusCode.Should().Be(201);
        }


        [Fact]
        public async Task PostProjetoBadRequest()
        {
            ProjetoDTO prod = null;

            var data = await _controller.Post(prod);

            var badRequest = data.Result.Should().BeOfType<BadRequestObjectResult>();
            badRequest.Subject.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task PostProjetoCompleto()
        {
            var projetoDTO = new ProjetoCompletoDTO
            {
                Titulo = "Projeto Teste",
                Motivacoes = new List<MotivacaoCriarDTO>
                {
                    new MotivacaoCriarDTO {Descricao = "Motivação 1"},
                    new MotivacaoCriarDTO {Descricao = "Motivação 2"}
                },
                Conhecimentos = new List<ConhecimentoCriarDTO>
                {
                    new ConhecimentoCriarDTO {Conceito = "Conceito 1",
                                              Fato = "Fato 1",
                                              Procedimento = "Procedimento 1"},
                },
                Estrategias = new List<EstrategiaCriarDTO>
                {
                    new EstrategiaCriarDTO {Descricao = "Teste 1"}
                }
            };

            var data = await _controller.PostCompleto(projetoDTO);

            var createdResult = data.Result.Should().BeOfType<CreatedAtActionResult>();
            createdResult.Subject.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task PostProjetoCompletoBadRequest()
        {
            ProjetoCompletoDTO prod = null;

            var data = await _controller.PostCompleto(prod);

            var badresquest = data.Result.Should().BeOfType<BadRequestObjectResult>();
            badresquest.Subject.StatusCode.Should().Be(400);
        }


    }
}
