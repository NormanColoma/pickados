
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IMatchCAD
{
MatchEN ReadOIDDefault (int id
                        );

void ModifyDefault (MatchEN match);



int NewMatch (MatchEN match);

void ModifyMatch (MatchEN match);


void DeleteMatch (int id
                  );
}
}
