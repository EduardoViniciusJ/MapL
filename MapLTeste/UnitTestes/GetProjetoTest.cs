using FluentAssertions;
using MapL.Controllers;
using MapL.DTOs;
using MapL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLTeste.UnitTestes
{
    public class GetProjetoTest : IClassFixture<ProjetoUnitTestController>
    {
        private readonly ProjetoController _controller;

        public GetProjetoTest(ProjetoUnitTestController controller)
        {
            _controller = new ProjetoController(controller.repository, controller.mapper);
        }

        [Fact] 
        public async Task GetProjetoByIdOkResult()
        {
            //Arrange
            var proId = 12;
            //Act
            var data = await _controller.GetId(proId);
            //Assert (FluetAssertions)
            data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetProjetoByIdReturnNotFound()
        {
            var proId = 999;

            var data = await _controller.GetId(proId);

            data.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);

        }
        [Fact]
        public async Task GetProjetoByIdBadRequest()
        {
            var proId = -1;

            var data = await _controller.GetId(proId);

            data.Should().BeOfType<BadRequestObjectResult>().Which.StatusCode.Should().Be(400);

        }

        [Fact]
        public async Task GetProjeto()
        {

            var data = await _controller.Get();

            data.Result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeAssignableTo<IEnumerable<ProjetoCompletoDTO>>().And.NotBeNull();
        }
   
    }
}
