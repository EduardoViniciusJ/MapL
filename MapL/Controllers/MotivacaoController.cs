using AutoMapper;
using MapL.DTOs.PorDTO;
using MapL.Models;
using MapL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MotivacaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uof;

        public MotivacaoController(IUnitOfWork uof, IMapper mapper)
        {
            _mapper = mapper;
            _uof = uof;
        }

        [HttpGet]
        // Obter todas as motivações
        public ActionResult<IEnumerable<MotivacaoDTO>> Get()
        {
            var motivacoes = _uof.Motivacoes.ObterTodas();

            if (motivacoes == null)
            {
                return NotFound();
            }

            var motivacoesDTO = _mapper.Map<IEnumerable<MotivacaoDTO>>(motivacoes);

            return Ok(motivacoesDTO);
        }

        [HttpGet("{id}/projeto")]
        // Obter motivações por ID do projeto
        public ActionResult<MotivacaoDTO> GetProjetoId(int id)
        {
            var motivacao = _uof.Motivacoes.ObterPorProjetoId(id);

            if (motivacao == null)
            {
                return NotFound();
            }

            var motivacaoDTO = _mapper.Map<MotivacaoDTO>(motivacao);

            return Ok(motivacaoDTO);
        }

        [HttpGet("{id}/motivacao")]
        // Obter motivação por ID
        public ActionResult<MotivacaoDTO> GetMotivacaoId(int id)
        {
            var motivacao = _uof.Motivacoes.ObterPorId(id);

            if (motivacao == null)
            {
                return NotFound();
            }

            var motivacaoDTO = _mapper.Map<MotivacaoDTO>(motivacao);

            return Ok(motivacaoDTO);
        }

        [HttpPost]
        // Criar uma nova motivação
        public ActionResult<MotivacaoDTO> Post(MotivacaoDTO motivacaoDTO)
        {
            if (motivacaoDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            var motivacao = _mapper.Map<Motivacao>(motivacaoDTO);
            var motivacaoNovo = _uof.Motivacoes.Criar(motivacao);
            _uof.Commit();
            var motivacaoNovoDTO = _mapper.Map<MotivacaoDTO>(motivacaoNovo);

            return CreatedAtAction(nameof(Get), new { id = motivacaoNovoDTO.Id }, motivacaoNovoDTO);
        }

        [HttpPut("{projetoId}/porque/{id}")]
        // Atualizar uma motivação
        public ActionResult<MotivacaoDTO> Put(MotivacaoDTO motivacaoDTO, int projetoId, int id)
        {
            if (motivacaoDTO is null)
            {
                return BadRequest("Dados inválidos");
            }

            var motivacao = _mapper.Map<Motivacao>(motivacaoDTO);

            var motivacaoAtualizado = _uof.Motivacoes.Atualizar(motivacao, projetoId, id);
            _uof.Commit();

            var motivacaoAtualizadoDTO = _mapper.Map<MotivacaoDTO>(motivacaoAtualizado);

            return Ok(motivacaoAtualizadoDTO);
        }

        [HttpDelete("{projetoId}/porque/{id}")]
        // Deletar uma motivação
        public ActionResult Delete(int projetoId, int id)
        {
            var motivacao = _uof.Motivacoes.Remover(projetoId, id);
            _uof.Commit();

            if (motivacao == null)
            {
                return NotFound("Item não encontrado");
            }

            return Ok(motivacao);
        }




    }
}
