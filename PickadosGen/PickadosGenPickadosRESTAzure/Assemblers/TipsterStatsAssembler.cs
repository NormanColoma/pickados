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
public static class TipsterStatsAssembler
{
public static TipsterStatsDTOA Convert (TipsterEN en, NHibernate.ISession session = null)
{
        TipsterStatsDTOA dto = null;
        TipsterStatsRESTCAD tipsterStatsRESTCAD = null;
        TipsterCEN tipsterCEN = null;
        TipsterCP tipsterCP = null;

        if (en != null) {
                dto = new TipsterStatsDTOA ();
                tipsterStatsRESTCAD = new TipsterStatsRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterStatsRESTCAD);
                tipsterCP = new TipsterCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Alias = en.Alias;
                dto.Subscription_fee = en.Subscription_fee;
                dto.Premium = en.Premium;

                //
                // TravesalLink

                /* Rol: TipsterStats o--> Stats */
                dto.GetStatsOfTipster = null;
                List<StatsEN> GetStatsOfTipster = tipsterStatsRESTCAD.GetStatsOfTipster (en.Id).ToList ();
                if (GetStatsOfTipster != null) {
                        dto.GetStatsOfTipster = new List<StatsDTOA>();
                        foreach (StatsEN entry in GetStatsOfTipster)
                                dto.GetStatsOfTipster.Add (StatsAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
