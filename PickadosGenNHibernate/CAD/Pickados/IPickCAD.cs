
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IPickCAD
{
PickEN ReadOIDDefault (int id
                       );

void ModifyDefault (PickEN pick);



int NewPick (PickEN pick);

void ModifyPick (PickEN pick);


void DeletePick (int id
                 );


PickEN GetByID (int id
                );


System.Collections.Generic.IList<PickEN> GetAll (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> PicksByResult ();
}
}
