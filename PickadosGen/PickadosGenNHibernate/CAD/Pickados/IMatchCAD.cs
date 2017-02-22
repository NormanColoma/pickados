
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IMatchCAD
{
MatchEN ReadOIDDefault (int id
                        );

void ModifyDefault (MatchEN match);

System.Collections.Generic.IList<MatchEN> ReadAllDefault (int first, int size);



int NewMatch (MatchEN match);

void ModifyMatch (MatchEN match);


void DeleteMatch (int id
                  );


MatchEN GetMatchById (int id
                      );


System.Collections.Generic.IList<MatchEN> GetAllMatches (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByTeam (string team);
}
}
