using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class AreasBLL
    {
        public tblArea Create(tblArea t)
        {
            tblArea Result = null;
            using (var r = new Repository<tblArea>())
            {
                tblArea ba = r.Retrieve(p => p.nombreArea == t.nombreArea 
                && p.horaInicio == t.horaInicio 
                && p.horaFinal == t.horaFinal 
                && p.idColaborador == t.idColaborador 
                && p.idAula == t.idAula);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El area ya existe."));
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


        public tblArea RetrieveAreaByID(int id)
        {
            tblArea Result = null;
            using (var r = new Repository<tblArea>())
            {
                Result = r.Retrieve(p => p.idArea == id);
            }
            return Result;
        }

        public List<tblArea> RetrieveAreasColaboradorByID(int id)
        {
            List<tblArea> Result = null;
            using (var r = new Repository<tblArea>())
            {
                Result = r.Filter(p => p.idColaborador == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public bool Update(tblArea t)
        {
            bool Result = false;
            using (var r = new Repository<tblArea>())
            {
                tblArea ba = r.Retrieve(p => p.nombreArea == t.nombreArea
                && p.horaInicio == t.horaInicio
                && p.horaFinal == t.horaFinal
                && p.idColaborador == t.idColaborador
                && p.idAula == t.idAula && p.idArea != t.idArea);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el area seleccionada."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblArea obj = RetrieveAreaByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblArea>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El area seleccionada no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblArea> RetrieveAll()
        {
            List<tblArea> Result = null;
            using (var r = new Repository<tblArea>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
