using AutoMapper;
using MapL.DTOs.OQueDTO;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OQueAprenderController : Controller
    {
        private readonly IConhecimentoRepository _oQueAprenderRepository;
        private readonly IMapper _mapper;


        public OQueAprenderController(IConhecimentoRepository oQueAprenderRespository, IMapper mapper)
        {
            _oQueAprenderRepository = oQueAprenderRespository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OQueAprenderDTO>> Get()
        {
            var oQueAprender = _oQueAprenderRepository.OQueAprenderGet();

            if (oQueAprender == null)
            {
                return NotFound();
            }

            var oQueAprenderDto = _mapper.Map<IEnumerable<OQueAprenderDTO>>(oQueAprender);

            return Ok(oQueAprenderDto);
        }

        [HttpGet("{id}/oque")]
        public ActionResult<OQueAprenderDTO> GetOQueAprender(int id)
        {
            var oQueAprender = _oQueAprenderRepository.OQueAprenderGetByIdOque(id);

            if (oQueAprender == null)
            {
                return NotFound();
            }

            var oQueAprenderDto = _mapper.Map<OQueAprenderDTO>(oQueAprender);

            return Ok(oQueAprenderDto);
        }

        [HttpGet("{id}/projeto")]
        public ActionResult<IEnumerable<OQueAprenderDTO>> GetProjeto(int id)
        {
            var oQueAprender = _oQueAprenderRepository.OQueAprenderGetByIdProjeto(id);
            if (oQueAprender == null)
            {
                return NotFound();
            }

            var oQueAprenderDto = _mapper.Map<IEnumerable<OQueAprenderDTO>>(oQueAprender);

            return Ok(oQueAprenderDto);
        }

        [HttpPost]
        public ActionResult<OQueAprenderDTO> PostOQueAprender(OQueAprenderDTO oQueAprenderDTO)
        {
            if (oQueAprenderDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            var oQueAprender = _mapper.Map<Conhecimento>(oQueAprenderDTO);

            var oQueAprenderCriado = _oQueAprenderRepository.OQueAprenderPost(oQueAprender);

            var oQueAprenderCriadoDTO = _mapper.Map<OQueAprenderDTO>(oQueAprenderCriado);

            return CreatedAtAction(nameof(GetOQueAprender), new { id = oQueAprenderCriadoDTO.Id }, oQueAprenderCriadoDTO);
        }

        [HttpPut("{projetoId}/porque/{id}")]
        public ActionResult<OQueAprenderDTO> PutOQueAprender(int projetoId, int id, OQueAprenderDTO oQueAprenderDTO) {
            if (oQueAprenderDTO is null)
            {
                return BadRequest("Dados inválidos");               
            }

            var oQueAprender = _mapper.Map<Conhecimento>(oQueAprenderDTO);

            var oQueAprenderAtualizado = _oQueAprenderRepository.OQueAprenderPut(oQueAprender,projetoId,id);

            var oQueAprenderAtualizadoDTO = _mapper.Map<OQueAprenderDTO>(oQueAprenderAtualizado);

            return Ok(oQueAprenderAtualizadoDTO);
        }

        [HttpDelete("{projetoId}/oque/{id}")]
        public ActionResult DeleteOQueAprender(int projetoId, int id)
        {
            var deletado = _oQueAprenderRepository.OQueAprenderDelete(projetoId, id);

            if(deletado == null)
            {
                return NotFound("Item não encontrado");
            }   

            return Ok(deletado);    
        }

    }

}

