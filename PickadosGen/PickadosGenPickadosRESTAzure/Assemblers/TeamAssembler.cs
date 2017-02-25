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
public static class TeamAssembler
{
public static TeamDTOA Convert (TeamEN en, NHibernate.ISession session = null)
{
        TeamDTOA dto = null;
        TeamRESTCAD teamRESTCAD = null;
        TeamCEN teamCEN = null;
        TeamCP teamCP = null;

        if (en != null) {
                dto = new TeamDTOA ();
                teamRESTCAD = new TeamRESTCAD (session);
                teamCEN = new TeamCEN (teamRESTCAD);
                teamCP = new TeamCP (session);


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
