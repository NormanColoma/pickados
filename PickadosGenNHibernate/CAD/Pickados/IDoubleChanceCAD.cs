
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IDoubleChanceCAD
{
DoubleChanceEN ReadOIDDefault (int id
                               );

void ModifyDefault (DoubleChanceEN doubleChance);



int NewDobleChance (DoubleChanceEN doubleChance);

void ModifyDobleChance (DoubleChanceEN doubleChance);


void DeleteDobleChance (int id
                        );
}
}
