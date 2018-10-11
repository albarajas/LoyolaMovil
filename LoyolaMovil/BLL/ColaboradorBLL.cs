using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class ColaboradorBLL
    {
        public tblColaboradore Create(tblColaboradore t)
        {
            tblColaboradore Result = null;
            using (var r = new Repository<tblColaboradore>())
            {
                tblColaboradore ba = r.Retrieve(p => p.nombreColaborador == t.nombreColaborador
                && p.telefonoColaborador == t.telefonoColaborador
                && p.correoColaborador == t.correoColaborador
                && p.horarioInicio == t.horarioInicio
                && p.horaFin == t.horaFin
                && p.contraseniaColaborador == t.contraseniaColaborador
                && p.idColaborador == t.idColaborador);


                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El colaborador ya existe."));
                }
            }
            return Result;
        }


        public tblColaboradore RetrieveColaboradorByID(int id)
        {
            tblColaboradore Result = null;
            using (var r = new Repository<tblColaboradore>())
            {
                Result = r.Retrieve(p => p.idColaborador == id);
            }

            return Result;
        }

        public bool Update(tblColaboradore t)
        {
            bool Result = false;
            using (var r = new Repository<tblColaboradore>())
            {
                tblColaboradore ba = r.Retrieve(p => p.nombreColaborador == t.nombreColaborador
                && p.telefonoColaborador == t.telefonoColaborador
                && p.correoColaborador == t.correoColaborador
                && p.horarioInicio == t.horarioInicio
                && p.horaFin == t.horaFin
                && p.contraseniaColaborador == t.contraseniaColaborador
                && p.idColaborador != t.idColaborador);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el colaborador seleccionada."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblColaboradore obj = RetrieveColaboradorByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblColaboradore>())
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

        public List<tblColaboradore> RetrieveAll()
        {
            List<tblColaboradore> Result = null;
            using (var r = new Repository<tblColaboradore>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }

        public tblColaboradore ValidarUsuarioContrasenia(string user, string pass)
        {
            tblColaboradore Result = null;
            using (var r = new Repository<tblColaboradore>())
            {
                Result = r.Retrieve(p => p.correoColaborador == user && p.contraseniaColaborador == pass);
            }

            return Result;

        }
    }
}
