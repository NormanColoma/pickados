using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class StatsAssemblerDTO {
public static IList<StatsEN> ConvertList (IList<StatsDTO> lista)
{
        IList<StatsEN> result = new List<StatsEN>();
        foreach (StatsDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static StatsEN Convert (StatsDTO dto)
{
        StatsEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new StatsEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Benefit = dto.Benefit;
                        newinstance.StakeAverage = dto.StakeAverage;
                        newinstance.Yield = dto.Yield;
                        newinstance.OddAverage = dto.OddAverage;
                        newinstance.TotalPicks = dto.TotalPicks;
                        newinstance.Date = dto.Date;
                        if (dto.Tipster_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ITipsterCAD tipsterCAD = new PickadosGenNHibernate.CAD.Pickados.TipsterCAD ();

                                newinstance.Tipster = tipsterCAD.ReadOIDDefault (dto.Tipster_oid);
                        }
                        newinstance.OddAccumulator = dto.OddAccumulator;
                        newinstance.TotalStaked = dto.TotalStaked;
                        newinstance.Wins = dto.Wins;
                        newinstance.Voids = dto.Voids;
                        newinstance.Lost = dto.Lost;
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
