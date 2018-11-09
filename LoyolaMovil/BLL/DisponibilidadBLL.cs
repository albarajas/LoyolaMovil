using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
 
namespace BLL
{
    public class DisponibilidadBLL
    {
        public tblDisponibilidad Create(tblDisponibilidad t)
        {
            tblDisponibilidad Result = null;
            using (var r = new Repository<tblDisponibilidad>())
            {
                tblDisponibilidad ba = r.Retrieve(p => p.DiasDisponibles == t.DiasDisponibles
                && p.semanaDisponibles == t.semanaDisponibles
                && p.idColaborador == t.idColaborador
                && p.idAnioMes == t.idAnioMes
                && p.idDisponibilidad == t.idDisponibilidad);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("La cita ya existe."));
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


        public tblDisponibilidad RetrieveDisponibilidadByID(int id)
        {
            tblDisponibilidad Result = null;
            using (var r = new Repository<tblDisponibilidad>())
            {
                Result = r.Retrieve(p => p.idDisponibilidad == id);
            }
            return Result;
        }

        public bool Update(tblDisponibilidad t)
        {
            bool Result = false;
            using (var r = new Repository<tblDisponibilidad>())
            {
                tblDisponibilidad ba = r.Retrieve(p => p.DiasDisponibles == t.DiasDisponibles
                && p.semanaDisponibles  == t.semanaDisponibles
                && p.idColaborador == t.idColaborador 
                && p.idAnioMes == t.idAnioMes
                && p.idDisponibilidad != t.idDisponibilidad);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar la cita seleccionada."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblDisponibilidad obj = RetrieveDisponibilidadByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblDisponibilidad>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("La cita seleccionada no se pudo eliminar."));
            }

            return Result;
        }


        public List<tblDisponibilidad> RetrieveAll()
        {
            List<tblDisponibilidad> Result = null;
            using (var r = new Repository<tblDisponibilidad>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}