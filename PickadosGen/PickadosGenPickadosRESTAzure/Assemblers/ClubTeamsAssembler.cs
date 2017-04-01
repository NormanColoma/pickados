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
public static class ClubTeamsAssembler
{
public static ClubTeamsDTOA Convert (TeamEN en, NHibernate.ISession session = null)
{
        ClubTeamsDTOA dto = null;
        ClubTeamsRESTCAD clubTeamsRESTCAD = null;
        TeamCEN teamCEN = null;
        TeamCP teamCP = null;

        if (en != null) {
                dto = new ClubTeamsDTOA ();
                clubTeamsRESTCAD = new ClubTeamsRESTCAD (session);
                teamCEN = new TeamCEN (clubTeamsRESTCAD);
                teamCP = new TeamCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Name = en.Name;
                dto.Country = en.Country;

                //
                // TravesalLink

                /* Rol: ClubTeams o--> Player */
                dto.GetAllClub_playerOfClub_team = null;
                List<PlayerEN> GetAllClub_playerOfClub_team = clubTeamsRESTCAD.GetAllClub_playerOfClub_team (en.Id).ToList ();
                if (GetAllClub_playerOfClub_team != null) {
                        dto.GetAllClub_playerOfClub_team = new List<PlayerDTOA>();
                        foreach (PlayerEN entry in GetAllClub_playerOfClub_team)
                                dto.GetAllClub_playerOfClub_team.Add (PlayerAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
