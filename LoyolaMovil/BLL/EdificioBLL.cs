using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class EdificioBLL
    {
        public tblEdificio Create(tblEdificio t)
        {
            tblEdificio Result = null;
            using (var r = new Repository<tblEdificio>())
            {
                tblEdificio ba = r.Retrieve(p => p.nombreEdificio == t.nombreEdificio);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El edificio ya existe."));
                }
            }
            return Result;
        }


        public tblEdificio RetrieveByEdificioTexto(string nombreEdificio)
        {
            tblEdificio Result = null;
            using (var r = new Repository<tblEdificio>())
            {
                Result = r.Retrieve(p => p.nombreEdificio == nombreEdificio);
            }
            return Result;
        }


        public tblEdificio RetrieveEdificioByID(int id)
        {
            tblEdificio Result = null;
            using (var r = new Repository<tblEdificio>())
            {
                Result = r.Retrieve(p => p.idEdificio == id);
            }
            return Result;
        }

        public bool Update(tblEdificio a)
        {
            bool Result = false;
            using (var r = new Repository<tblEdificio>())
            {
                tblEdificio ba = r.Retrieve(p => p.nombreEdificio == a.nombreEdificio && p.idEdificio != a.idEdificio);

                if (ba == null)
                {
                    Result = r.Update(a);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el edificio"));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblEdificio obj = RetrieveEdificioByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblEdificio>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El edificio seleccionado no se pudo eliminar."));
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


        public List<tblEdificio> RetrieveAll()
        {
            List<tblEdificio> Result = null;
            using (var r = new Repository<tblEdificio>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
