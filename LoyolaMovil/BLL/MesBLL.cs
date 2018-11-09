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
        public tblMes Create(tblMes t)
        {
            tblMes Result = null;
            using (var r = new Repository<tblMes>())
            {
                tblMes ba = r.Retrieve(p => p.mes == t.mes
                && p.fechaInicial == t.fechaInicial
                && p.fechaFinal == t.fechaFinal
                && p.idAnioMes == t.idAnioMes
                && p.idMes == t.idMes);

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


        public tblMes RetrieveMesByID(int id)
        {
            tblMes Result = null;
            using (var r = new Repository<tblMes>())
            {
                Result = r.Retrieve(p => p.idMes == id);
            }
            return Result;
        }

        public bool Update(tblMes t)
        {
            bool Result = false;
            using (var r = new Repository<tblMes>())
            {
                tblMes ba = r.Retrieve(p => p.mes == t.mes
                && p.fechaInicial == t.fechaInicial
                && p.fechaFinal == t.fechaFinal
                && p.idAnioMes == t.idAnioMes
                && p.idMes != t.idMes);

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
            tblSemana obj = RetrieveMesByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblMes>())
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


        public List<tblMes> RetrieveAll()
        {
            List<tblMes> Result = null;
            using (var r = new Repository<tblMes>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
        public List<tblMes> RetrieveMesAnioByID(int id)
        {
            List<tblMes> Result = null;
            using (var r = new Repository<tblMes>())
            {
                Result = r.Filter(p => p.idAnio == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }
    }
}