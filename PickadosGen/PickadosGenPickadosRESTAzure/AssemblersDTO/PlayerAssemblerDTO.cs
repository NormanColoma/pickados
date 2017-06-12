using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class PlayerAssemblerDTO {
public static IList<PlayerEN> ConvertList (IList<PlayerDTO> lista)
{
        IList<PlayerEN> result = new List<PlayerEN>();
        foreach (PlayerDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static PlayerEN Convert (PlayerDTO dto)
{
        PlayerEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PlayerEN ();



                        if (dto.Club_team_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ITeamCAD teamCAD = new PickadosGenNHibernate.CAD.Pickados.TeamCAD ();

                                newinstance.Club_team = teamCAD.ReadOIDDefault (dto.Club_team_oid);
                        }
                        if (dto.National_team_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ITeamCAD teamCAD = new PickadosGenNHibernate.CAD.Pickados.TeamCAD ();

                                newinstance.National_team = teamCAD.ReadOIDDefault (dto.National_team_oid);
                        }
                        newinstance.Id = dto.Id;
                        newinstance.Name = dto.Name;
                        if (dto.Scorer_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IScorerCAD scorerCAD = new PickadosGenNHibernate.CAD.Pickados.ScorerCAD ();

                                newinstance.Scorer = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.ScorerEN>();
                                foreach (int entry in dto.Scorer_oid) {
                                        newinstance.Scorer.Add (scorerCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Sport_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ISportCAD sportCAD = new PickadosGenNHibernate.CAD.Pickados.SportCAD ();

                                newinstance.Sport = sportCAD.ReadOIDDefault (dto.Sport_oid);
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
