using DemoDapperAPI.Models;
using DemoDapperAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        // GET: api/<ClientesController>
        [HttpGet]
        public ActionResult<IEnumerable<Alumno>> Get()
        {
            var alumnoService = new AlumnoServices();
            {
                var alumno = AlumnoService.GetAlumno();
                if (alumno != null)
                {
                    return Ok(alumno);
                }
                return NotFound("Mensaje: There is not alumno");
            }
        }



        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            var alumnoService = new AlumnoServices();
            {
                var alumno = alumnoService.GetAlumnoById(id);
                if (alumno != null)
                {
                    return Ok(Alumno);
                }
                return NotFound("Mensaje: There is not student with id: " + id);
            }
        }


        //api/Alumno/async
        [HttpPost]
        [Route("ASYNC")]
        public async Task PostAsync([FromBody] Alumno alumno)
        {
            try
            {
                var alumnoService = new AlumnoServices();
                {
                    alumno.id = 0;
                    await alumnoService.AddAlumnoAsync(alumno);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("{id}")]
        [Route("ASYNC")]
        public async Task PutAsync([FromBody] Alumno alumno)
        {
            try
            {
                var alumnoService = new AlumnoServices();
                {
                    await alumnoService.UpdateAlumnoAsync(alumno);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
