using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rectBackend.Models;
using rectBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDao _proDao = new ProfesorDao();

        [HttpPost("autentificacion")]

        public string loginProfesor([FromBody] Profesor prof)
        {
            var prof1 = _proDao.login(prof.Usuario, prof.Pass); // Fixed the error by removing 'new'
            if (prof1 != null)
            {
                return prof1.Usuario;
            }
            return "No se encontro el profesor";
        }
    }
}
