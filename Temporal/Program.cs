using rectBackend.Models;
using rectBackend.Repository;
using System.Data.Entity.Core.Metadata.Edm;
#region Get All
AlumnoDao alumnoDao = new AlumnoDao();
var alumnos = alumnoDao.SelectAll();
foreach (var item in alumnos)
{
    Console.WriteLine(item.Nombre);
}
#endregion

Console.WriteLine("");

#region Get By Id
var selectById = alumnoDao.GettById(1);
Console.WriteLine(selectById?.Nombre);
#endregion

Console.WriteLine("");

#region Update
var nuevoAlumno2 = new Alumno
{
    Direccion = "Calle 123",
    Dni = "1345",
    Nombre = "Juan",
    Edad = 20,
    Email = "4524@gmail.com"
};

var resultado2 = alumnoDao.Update(2, nuevoAlumno2);
Console.WriteLine(resultado2);
#endregion

Console.WriteLine("");

#region Delete
var result = alumnoDao.DeleteAlumno(14);
Console.WriteLine("Se elimino " + result);
#endregion