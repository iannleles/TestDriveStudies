using API_Estudos.Context;
using API_Estudos.Models;
using API_Estudos.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Estudos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspecialidadesController : ControllerBase
    {
        private readonly APIEstudosContext _context;

        public EspecialidadesController(APIEstudosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<EspecialidadeDTO> especialidadesDTO = new List<EspecialidadeDTO>();            
            var especialidades = _context.Especialidades.Where(x=>x.Excluido == false).ToList();
            foreach (var item in especialidades)
            {
                especialidadesDTO.Add(new EspecialidadeDTO
                {   Id = item.Id,                 
                    Nome = item.Nome,                    
                });
            }

            return Ok(especialidadesDTO);
        }

        [HttpPost]
        public IActionResult Insert(EspecialidadeDTO especialidadeDTO)
        {
            var especialidade = new Especialidade
            {
               Nome = especialidadeDTO.Nome,              
            };
            especialidade.InserirDadosBase();
            _context.Especialidades.Add(especialidade);
            _context.SaveChanges();
            return Ok(especialidadeDTO);
        }

        [HttpPut]
        public IActionResult Update(EspecialidadeDTO especialidadeDTO)
        {
            var especialidade = _context.Especialidades.FirstOrDefault(x => x.Id == especialidadeDTO.Id);

            if (especialidade == null)
            {
                return NotFound();
            }         
            especialidade.Nome = especialidadeDTO.Nome;
            _context.Especialidades.Update(especialidade);
            _context.SaveChanges();
            return Ok(especialidadeDTO);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var especialidade = _context.Especialidades.First(x => x.Id == id);
            //_context.Especialidades.Remove(especialidade);
            //_context.SaveChanges();
            if (especialidade == null)
            {
                return NotFound();
            }
            especialidade.Excluido = true;
            _context.Update(especialidade);
            _context.SaveChanges();
            return Ok();
        }
    }
}
