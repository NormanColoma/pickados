
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IStatsCAD
{
StatsEN ReadOIDDefault (int id
                        );

void ModifyDefault (StatsEN stats);



int NewMonthlyStats (StatsEN stats);

void ModifyMonthlyStats (StatsEN stats);


void DeleteMonthlyStats (int id
                         );

StatsEN GetByID(int id
                 );


System.Collections.Generic.IList<StatsEN> ReadAll(int first, int size);
   
}
}
