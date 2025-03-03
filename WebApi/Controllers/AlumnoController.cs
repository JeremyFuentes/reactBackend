using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rectBackend.Models;
using rectBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDao _dao = new AlumnoDao();

        #region endPointAlumnoProfesor
        [HttpGet("alumnoProfesor")]
        public List<AlumnoProfesor> GetAlumnoProfesor(string usuario)
        {
            return _dao.alumnoProfesors(usuario);
        }
        #endregion

        #region selectByID
        [HttpGet("alumno")]
        public Alumno selectById(int id)
        {
            var alumno = _dao.GettById(id);
            return alumno;
        }
        #endregion

        [HttpPut("alumno")]
        public bool actualizarAlumno([FromBody] Alumno alumno)
        {
            return _dao.Update(alumno.Id, alumno);
        }
    }
}
