
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IPickCAD
{
PickEN ReadOIDDefault (int id
                       );

void ModifyDefault (PickEN pick);

System.Collections.Generic.IList<PickEN> ReadAllDefault (int first, int size);



int NewPick (PickEN pick);

void ModifyPick (PickEN pick);


void DeletePick (int id
                 );


PickEN GetPickById (int id
                    );


System.Collections.Generic.IList<PickEN> GetAllPicks (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> GetPicksByResult (PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum ? p_pickResult);
}
}
