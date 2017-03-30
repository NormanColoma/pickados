using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using PickadosGenPickadosRESTAzure.DTOA;
using PickadosGenPickadosRESTAzure.CAD;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CP.Pickados;

namespace PickadosGenPickadosRESTAzure.Assemblers
{
public static class UsuarioAssembler
{
public static UsuarioDTOA Convert (UsuarioEN en, NHibernate.ISession session = null)
{
        UsuarioDTOA dto = null;
        UsuarioRESTCAD usuarioRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        UsuarioCP usuarioCP = null;

        if (en != null) {
                dto = new UsuarioDTOA ();
                usuarioRESTCAD = new UsuarioRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioRESTCAD);
                usuarioCP = new UsuarioCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Nif = en.Nif;
                dto.Email = en.Email;
                dto.Alias = en.Alias;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
