
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ITimecastCAD
{
TimecastEN ReadOIDDefault (int id
                           );

void ModifyDefault (TimecastEN timecast);
}
}
