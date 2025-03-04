using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rectBackend.Models;
using rectBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private CalificacionDao _cdao = new CalificacionDao();

        #region Lista de calificaciones 
        [HttpGet("calificaciones")]
        public List<Calificacion> get(int idMatricula)
        {
            return _cdao.seleccion(idMatricula);
        }
        #endregion

    }
}
