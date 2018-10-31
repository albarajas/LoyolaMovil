using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
  public class Area_ServiciosBLL
    {
        public tblAreas_Servicios Create(tblAreas_Servicios t)
        {
            tblAreas_Servicios Result = null;
            using (var r = new Repository<tblAreas_Servicios>())
            {
                tblAreas_Servicios ba = r.Retrieve(p => p.idServicios == t.idServicios
                && p.serviciosNombre == t.serviciosNombre
                && p.idArea == t.idArea
                && p.nombreArea == t.nombreArea);

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


        public tblAreas_Servicios RetrieveArea_ServicioByID(int id)
        {
            tblAreas_Servicios Result = null;
            using (var r = new Repository<tblAreas_Servicios>())
            {
                Result = r.Retrieve(p => p.idServicios == id);
            }
            return Result;
        }

        public List<tblAreas_Servicios> RetrieveAreas_ServicioAreaByID(int id)
        {
            List<tblAreas_Servicios> Result = null;
            using (var r = new Repository<tblAreas_Servicios>())
            {
                Result = r.Filter(p => p.idArea == id);
                //select * from tblEventos Where idColaborador == id
            }
            return Result;
        }

        public bool Update(tblAreas_Servicios t)
        {
            bool Result = false;
            using (var r = new Repository<tblAreas_Servicios>())
            {
                tblAreas_Servicios ba = r.Retrieve(p => p.idServicios == t.idServicios
                && p.serviciosNombre == t.serviciosNombre
                && p.idArea == t.idArea
                && p.nombreArea == t.nombreArea);

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
            tblAreas_Servicios obj = RetrieveArea_ServicioByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblAreas_Servicios>())
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

        public List<tblAreas_Servicios> RetrieveAll()
        {
            List<tblAreas_Servicios> Result = null;
            using (var r = new Repository<tblAreas_Servicios>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
