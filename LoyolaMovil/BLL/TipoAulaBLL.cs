using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class TipoAulaBLL
    {
        public tblTipoAula Create(tblTipoAula t)
        {
            tblTipoAula Result = null;
            using (var r = new Repository<tblTipoAula>())
            {
                tblTipoAula ba = r.Retrieve(p => p.tipoAula == t.tipoAula);

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


        public tblTipoAula RetrieveByTipoAulaTexto(string tipoAula)
        {
            tblTipoAula Result = null;
            using (var r = new Repository<tblTipoAula>())
            {
                Result = r.Retrieve(p => p.tipoAula == tipoAula);
            }
            return Result;
        }


        public tblTipoAula RetrieveTipoAulaByID(int id)
        {
            tblTipoAula Result = null;
            using (var r = new Repository<tblTipoAula>())
            {
                Result = r.Retrieve(p => p.idTipoAula == id);
            }
            return Result;
        }

        public bool Update(tblTipoAula a)
        {
            bool Result = false;
            using (var r = new Repository<tblTipoAula>())
            {
                tblTipoAula ba = r.Retrieve(p => p.tipoAula == a.tipoAula && p.idTipoAula != a.idTipoAula);

                if (ba == null)
                {
                    Result = r.Update(a);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el tipo de aula"));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblTipoAula obj = RetrieveTipoAulaByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblTipoAula>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El tipo de aula seleccionado no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblTipoAula> RetrieveAll()
        {
            List<tblTipoAula> Result = null;
            using (var r = new Repository<tblTipoAula>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}
