using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class ServiciosBLL
    {
        public tblServicio Create(tblServicio t)
        {
            tblServicio Result = null;
            using (var r = new Repository<tblServicio>())
            {
                tblServicio ba = r.Retrieve(p => p.idservicios != t.idservicios
                && p.serviciosNombre == t.serviciosNombre
                && p.idArea == t.idArea);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El servicio ya existe."));
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


        public tblServicio RetrieveServicioByID(int id)
        {
            tblServicio Result = null;
            using (var r = new Repository<tblServicio>())
            {
                Result = r.Retrieve(p => p.idservicios == id);
            }
            return Result;
        }

        public List<tblServicio> RetrieveServicioAreaByID(int id)
        {
            List<tblServicio> Result = null;
            using (var r = new Repository<tblServicio>())
            {
                Result = r.Filter(p => p.idArea == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public bool Update(tblServicio t)
        {
            bool Result = false;
            using (var r = new Repository<tblServicio>())
            {
                tblServicio ba = r.Retrieve(p => p.idservicios == t.idservicios
                && p.serviciosNombre == t.serviciosNombre
                && p.idArea == t.idArea);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el servicio seleccionado."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblServicio obj = RetrieveServicioByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblServicio>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El servicio seleccionada no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblServicio> RetrieveAll()
        {
            List<tblServicio> Result = null;
            using (var r = new Repository<tblServicio>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
