
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IGoalCAD
{
GoalEN ReadOIDDefault (int id
                       );

void ModifyDefault (GoalEN goal);



int NewGoal (GoalEN goal);

void ModifyGoal (GoalEN goal);


void DeleteGoal (int id
                 );
}
}
