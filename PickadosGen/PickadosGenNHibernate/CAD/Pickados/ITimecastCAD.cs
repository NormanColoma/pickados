
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ITimecastCAD
{
TimecastEN ReadOIDDefault (int id
                           );

void ModifyDefault (TimecastEN timecast);

System.Collections.Generic.IList<TimecastEN> ReadAllDefault (int first, int size);



int NewTimecast (TimecastEN timecast);

void ModifyTimecast (TimecastEN timecast);


void DeleteTimecast (int id
                     );
}
}
