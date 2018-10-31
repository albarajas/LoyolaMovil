using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
namespace BLL
{
    public class AulaBLL
    {
        public tblAula Create(tblAula t)
        {
            tblAula Result = null;
            using (var r = new Repository<tblAula>())
            {
                tblAula ba = r.Retrieve(p => p.nombreAula == t.nombreAula
                && p.idTipoAula == t.idTipoAula
                && p.idEdificio == t.idEdificio
                && p.idAula == t.idAula);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El aula ya existe."));
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


        public tblAula RetrieveAulaByID(int id)
        {
            tblAula Result = null;
            using (var r = new Repository<tblAula>())
            {
                Result = r.Retrieve(p => p.idAula == id);
            }
            return Result;
        }

        public bool Update(tblAula t)
        {
            bool Result = false;
            using (var r = new Repository<tblAula>())
            {
                tblAula ba = r.Retrieve(p => p.nombreAula == t.nombreAula
                && p.idTipoAula == t.idTipoAula
                && p.idAula == t.idAula && p.idEdificio != t.idEdificio);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el aula seleccionada."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblAula obj = RetrieveAulaByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblAula>())
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

        public List<tblAula> RetrieveAulaEdificioByID(int id)
        {
            List<tblAula> Result = null;
            using (var r = new Repository<tblAula>())
            {
                Result = r.Filter(p => p.idEdificio == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public List<tblAula> RetrieveAulaTipoAulaByID(int id)
        {
            List<tblAula> Result = null;
            using (var r = new Repository<tblAula>())
            {
                Result = r.Filter(p => p.idTipoAula == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public List<tblAula> RetrieveAll()
        {
            List<tblAula> Result = null;
            using (var r = new Repository<tblAula>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
