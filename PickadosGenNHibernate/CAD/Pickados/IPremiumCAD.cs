
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IPremiumCAD
{
PremiumEN ReadOIDDefault (int id
                          );

void ModifyDefault (PremiumEN premium);



int New_ (PremiumEN premium);

void Modify (PremiumEN premium);


void Destroy (int id
              );
}
}
