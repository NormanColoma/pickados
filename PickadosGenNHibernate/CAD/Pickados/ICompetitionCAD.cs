
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ICompetitionCAD
{
CompetitionEN ReadOIDDefault (int id
                              );

void ModifyDefault (CompetitionEN competition);



int NewCompetition (CompetitionEN competition);

void ModifyCompetition (CompetitionEN competition);


void DeleteCompetition (int id
                        );
}
}
