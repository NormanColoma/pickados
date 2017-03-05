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
public static class SportAssembler
{
public static SportDTOA Convert (SportEN en, NHibernate.ISession session = null)
{
        SportDTOA dto = null;
        SportRESTCAD sportRESTCAD = null;
        SportCEN sportCEN = null;
        SportCP sportCP = null;

        if (en != null) {
                dto = new SportDTOA ();
                sportRESTCAD = new SportRESTCAD (session);
                sportCEN = new SportCEN (sportRESTCAD);
                sportCP = new SportCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Name = en.Name;

                //
                // TravesalLink

                /* Rol: Sport o--> Competition */
                dto.GetAllCompetitionOfSport = null;
                List<CompetitionEN> GetAllCompetitionOfSport = sportRESTCAD.GetAllCompetitionOfSport (en.Id).ToList ();
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
