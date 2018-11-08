using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class CitaBLL
    {
        public tblCita Create(tblCita t)
        {
            tblCita Result = null;
            using (var r = new Repository<tblCita>())
            {
                tblCita ba = r.Retrieve(p => p.idColaborador == t.idColaborador
                && p.idHorario == t.idHorario
                && p.idSemanas == t.idSemanas
                && p.idDias == t.idDias
                && p.idCita == t.idCita);

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


        public tblCita RetrieveCitaByID(int id)
        {
            tblCita Result = null;
            using (var r = new Repository<tblCita>())
            {
                Result = r.Retrieve(p => p.idCita == id);
            }
            return Result;
        }

        public bool Update(tblCita t)
        {
            bool Result = false;
            using (var r = new Repository<tblCita>())
            {
                tblCita ba = r.Retrieve(p => p.idColaborador == t.idColaborador
                && p.idHorario == t.idHorario
                && p.idSemanas == t.idSemanas
                && p.idDias == t.idDias
                && p.idCita != t.idCita);

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
            tblCita obj = RetrieveCitaByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblCita>())
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

        public List<tblCita> RetrieveCitasColaboradorByID(int id)
        {
            List<tblCita> Result = null;
            using (var r = new Repository<tblCita>())
            {
                Result = r.Filter(p => p.idColaborador == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public List<tblCita> RetrieveCitaDiaByID(int id)
        {
            List<tblCita> Result = null;
            using (var r = new Repository<tblCita>())
            {
                Result = r.Filter(p => p.idCita == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public List<tblCita> RetrieveCitasSemanaByID(int id)
        {
            List<tblCita> Result = null;
            using (var r = new Repository<tblCita>())
            {
                Result = r.Filter(p => p.idCita == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }










        public List<tblCita> RetrieveAll()
        {
            List<tblCita> Result = null;
            using (var r = new Repository<tblCita>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
