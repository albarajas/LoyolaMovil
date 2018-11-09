using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
   public class NivelBLL
    {
        public tblNivel Create(tblNivel t)
        {
            tblNivel Result = null;
            using (var r = new Repository<tblNivel>())
            {
                tblNivel ba = r.Retrieve(p => p.idNivel == t.idNivel
                && p.nivelNombre == t.nivelNombre);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El nivel ya existe."));
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


        public tblNivel RetrieveNivelByID(int id)
        {
            tblNivel Result = null;
            using (var r = new Repository<tblNivel>())
            {
                Result = r.Retrieve(p => p.idNivel == id);
            }
            return Result;
        }

        public bool Update(tblNivel t)
        {
            bool Result = false;
            using (var r = new Repository<tblNivel>())
            {
                tblNivel ba = r.Retrieve(p => p.idNivel == t.idNivel
                && p.nivelNombre == t.nivelNombre);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el nivel seleccionado."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblNivel obj = RetrieveNivelByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblNivel>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El nivel seleccionada no se pudo eliminar."));
            }

            return Result;
        }


        public List<tblEdificio> RetrieveNivelEdificioByID(int id)
        {
            List<tblEdificio> Result = null;
            using (var r = new Repository<tblEdificio>())
            {
                Result = r.Filter(p => p.idEdificio == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public List<tblNivel> RetrieveAll()
        {
            List<tblNivel> Result = null;
            using (var r = new Repository<tblNivel>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
        public List<tblNivel> RetrieveNoticiasNivelByID(int id)
        {
            List<tblNivel> Result = null;
            using (var r = new Repository<tblNivel>())
            {
                Result = r.Filter(p => p.idNivel == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }
    }
}
