using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaControlEstudiantesUNI.ViewModels;

namespace SistemaControlEstudiantesUNI.Models
{
    public class Turno_DL
    {

        public List<Turnos_VM> ListarTurnos()
        {
            List<Turnos_VM> lstTurnos = new List<Turnos_VM>();
            using (var contexto = new ControlAlumnosEntities())
            {
                lstTurnos = contexto.turnos.Select(x => new Turnos_VM
                {

                    id = x.idTurno,
                    nombre_turno=x.nombre_turno,
                    horario_turno=x.horario_turno,
                    activo=(bool)x.activo

                }).ToList();

                return lstTurnos;
            }


        }


        public Turnos_VM ListarTurnoId(long id)
        {
            Turnos_VM lstTurno = new Turnos_VM();
            using (var contexto = new ControlAlumnosEntities())
            {
                lstTurno = contexto.turnos.Where(x =>  x.idTurno == id).Select(x => new Turnos_VM
                {

                   id=x.idTurno,
                   nombre_turno=x.nombre_turno,
                   horario_turno=x.horario_turno,
                   activo=(bool)x.activo

                }).FirstOrDefault();

                return lstTurno;
            }


        }

        public bool EditarTurno(Turnos_VM TurnosId)
        {

            try
            {
                var Tur = new turnos { idTurno = TurnosId.id };

                using (var context = new ControlAlumnosEntities())

                {

                    context.turnos.Attach(Tur);
                    Tur.idTurno = TurnosId.id;
                    Tur.nombre_turno = TurnosId.nombre_turno;
                    Tur.horario_turno = TurnosId.horario_turno;
                    Tur.activo = TurnosId.activo;


                    context.Configuration.ValidateOnSaveEnabled = false;

                    context.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }


        }


        public bool GuardarTurno(Turnos_VM turnos)
        {

            try
            {
                using (var contexto = new ControlAlumnosEntities())
                {
                    turnos tur = new turnos();

                    tur.nombre_turno = turnos.nombre_turno;
                    tur.horario_turno = turnos.horario_turno;
                    tur.activo = true;



                    contexto.turnos.Add(tur);
                    contexto.SaveChanges();


                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }



        }
    }
}