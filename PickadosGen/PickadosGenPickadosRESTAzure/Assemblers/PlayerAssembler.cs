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
public static class PlayerAssembler
{
public static PlayerDTOA Convert (PlayerEN en, NHibernate.ISession session = null)
{
        PlayerDTOA dto = null;
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;
        PlayerCP playerCP = null;

        if (en != null) {
                dto = new PlayerDTOA ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);
                playerCP = new PlayerCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Name = en.Name;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
