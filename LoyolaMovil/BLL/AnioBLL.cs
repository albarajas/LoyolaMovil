using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class AnioBLL
    {
        public tblAnio Create(tblAnio t)
        {
            tblAnio Result = null;
            using (var r = new Repository<tblAnio>())
            {
                tblAnio ba = r.Retrieve(p => p.anio == t.anio);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El año ya existe."));
                }
            }
            return Result;
        }


        public tblAnio RetrieveByAnioTexto(DateTime anio)
        {
            tblAnio Result = null;
            using (var r = new Repository<tblAnio>())
            {
                Result = r.Retrieve(p => p.anio == anio);
            }
            return Result;
        }


        public tblAnio RetrieveAnioByID(int id)
        {
            tblAnio Result = null;
            using (var r = new Repository<tblAnio>())
            {
                Result = r.Retrieve(p => p.idAnio == id);
            }
            return Result;
        }

        public bool Update(tblAnio a)
        {
            bool Result = false;
            using (var r = new Repository<tblAnio>())
            {
                tblAnio ba = r.Retrieve(p => p.anio == a.anio && p.idAnio != a.idAnio);

                if (ba == null)
                {
                    Result = r.Update(a);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el año"));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblAnio obj = RetrieveAnioByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblAnio>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El año seleccionado no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblAnio> RetrieveAll()
        {
            List<tblAnio> Result = null;
            using (var r = new Repository<tblAnio>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
