using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class TeamAssemblerDTO {
public static IList<TeamEN> ConvertList (IList<TeamDTO> lista)
{
        IList<TeamEN> result = new List<TeamEN>();
        foreach (TeamDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static TeamEN Convert (TeamDTO dto)
{
        TeamEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new TeamEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Name = dto.Name;
                        newinstance.Country = dto.Country;
                        if (dto.Event_home_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IMatchCAD matchCAD = new PickadosGenNHibernate.CAD.Pickados.MatchCAD ();

                                newinstance.Event_home = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
                                foreach (int entry in dto.Event_home_oid) {
                                        newinstance.Event_home.Add (matchCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Event_away_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IMatchCAD matchCAD = new PickadosGenNHibernate.CAD.Pickados.MatchCAD ();

                                newinstance.Event_away = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
                                foreach (int entry in dto.Event_away_oid) {
                                        newinstance.Event_away.Add (matchCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Club_player_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IPlayerCAD playerCAD = new PickadosGenNHibernate.CAD.Pickados.PlayerCAD ();

                                newinstance.Club_player = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
                                foreach (int entry in dto.Club_player_oid) {
                                        newinstance.Club_player.Add (playerCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.National_player_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IPlayerCAD playerCAD = new PickadosGenNHibernate.CAD.Pickados.PlayerCAD ();

                                newinstance.National_player = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
                                foreach (int entry in dto.National_player_oid) {
                                        newinstance.National_player.Add (playerCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Competition_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.ICompetitionCAD competitionCAD = new PickadosGenNHibernate.CAD.Pickados.CompetitionCAD ();

                                newinstance.Competition = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.CompetitionEN>();
                                foreach (int entry in dto.Competition_oid) {
                                        newinstance.Competition.Add (competitionCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Club = dto.Club;
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
