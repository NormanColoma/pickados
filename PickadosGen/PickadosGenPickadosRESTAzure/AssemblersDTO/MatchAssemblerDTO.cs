using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class MatchAssemblerDTO {
public static IList<MatchEN> ConvertList (IList<MatchDTO> lista)
{
        IList<MatchEN> result = new List<MatchEN>();
        foreach (MatchDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static MatchEN Convert (MatchDTO dto)
{
        MatchEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new MatchEN ();



                        if (dto.Away_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ITeamCAD teamCAD = new PickadosGenNHibernate.CAD.Pickados.TeamCAD ();

                                newinstance.Away = teamCAD.ReadOIDDefault (dto.Away_oid);
                        }
                        if (dto.Home_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ITeamCAD teamCAD = new PickadosGenNHibernate.CAD.Pickados.TeamCAD ();

                                newinstance.Home = teamCAD.ReadOIDDefault (dto.Home_oid);
                        }
                        newinstance.Stadium = dto.Stadium;
                        newinstance.Id = dto.Id;
                        if (dto.Competition_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ICompetitionCAD competitionCAD = new PickadosGenNHibernate.CAD.Pickados.CompetitionCAD ();

                                newinstance.Competition = competitionCAD.ReadOIDDefault (dto.Competition_oid);
                        }

                        if (dto.Pick_rel != null) {
                                PickadosGenNHibernate.CAD.Pickados.IPickCAD pickCAD = new PickadosGenNHibernate.CAD.Pickados.PickCAD ();

                                newinstance.Pick_rel = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
                                foreach (PickDTO entry in dto.Pick_rel) {
                                        newinstance.Pick_rel.Add (PickAssemblerDTO.Convert (entry));
                                }
                        }
                        newinstance.Date = dto.Date;
                        if (dto.Round_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.IRoundCAD roundCAD = new PickadosGenNHibernate.CAD.Pickados.RoundCAD ();

                                newinstance.Round = roundCAD.ReadOIDDefault (dto.Round_oid);
                        }
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
