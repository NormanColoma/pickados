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
public static class NationalTeamAssembler
{
public static NationalTeamDTOA Convert (TeamEN en, NHibernate.ISession session = null)
{
        NationalTeamDTOA dto = null;
        NationalTeamRESTCAD nationalTeamRESTCAD = null;
        TeamCEN teamCEN = null;
        TeamCP teamCP = null;

        if (en != null) {
                dto = new NationalTeamDTOA ();
                nationalTeamRESTCAD = new NationalTeamRESTCAD (session);
                teamCEN = new TeamCEN (nationalTeamRESTCAD);
                teamCP = new TeamCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Name = en.Name;
                dto.Country = en.Country;

                //
                // TravesalLink

                /* Rol: NationalTeam o--> Player */
                dto.GetAllNational_playerOfNational_team = null;
                List<PlayerEN> GetAllNational_playerOfNational_team = nationalTeamRESTCAD.GetAllNational_playerOfNational_team (en.Id).ToList ();
                if (GetAllNational_playerOfNational_team != null) {
                        dto.GetAllNational_playerOfNational_team = new List<PlayerDTOA>();
                        foreach (PlayerEN entry in GetAllNational_playerOfNational_team)
                                dto.GetAllNational_playerOfNational_team.Add (PlayerAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
