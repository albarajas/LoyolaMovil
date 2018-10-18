using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class HorariosBLL
    {
        public tblHorario Create(tblHorario t)
        {
            tblHorario Result = null;
            using (var r = new Repository<tblHorario>())
            {
                tblHorario ba = r.Retrieve(p => p.idHorarios == t.idHorarios
                && p.horaInicio == t.horaInicio
                && p.horaFinal == t.horaFinal);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El horario ya existe."));
                }
            }
            return Result;
        }


        //public tblAnio RetrieveByAnioTexto(int anio)
        //{
        //    tblAnio Result = null;
        //    using (var r = new Repository<tblAnio>())
        //    {
        //        Result = r.Retrieve(p => p.anio == anio);
        //    }
        //    return Result;
        //}


        public tblHorario RetrieveHorarioByID(int id)
        {
            tblHorario Result = null;
            using (var r = new Repository<tblHorario>())
            {
                Result = r.Retrieve(p => p.idHorarios == id);
            }
            return Result;
        }

        public bool Update(tblHorario t)
        {
            bool Result = false;
            using (var r = new Repository<tblHorario>())
            {
                tblHorario ba = r.Retrieve(p => p.idHorarios == t.idHorarios
                && p.horaInicio == t.horaInicio
                && p.horaFinal == t.horaFinal);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el horario seleccionado."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblHorario obj = RetrieveHorarioByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblHorario>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El horario seleccionada no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblHorario> RetrieveAll()
        {
            List<tblHorario> Result = null;
            using (var r = new Repository<tblHorario>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
