using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class EventoBLL
    {
        public tblEvento Create(tblEvento t)
        {
            tblEvento Result = null;
            using (var r = new Repository<tblEvento>())
            {
                tblEvento ba = r.Retrieve(p => p.nombreEvento == t.nombreEvento
                && p.descripcionEvento == t.descripcionEvento
                && p.fechaEvento == t.fechaEvento
                && p.horaInicio == t.horaInicio
                && p.horaFinal == t.horaFinal
                && p.idAula == t.idAula
                && p.idColaborador ==  t.idColaborador
                && p.idNivel == t.idNivel
                && p.idEvento == t.idEvento);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El evento ya existe."));
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


        public tblEvento RetrievEventoByID(int id)
        {
            tblEvento Result = null;
            using (var r = new Repository<tblEvento>())
            {
                Result = r.Retrieve(p => p.idEvento == id);
            }
            return Result;
        }

        public List<tblEvento> RetrieveEventosColaboradorByID(int id)
        {
            List<tblEvento> Result = null;
            using (var r = new Repository<tblEvento>())
            {
                Result = r.Filter(p => p.idColaborador == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public List<tblEvento> RetrieveEventosAulaByID(int id)
        {
            List<tblEvento> Result = null;
            using (var r = new Repository<tblEvento>())
            {
                Result = r.Filter(p => p.idAula == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }


        public List<tblEvento> RetrieveEventoNivelByID(int id)
        {
            List<tblEvento> Result = null;
            using (var r = new Repository<tblEvento>())
            {
                Result = r.Filter(p => p.idNivel == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }


        public bool Update(tblEvento t)
        {
            bool Result = false;
            using (var r = new Repository<tblEvento>())
            {
                tblEvento ba = r.Retrieve(p => p.nombreEvento == t.nombreEvento
                && p.descripcionEvento  == t.descripcionEvento
                && p.fechaEvento == t.fechaEvento 
                && p.horaInicio == t.horaInicio
                && p.horaFinal == t.horaFinal
                && p.idAula == t.idAula
                && p.idColaborador == t.idColaborador
                && p.idNivel == t.idNivel 
                );

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el evento seleccionado."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblEvento obj = RetrievEventoByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblEvento>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El aula seleccionada no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblEvento> RetrieveAll()
        {
            List<tblEvento> Result = null;
            using (var r = new Repository<tblEvento>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
