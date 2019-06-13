using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaControlEstudiantesUNI.ViewModels
{
    public class rptConstanciaNotasIndividual_VM
    {
        public long id { get; set; }
        public string Estudiante { get; set; }
        public string no_carnet { get; set; }
        public string AnioCursa { get; set; }
        public string Carrera { get; set; }
        public string fechaLetra { get; set; }

        public List<ConstanciaNotasPeriodos> LstPeriodos { get; set; }
        public List<ConstanciaNotasAsignaturas> LstAsignaturas { get; set; }

    }


    public class ListaConstanciaNotas
    {
        public long id { get; set; }
        public string Estudiante { get; set; }

    }
    public class ConstanciaNotasPeriodos
    {

        public long id { get; set; }
        public string Periodo { get; set; }
    }

    public class ConstanciaNotasAsignaturas
    {

        public long id { get; set; }
        public long idPeriodo { get; set; }
        public string Asignatura { get; set; }
        public double Notas { get; set; }
        public double Conv { get; set; }
        public string NotaLetras { get; set; }
        public string ConvLetras { get; set; }
    }

   
}