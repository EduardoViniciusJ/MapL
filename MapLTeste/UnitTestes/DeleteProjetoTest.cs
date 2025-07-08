using FluentAssertions;
using MapL.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MapLTeste.UnitTestes
{
    public class DeleteProjetoTest : IClassFixture<ProjetoUnitTestController>
    {
        private readonly ProjetoController _controller;

        public DeleteProjetoTest(ProjetoUnitTestController controller)
        {
            _controller = new ProjetoController(controller.repository, controller.mapper);
        }

        [Fact]
        public async Task DeleteProjetoByIdOkResult()
        {
            var proId = 12;

            var result = await _controller.Delete(proId);

            result .Should().NotBeNull();
            result.Result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public async Task DeleteProjetoReturnNotFound()
        {
            var proId = 999;
            var result = await _controller.Delete(proId);
            result.Result.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);
        }
    }
}
