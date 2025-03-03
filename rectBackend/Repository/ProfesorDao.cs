using rectBackend.Context;
using rectBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectBackend.Repository
{
    public class ProfesorDao
    {
        public RegistroAlumnoContext context = new RegistroAlumnoContext();


        #region GetById
        public Profesor login(string usuario, string pass)
        {
            var prof = context.Profesors.Where(p => p.Usuario == usuario && p.Pass == pass).FirstOrDefault();
            return prof;
        }
        #endregion
    }
}
