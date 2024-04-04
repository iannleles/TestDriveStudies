using API_Estudos.Context;
using API_Estudos.Models;
using API_Estudos.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Estudos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly APIEstudosContext _context;

        public PacientesController(APIEstudosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<PacienteDTO> pacientesDTO = new List<PacienteDTO>();            
            var pacientes = _context.Pacientes.Where(x=>x.Excluido == false).Include(x=>x.Medico).ToList();
            foreach (var item in pacientes)
            {
                pacientesDTO.Add(new PacienteDTO
                {
                    Id = item.Id,
                    DataNascimento = item.DataNascimento,
                    Nome = item.Nome,
                    SobreNome = item.SobreNome,
                    Telefone = item.Telefone,
                    MedicoId = item?.Medico?.Id
                });
            }

            return Ok(pacientesDTO);
        }

        [HttpPost]
        public IActionResult Insert(PacienteDTO pacienteDTO)
        {
            var paciente = new Paciente
            {
               Nome = pacienteDTO.Nome,
               SobreNome = pacienteDTO.SobreNome,
               DataNascimento = pacienteDTO.DataNascimento,
               Telefone = pacienteDTO.Telefone,
               MedicoId = pacienteDTO.MedicoId,
            };
            paciente.InserirDadosBase();
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return Ok(pacienteDTO);
        }

        [HttpPut]
        public IActionResult Update(PacienteDTO pacienteDTO)
        {
            var paciente = _context.Pacientes.FirstOrDefault(x => x.Id == pacienteDTO.Id);

            if (paciente == null)
            {
                return NotFound();
            }
            paciente.Telefone = pacienteDTO.Telefone;
            paciente.DataNascimento = pacienteDTO.DataNascimento;
            paciente.Nome = pacienteDTO.Nome;
            paciente.SobreNome = pacienteDTO.SobreNome;
            paciente.MedicoId = pacienteDTO.MedicoId;

            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
            return Ok(pacienteDTO);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var paciente = _context.Pacientes.First(x => x.Id == id);
            //_context.Pacientes.Remove(paciente);
            //_context.SaveChanges();
            if (paciente == null)
            {
                return NotFound();
            }
            paciente.Excluido = true;
            _context.Update(paciente);
            _context.SaveChanges();
            return Ok();
        }
    }
}
