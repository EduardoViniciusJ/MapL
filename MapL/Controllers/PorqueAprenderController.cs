using AutoMapper;
using MapL.DTOs;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PorqueAprenderController : Controller
    {
        private readonly IPorqueAprenderRepository _porqueAprenderRepository;
        private readonly IMapper _mapper;

        public PorqueAprenderController(IPorqueAprenderRepository porqueAprenderRepository, IMapper mapper)
        {
            _porqueAprenderRepository = porqueAprenderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PorqueAprenderDTO>> Get()
        {
            var porqueAprender = _porqueAprenderRepository.PorqueAprenderGet();

            if (porqueAprender == null)
            {
                return NotFound();
            }

            var porqueAprenderDto = _mapper.Map<IEnumerable<PorqueAprenderDTO>>(porqueAprender);

            return Ok(porqueAprenderDto);
        }

        [HttpGet("{id}/projeto")]
        public ActionResult<PorqueAprenderDTO> GetIdProjeto(int id)
        {
            var porqueAprender = _porqueAprenderRepository.PorqueAprenderGetIdProjeto(id);

            if (porqueAprender == null)
            {
                return NotFound();
            }

            var porqueAprenderDto = _mapper.Map<PorqueAprenderDTO>(porqueAprender);

            return Ok(porqueAprenderDto);
        }

        [HttpGet("{id}/porque")]
        public ActionResult<PorqueAprenderDTO> GetIdPorque(int id)
        {
            var porqueAprender = _porqueAprenderRepository.PorqueAprenderGetIdPorque(id);

            if (porqueAprender == null)
            {
                return NotFound();
            }

            var porqueAprenderDto = _mapper.Map<PorqueAprenderDTO>(porqueAprender);

            return Ok(porqueAprenderDto);
        }

        [HttpPost]
        public ActionResult<PorqueAprenderDTO> Post(PorqueAprenderDTO porqueAprendeDto)
        {
            if (porqueAprendeDto == null)
            {
                return BadRequest("Dados inválidos");
            }

            var porqueAprender = _mapper.Map<PorqueAprender>(porqueAprendeDto);
            var porqueAprenderNovo = _porqueAprenderRepository.PorqueAprenderPost(porqueAprender);
            var porqueAprenderNovoDTO = _mapper.Map<PorqueAprenderDTO>(porqueAprenderNovo);

            return CreatedAtAction(nameof(Get), new { id = porqueAprenderNovoDTO.Id }, porqueAprenderNovoDTO);
        }

        [HttpPut]
        public ActionResult<PorqueAprenderDTO> PutPorqueAprender(PorqueAprenderDTO porqueAprenderDTO)
        {
            if (porqueAprenderDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var porqueAprender = _mapper.Map<PorqueAprender>(porqueAprenderDTO);

            var porqueAprenderAtualizado = _porqueAprenderRepository.PorqueAprenderPut(porqueAprender);

            var porqueAprenderAtualizadoDTO = _mapper.Map<PorqueAprenderDTO>(porqueAprenderAtualizado);

            return Ok(porqueAprenderAtualizadoDTO);
        }

        [HttpDelete("{projetoId}/porque/{id}")]
        public ActionResult DeletePorqueAprender(int projetoId, int id)
        {
            var deletado = _porqueAprenderRepository.PorqueAprenderDelete(projetoId, id);

            if (deletado == null)
            {
                return NotFound("Item não encontrado");
            }

            return Ok(deletado);
        }




    }
}
