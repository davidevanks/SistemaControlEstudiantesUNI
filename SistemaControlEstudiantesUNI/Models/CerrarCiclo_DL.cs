using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SistemaControlEstudiantesUNI.Models
{
    public class CerrarCiclo_DL
    {

        public bool CerrarCiclo()
        {
            bool ban = true;


            try
            {
                //Se llama a metodo para cerrar ciclo de periodo para estudiantes
                using (var contexto = new ControlAlumnosEntities())
                {
                   contexto.CerrarPeriodo();
                }

                ban = true;

            }
            catch (Exception ex)
            {
                ban = false;
                throw;
            }


            return ban;



        }
    }
}