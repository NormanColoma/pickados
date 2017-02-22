
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ICompetitionCAD
{
CompetitionEN ReadOIDDefault (int id
                              );

void ModifyDefault (CompetitionEN competition);

System.Collections.Generic.IList<CompetitionEN> ReadAllDefault (int first, int size);



int NewCompetition (CompetitionEN competition);

void ModifyCompetition (CompetitionEN competition);


void DeleteCompetition (int id
                        );


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetCompetitionsByPlace (string place);


CompetitionEN GetCompetitionById (int id
                                  );


System.Collections.Generic.IList<CompetitionEN> GetAllCompetitions (int first, int size);
}
}
