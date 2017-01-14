
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IWincastCAD
{
WincastEN ReadOIDDefault (int id
                          );

void ModifyDefault (WincastEN wincast);
}
}
