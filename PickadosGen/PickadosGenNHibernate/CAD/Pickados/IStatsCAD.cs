
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IStatsCAD
{
StatsEN ReadOIDDefault (int id
                        );

void ModifyDefault (StatsEN stats);

System.Collections.Generic.IList<StatsEN> ReadAllDefault (int first, int size);



int NewMonthlyStats (StatsEN stats);

void ModifyMonthlyStats (StatsEN stats);


void DeleteMonthlyStats (int id
                         );


StatsEN GetStatById (int id
                     );


System.Collections.Generic.IList<StatsEN> GetAllStats (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> GetStatsByTipster (string p_Tipster_Name);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> GetStatsByMonthTipster (string p_Tipster_Name, int ? p_Stats_Month);
}
}
