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
public static class Sport_2Assembler
{
public static Sport_2DTOA Convert (SportEN en, NHibernate.ISession session = null)
{
        Sport_2DTOA dto = null;
        Sport_2RESTCAD sport_2RESTCAD = null;
        SportCEN sportCEN = null;
        SportCP sportCP = null;

        if (en != null) {
                dto = new Sport_2DTOA ();
                sport_2RESTCAD = new Sport_2RESTCAD (session);
                sportCEN = new SportCEN (sport_2RESTCAD);
                sportCP = new SportCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Name = en.Name;

                //
                // TravesalLink

                /* Rol: Sport_2 o--> Competition */
                dto.GetAllCompetitionOfSport = null;
                List<CompetitionEN> GetAllCompetitionOfSport = sport_2RESTCAD.GetAllCompetitionOfSport (en.Id).ToList ();
                if (GetAllCompetitionOfSport != null) {
                        dto.GetAllCompetitionOfSport = new List<CompetitionDTOA>();
                        foreach (CompetitionEN entry in GetAllCompetitionOfSport)
                                dto.GetAllCompetitionOfSport.Add (CompetitionAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
