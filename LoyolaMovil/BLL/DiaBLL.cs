using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class DiaBLL
    {
        public tblDías Create(tblDías t)
        {
            tblDías Result = null;
            using (var r = new Repository<tblDías>())
            {
                tblDías ba = r.Retrieve(p => p.idDias == t.idDias
                && p.dia == t.dia);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El día ya existe."));
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


        public tblDías RetrieveDiaByID(int id)
        {
            tblDías Result = null;
            using (var r = new Repository<tblDías>())
            {
                Result = r.Retrieve(p => p.idDias == id);
            }
            return Result;
        }

        public bool Update(tblDías t)
        {
            bool Result = false;
            using (var r = new Repository<tblDías>())
            {
                tblDías ba = r.Retrieve(p => p.idDias == t.idDias
                && p.dia == t.dia);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el día seleccionado."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblDías obj = RetrieveDiaByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblDías>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El día seleccionada no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblDías> RetrieveAll()
        {
            List<tblDías> Result = null;
            using (var r = new Repository<tblDías>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
