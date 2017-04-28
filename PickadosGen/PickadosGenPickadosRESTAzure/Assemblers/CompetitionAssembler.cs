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
public static class CompetitionAssembler
{
public static CompetitionDTOA Convert (CompetitionEN en, NHibernate.ISession session = null)
{
        CompetitionDTOA dto = null;
        CompetitionRESTCAD competitionRESTCAD = null;
        CompetitionCEN competitionCEN = null;
        CompetitionCP competitionCP = null;

        if (en != null) {
                dto = new CompetitionDTOA ();
                competitionRESTCAD = new CompetitionRESTCAD (session);
                competitionCEN = new CompetitionCEN (competitionRESTCAD);
                competitionCP = new CompetitionCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Name = en.Name;
                dto.Place = en.Place;

                //
                // TravesalLink

                /* Rol: Competition o--> Match */
                dto.GetAllEventOfCompetition = null;
                List<MatchEN> GetAllEventOfCompetition = competitionRESTCAD.GetAllEventOfCompetition (en.Id).ToList ();
                if (GetAllEventOfCompetition != null) {
                        dto.GetAllEventOfCompetition = new List<MatchDTOA>();
                        foreach (MatchEN entry in GetAllEventOfCompetition)
                                dto.GetAllEventOfCompetition.Add (MatchAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
