using rectBackend.Repository;

AlumnoDao alumnoDao = new AlumnoDao();
var alumnos = alumnoDao.SelectAll();
foreach (var item in alumnos)
{
    Console.WriteLine(item.Nombre);
}

Console.WriteLine("");

var selectById = alumnoDao.GettById(1);
Console.WriteLine(selectById?.Nombre);
