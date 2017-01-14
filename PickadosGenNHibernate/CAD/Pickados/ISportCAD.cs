
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ISportCAD
{
SportEN ReadOIDDefault (int id
                        );

void ModifyDefault (SportEN sport);



int New_ (SportEN sport);

void Modify (SportEN sport);


void Destroy (int id
              );
}
}
