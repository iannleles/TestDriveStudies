using API_Estudos.Context;
using API_Estudos.Models;
using API_Estudos.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API_Estudos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly APIEstudosContext _context;

        public MedicosController(APIEstudosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<MedicoDTO> medicosDTO = new List<MedicoDTO>();
            var medicos = _context.Medicos.Where(x => x.Excluido == false).ToList();
            foreach (var item in medicos)
            {
                medicosDTO.Add(new MedicoDTO
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    CRM = item.CRM,
                });
            }
            return Ok(medicosDTO);
        }

        [HttpPost]
        public IActionResult Insert(MedicoDTO medicoDTO)
        {
            var medico = new Medico
            {
               Nome = medicoDTO.Nome,
               CRM = medicoDTO.CRM,
               EspecialidadeId = medicoDTO.EspecialidadeId
            };
            medico.InserirDadosBase();
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return Ok(medicoDTO);
        }

        [HttpPut]
        public IActionResult Update(MedicoDTO medicoDTO)
        {
            var medico = _context.Medicos.FirstOrDefault(x => x.Id == medicoDTO.Id);

            if (medico == null)
            {
                return NotFound();
            }
            medico.CRM = medicoDTO.CRM;
            medico.Nome = medicoDTO.Nome;
            medico.EspecialidadeId = medicoDTO.EspecialidadeId;
            _context.Medicos.Update(medico);
            _context.SaveChanges();
            return Ok(medicoDTO);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var medico = _context.Medicos.First(x => x.Id == id);
            //_context.Medicos.Remove(medico);
            //_context.SaveChanges();
            if (medico == null)
            {
                return NotFound();
            }
            medico.Excluido = true;
            _context.Update(medico);
            _context.SaveChanges();
            return Ok();
        }
    }
}
