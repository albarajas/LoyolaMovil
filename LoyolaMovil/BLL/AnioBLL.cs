using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class AnioBLL
    {
        public tblAnio Create(tblAnio t)
        {
            tblAnio Result = null;
            using (var r = new Repository<tblAnio>())
            {
                tblAnio ba = r.Retrieve(p => p.anio == t.anio);

                if (ba == null)
                {
                    Result = r.Create(t);
                }
                else
                {
                    throw (new Exception("El año ya existe."));
                }
            }
            return Result;
        }
    }
}
