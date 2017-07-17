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
public static class StatsAssembler
{
public static StatsDTOA Convert (StatsEN en, NHibernate.ISession session = null)
{
        StatsDTOA dto = null;
        StatsRESTCAD statsRESTCAD = null;
        StatsCEN statsCEN = null;
        StatsCP statsCP = null;

        if (en != null) {
                dto = new StatsDTOA ();
                statsRESTCAD = new StatsRESTCAD (session);
                statsCEN = new StatsCEN (statsRESTCAD);
                statsCP = new StatsCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Benefit = en.Benefit;
                dto.StakeAverage = en.StakeAverage;
                dto.Yield = en.Yield;
                dto.OddAverage = en.OddAverage;
                dto.TotalPicks = en.TotalPicks;
                dto.OddAccumulator = en.OddAccumulator;
                dto.TotalStaked = en.TotalStaked;
                dto.Wins = en.Wins;
                dto.Voids = en.Voids;
                dto.Lost = en.Lost;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
