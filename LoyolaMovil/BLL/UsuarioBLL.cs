using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class UsuarioBLL
    {
        public tblUsuario Create(tblUsuario t)
        {
            tblUsuario Result = null;
            using (var r = new Repository<tblUsuario>())
            {
                tblUsuario ba = r.Retrieve(p => p.idUsuario == t.idUsuario
                && p.nombreUsuario == t.nombreUsuario
                && p.apellidosUsuario == t.apellidosUsuario
                && p.correoUsuarios == t.correoUsuarios
                && p.contraseniaUsuario == t.contraseniaUsuario
                && p.idNivel == t.idNivel);


                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El usuario ya existe."));
                }
            }
            return Result;
        }


        public tblUsuario RetrieveUsuarioByID(int id)
        {
            tblUsuario Result = null;
            using (var r = new Repository<tblUsuario>())
            {
                Result = r.Retrieve(p => p.idUsuario == id);
            }

            return Result;
        }

        public bool Update(tblUsuario t)
        {
            bool Result = false;
            using (var r = new Repository<tblUsuario>())
            {
                tblUsuario ba = r.Retrieve( p=> p.idUsuario == t.idUsuario
                && p.nombreUsuario == t.nombreUsuario
                && p.apellidosUsuario == t.apellidosUsuario
                && p.correoUsuarios == t.correoUsuarios
                && p.contraseniaUsuario == t.contraseniaUsuario
                && p.idNivel == t.idNivel);

                if (ba == null)
                {
                    Result = r.Update(t);
                }
                else
                {
                    throw (new Exception("No se pudo actualizar el usuario seleccionada."));
                }
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            tblUsuario obj = RetrieveUsuarioByID(id);

            if (obj != null)
            {
                using (var r = new Repository<tblUsuario>())
                {
                    Result = r.Delete(obj);
                }
            }
            else
            {
                throw (new Exception("El usuario seleccionado no se pudo eliminar."));
            }

            return Result;
        }

        public List<tblUsuario> RetrieveAll()
        {
            List<tblUsuario> Result = null;
            using (var r = new Repository<tblUsuario>())
            {
                Result = r.RetrieveAll();
            }

            return Result;
        }

        public tblUsuario ValidarUsuarioContrasenia(string user, string pass)
        {
            tblUsuario Result = null;
            using (var r = new Repository<tblUsuario>())
            {
                Result = r.Retrieve(p => p.correoUsuarios == user && p.contraseniaUsuario == pass);
            }

            return Result;

        }
    }
}
