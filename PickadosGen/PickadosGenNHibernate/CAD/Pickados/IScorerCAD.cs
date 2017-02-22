
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IScorerCAD
{
ScorerEN ReadOIDDefault (int id
                         );

void ModifyDefault (ScorerEN scorer);

System.Collections.Generic.IList<ScorerEN> ReadAllDefault (int first, int size);



int NewScorer (ScorerEN scorer);

void ModifyScorer (ScorerEN scorer);


void DeleteScorer (int id
                   );
}
}
