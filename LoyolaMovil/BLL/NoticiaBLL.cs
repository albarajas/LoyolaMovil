using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class NoticiaBLL
    {
        public tblNoticia Create(tblNoticia t)
        {
            tblNoticia Result = null;
            using (var r = new Repository<tblNoticia>())
            {
                tblNoticia ba = r.Retrieve(p => p.noticiasTitulo == t.noticiasTitulo
                && p.noticiasTexto == t.noticiasTexto
                && p.idNivel == t.idNivel
                && p.idNoticias == t.idNoticias);


                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("La noticia ya existe."));
                }
            }
            return Result;
        }


        public tblNoticia RetrieveNoticiaByID(int id)
        {
            tblNoticia Result = null;
            using (var r = new Repository<tblNoticia>())
            {
                Result = r.Retrieve(p => p.idNoticias == id);
            }

            return Result;
        }

        public bool Update(tblNoticia t)
        {
            bool Result = false;
            using (var r = new Repository<tblNoticia>())
            {
                tblNoticia ba = r.Retrieve(p => p.noticiasTitulo == t.noticiasTitulo
                && p.noticiasTexto == t.noticiasTexto
                && p.idNoticias == t.idNoticias
                && p.idNivel == t.idNivel);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar la noticia seleccionada."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblNoticia obj = RetrieveNoticiaByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblNoticia>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El colaborador seleccionado no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblNoticia> RetrieveAll()
        {
            List<tblNoticia> Result = null;
            using (var r = new Repository<tblNoticia>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }
    }
}

