using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class SemanasBLL
    {
        public tblSemana Create(tblSemana t)
        {
            tblSemana Result = null;
            using (var r = new Repository<tblSemana>())
            {
                tblSemana ba = r.Retrieve(p => p.semana == t.semana
                && p.fechaInicial == t.fechaInicial
                && p.fechaFinal == t.fechaFinal
                && p.idAnioSemana == t.idAnioSemana
                && p.idSemana == t.idSemana);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("La semana ya existe."));
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


        public tblSemana RetrieveSemanaByID(int id)
        {
            tblSemana Result = null;
            using (var r = new Repository<tblSemana>())
            {
                Result = r.Retrieve(p => p.idSemana == id);
            }
            return Result;
        }

        public bool Update(tblSemana t)
        {
            bool Result = false;
            using (var r = new Repository<tblSemana>())
            {
                tblSemana ba = r.Retrieve(p => p.semana == t.semana
                && p.fechaInicial == t.fechaInicial
                && p.fechaFinal == t.fechaFinal
                && p.idAnioSemana == t.idAnioSemana
                && p.idSemana != t.idSemana);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar la semana seleccionada."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblSemana obj = RetrieveSemanaByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblSemana>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("La Semanaseleccionada no se pudo eliminar"));
            }

            return Result;
        }


        public List<tblSemana> RetrieveAll()
        {
            List<tblSemana> Result = null;
            using (var r = new Repository<tblSemana>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
        public List<tblAnio> RetrieveSemanaAnioByID(int id)
        {
            List<tblAnio> Result = null;
            using (var r = new Repository<tblAnio>())
            {
                Result = r.Filter(p => p.idAnio == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }
    }
}