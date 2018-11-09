using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class AnioMesBLL
    {
        public tblAnioMe Create(tblAnioMe t)
        {
            tblAnioMe Result = null;
            using (var r = new Repository<tblAnioMe>())
            {
                tblAnioMe ba = r.Retrieve(p => p.idMes == t.idMes
                && p.idAnio == t.idAnio
                && p.idAnioMes == t.idAnioMes);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El mes ya existe."));
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


        public tblAnioMe RetrieveAnioMesByID(int id)
        {
            tblAnioMe Result = null;
            using (var r = new Repository<tblAnioMe>())
            {
                Result = r.Retrieve(p => p.idAnioMes == id);
            }
            return Result;
        }

        public bool Update(tblAnioMe t)
        {
            bool Result = false;
            using (var r = new Repository<tblAnioMe>())
            {
                tblAnioMe ba = r.Retrieve(p => p.idAnio == t.idAnio
                && p.idMes == t.idMes
                && p.idAnioMes != t.idAnioMes);

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
            tblAnioMe obj = RetrieveAnioMesByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblAnioMe>())
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

        public List<tblAnioMe> RetrieveAll()
        {
            List<tblAnioMe> Result = null;
            using (var r = new Repository<tblAnioMe>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}