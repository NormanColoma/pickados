
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IWincastCAD
{
WincastEN ReadOIDDefault (int id
                          );

void ModifyDefault (WincastEN wincast);

System.Collections.Generic.IList<WincastEN> ReadAllDefault (int first, int size);



int NewWincast (WincastEN wincast);

void ModifyWincast (WincastEN wincast);


void DeleteWincast (int id
                    );
}
}
