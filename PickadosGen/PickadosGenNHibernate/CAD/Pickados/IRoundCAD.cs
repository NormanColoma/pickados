
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IRoundCAD
{
RoundEN ReadOIDDefault (int id
                        );

void ModifyDefault (RoundEN round);

System.Collections.Generic.IList<RoundEN> ReadAllDefault (int first, int size);



int NewRound (RoundEN round);

void ModifyRound (RoundEN round);


void DestroyRound (int id
                   );


RoundEN ReadOID (int id
                 );


System.Collections.Generic.IList<RoundEN> ReadAll (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RoundEN> GetRoundBySeason (int id);
}
}
