using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class SeasonAssemblerDTO {
public static IList<SeasonEN> ConvertList (IList<SeasonDTO> lista)
{
        IList<SeasonEN> result = new List<SeasonEN>();
        foreach (SeasonDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static SeasonEN Convert (SeasonDTO dto)
{
        SeasonEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new SeasonEN ();



                        newinstance.Id = dto.Id;
                        newinstance.InitDate = dto.InitDate;
                        newinstance.FinalDate = dto.FinalDate;
                        if (dto.Competition_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ICompetitionCAD competitionCAD = new PickadosGenNHibernate.CAD.Pickados.CompetitionCAD ();

                                newinstance.Competition = competitionCAD.ReadOIDDefault (dto.Competition_oid);
                        }
                        if (dto.Round_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IRoundCAD roundCAD = new PickadosGenNHibernate.CAD.Pickados.RoundCAD ();

                                newinstance.Round = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.RoundEN>();
                                foreach (int entry in dto.Round_oid) {
                                        newinstance.Round.Add (roundCAD.ReadOIDDefault (entry));
                                }
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
