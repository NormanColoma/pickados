
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ICorrectScoreCAD
{
CorrectScoreEN ReadOIDDefault (int id
                               );

void ModifyDefault (CorrectScoreEN correctScore);



int NewCorrectScore (CorrectScoreEN correctScore);

void ModifyCorrectScore (CorrectScoreEN correctScore);


void DeleteCorrectScore (int id
                         );
}
}
