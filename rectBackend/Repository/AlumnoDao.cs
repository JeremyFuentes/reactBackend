using rectBackend.Context;
using rectBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectBackend.Repository
{
    public class AlumnoDao
    {
        #region Context
        public RegistroAlumnoContext contexto = new RegistroAlumnoContext();
        #endregion

        #region Select All
        public List<Alumno> SelectAll()
        {
            var alumno = contexto.Alumnos.ToList<Alumno>();
            return alumno;
        }
        #endregion

        #region Select By Id
        public Alumno GettById(int id)
        {
            var alumno = contexto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? new Alumno() : alumno;
        }
        #endregion
    }
}
