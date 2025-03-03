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

        #region update alumno
        public bool Update(int id, Alumno actualizar)
        {
            try
            {
                var alumnoUpdate = GettById(id);

                if (alumnoUpdate == null)
                {
                    Console.WriteLine("No se encontro el alumno");
                    return false;
                }

                alumnoUpdate.Direccion = actualizar.Direccion;
                alumnoUpdate.Dni = actualizar.Dni;
                alumnoUpdate.Nombre = actualizar.Nombre;
                alumnoUpdate.Edad = actualizar.Edad;
                alumnoUpdate.Email = actualizar.Email;

                contexto.Alumnos.Update(alumnoUpdate);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.InnerException);
                return false;
            }
        }
        #endregion

        #region Delete
        public bool DeleteAlumno(int id)
        {
            try
            {
                var alumnoDelete = GettById(id);
                if (alumnoDelete == null)
                {
                    Console.WriteLine("No se encontro el alumno");
                    return false;
                }
                else
                {
                    contexto.Alumnos.Remove(alumnoDelete);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }
        #endregion

        #region Leftjoin
        public List<AlumnoAsignatura> SelectAlumAsig()
        {
            var consulta = from a in contexto.Alumnos
                           join m in contexto.Matriculas on a.Id equals m.AlumnoId
                           join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                           select new AlumnoAsignatura
                           {
                               nombreAlumno = a.Nombre,
                               nombreAsignatura = asig.Nombre
                           };
            return consulta.ToList();
        }
        #endregion

        #region AlumnoProfesor
        public List<AlumnoProfesor> alumnoProfesors(string nombreProfesor)
        {
            var listadoALumno = from a in contexto.Alumnos
                                join m in contexto.Matriculas on a.Id equals m.AlumnoId
                                join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                                where asig.Profesor == nombreProfesor
                                select new AlumnoProfesor
                                {
                                    Id = a.Id,
                                    Dni = a.Dni,
                                    Nombre = a.Nombre,
                                    Direccion = a.Direccion,
                                    Edad = a.Edad,
                                    Email = a.Email,
                                    asignatura = asig.Nombre
                                };

            return listadoALumno.ToList();
        }
        #endregion
    }
}
