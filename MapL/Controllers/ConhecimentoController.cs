using AutoMapper;
using MapL.DTOs.OQueDTO;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConhecimentoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;


        public ConhecimentoController(IMapper mapper, IUnitOfWork uof)
        {
            _mapper = mapper;
            _uof = uof;
        }

        [HttpGet]
        // Obter todos os conhecimentos
        public ActionResult<IEnumerable<ConhecimentoDTO>> Get()
        {

            var conhecimentos = _uof.Conhecimentos.ObterTodas();

            if (conhecimentos == null)
            {
                return NotFound();
            }

            var conhecimentosDTO = _mapper.Map<IEnumerable<ConhecimentoDTO>>(conhecimentos);

            return Ok(conhecimentosDTO);
        }

        [HttpGet("{id}/conhecimento")]
        // Obter conhecimento por ID
        public ActionResult<ConhecimentoDTO> GetConhecimentoId(int id)
        {
            var conhecimento = _uof.Conhecimentos.ObterPorId(id);

            if (conhecimento == null)
            {
                return NotFound();
            }

            var conhecimentoDTO = _mapper.Map<ConhecimentoDTO>(conhecimento);

            return Ok(conhecimentoDTO);
        }

        [HttpGet("{id}/projeto")]
        // Obter conhecimentos por ID do projeto
        public ActionResult<IEnumerable<ConhecimentoDTO>> GetProjetoId(int id)
        {
            var conhecimento = _uof.Conhecimentos.ObterPorProjetoId(id);
            if (conhecimento == null)
            {
                return NotFound();
            }

            var conhecimentoDTO = _mapper.Map<IEnumerable<ConhecimentoDTO>>(conhecimento);

            return Ok(conhecimentoDTO);
        }

        [HttpPost]
        // Criar um novo conhecimento
        public ActionResult<ConhecimentoDTO> Post(ConhecimentoDTO conhecimentoDTO)
        {
            if (conhecimentoDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            var conhecimento = _mapper.Map<Conhecimento>(conhecimentoDTO);

            var conhecimentoCriado = _uof.Conhecimentos.Criar(conhecimento);

            _uof.Commit();

            var conhecimentoCriadoDTO = _mapper.Map<ConhecimentoDTO>(conhecimentoCriado);

            return CreatedAtAction(nameof(Get), new { id = conhecimentoCriadoDTO.Id }, conhecimentoCriadoDTO);
        }

        [HttpPut("{projetoId}/conhecimento/{id}")]
        // Atualizar um conhecimento
        public ActionResult<ConhecimentoDTO> Put(int projetoId, int id, ConhecimentoDTO conhecimentoDTO) {
            if (conhecimentoDTO is null)
            {
                return BadRequest("Dados inválidos");               
            }

            var conhecimento = _mapper.Map<Conhecimento>(conhecimentoDTO);

            var conhecimentoAtualizado = _uof.Conhecimentos.Atualizar(conhecimento, id, projetoId);

            _uof.Commit();

            var conhecimentoAtualizadoDTO = _mapper.Map<ConhecimentoDTO>(conhecimentoAtualizado);

            return Ok(conhecimentoAtualizadoDTO);
        }

        [HttpDelete("{projetoId}/conhecimento/{id}")]
        // Deletar um conhecimento
        public ActionResult DeleteOQueAprender(int projetoId, int id)
        {
            var conhecimento = _uof.Conhecimentos.Remover(id, projetoId);

            _uof.Commit();

            if (conhecimento == null)
            {
                return NotFound("Item não encontrado");
            }   

            return Ok(conhecimento);    
        }

    }

}

