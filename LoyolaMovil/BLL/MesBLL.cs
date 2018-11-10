using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class MesBLL
    {
        public tblMe Create(tblMe t)
        {
            tblMe Result = null;
            using (var r = new Repository<tblMe>())
            {
                tblMe ba = r.Retrieve(p => p.idMes== t.idMes
                && p.fechaInicial == t.fechaInicial
                && p.fechaFinal == t.fechaFinal
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


        public tblMe RetrieveMesByID(int id)
        {
            tblMe Result = null;
            using (var r = new Repository<tblMe>())
            {
                Result = r.Retrieve(p => p.idMes == id);
            }
            return Result;
        }

        public bool Update(tblMe t)
        {
            bool Result = false;
            using (var r = new Repository<tblMe>())
            {
                tblMe ba = r.Retrieve(p => p.Mes == t.Mes
                && p.fechaInicial == t.fechaInicial
                && p.fechaFinal == t.fechaFinal
                && p.idAnioMes == t.idAnioMes);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el mes seleccionado."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblMe obj = RetrieveMesByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblMe>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El mes seleccionada no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblMe> RetrieveAll()
        {
            List<tblMe> Result = null;
            using (var r = new Repository<tblMe>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }

        public List<tblMe> RetrieveAnioMesByID(int id)
        {
            List<tblMe> Result = null;
            using (var r = new Repository<tblMe>())
            {
                Result = r.Filter(p=>p.idAnioMes==id);
            }

            return Result;
        }
    }
}