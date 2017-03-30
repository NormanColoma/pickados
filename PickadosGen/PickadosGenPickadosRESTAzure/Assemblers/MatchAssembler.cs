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
public static class MatchAssembler
{
public static MatchDTOA Convert (MatchEN en, NHibernate.ISession session = null)
{
        MatchDTOA dto = null;
        MatchRESTCAD matchRESTCAD = null;
        MatchCEN matchCEN = null;
        MatchCP matchCP = null;

        if (en != null) {
                dto = new MatchDTOA ();
                matchRESTCAD = new MatchRESTCAD (session);
                matchCEN = new MatchCEN (matchRESTCAD);
                matchCP = new MatchCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Date = en.Date;
                dto.Stadium = en.Stadium;

                //
                // TravesalLink

                /* Rol: Match o--> Team */
                dto.GetHomeOfEvent_home = TeamAssembler.Convert (en.Home, session);

                /* Rol: Match o--> Team */
                dto.GetAwayOfEvent_away = TeamAssembler.Convert (en.Away, session);


                //
                // Service
        }

        return dto;
}
}
}
