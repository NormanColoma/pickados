
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IWincastCAD
{
WincastEN ReadOIDDefault (int id
                          );

void ModifyDefault (WincastEN wincast);



int New_ (WincastEN wincast);

void Modify (WincastEN wincast);


void Destroy (int id
              );
}
}
