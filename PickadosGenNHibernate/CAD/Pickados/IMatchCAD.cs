
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IMatchCAD
{
MatchEN ReadOIDDefault (int id
                        );

void ModifyDefault (MatchEN match);



System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetTeams ();


void AddVisitante (int p_Match_OID, int p_away_OID);

void AddLocal (int p_Match_OID, int p_home_OID);

int New_ (MatchEN match);

void Modify (MatchEN match);


void Destroy (int id
              );
}
}
