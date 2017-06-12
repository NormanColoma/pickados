
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


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetCompetitionByTeam (int id);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetCompetitionBySport (int id);


System.Collections.Generic.IList<string> GetPlaces ();


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetClubCompetition ();


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetNationalCompetition ();


System.Collections.Generic.IList<string> GetClubPlaces ();


System.Collections.Generic.IList<string> GetNationalPlaces ();
}
}
