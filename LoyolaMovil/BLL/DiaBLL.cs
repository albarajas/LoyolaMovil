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
        public tblDia Create(tblDia t)
        {
            tblDia Result = null;
            using (var r = new Repository<tblDia>())
            {
                tblDia ba = r.Retrieve(p => p.idDias == t.idDias
                && p.dia == t.dia);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El dia ya existe."));
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


        public tblDia RetrieveDiaByID(int id)
        {
            tblDia Result = null;
            using (var r = new Repository<tblDia>())
            {
                Result = r.Retrieve(p => p.idDias == id);
            }
            return Result;
        }

        public bool Update(tblDia t)
        {
            bool Result = false;
            using (var r = new Repository<tblDia>())
            {
                tblDia ba = r.Retrieve(p => p.idDias == t.idDias
                && p.dia == t.dia);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el dia seleccionado."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblDia obj = RetrieveDiaByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblDia>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El dia seleccionada no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblDia> RetrieveAll()
        {
            List<tblDia> Result = null;
            using (var r = new Repository<tblDia>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
