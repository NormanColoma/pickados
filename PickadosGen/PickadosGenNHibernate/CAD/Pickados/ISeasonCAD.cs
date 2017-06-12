
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ISeasonCAD
{
SeasonEN ReadOIDDefault (int id
                         );

void ModifyDefault (SeasonEN season);

System.Collections.Generic.IList<SeasonEN> ReadAllDefault (int first, int size);



int NewSeason (SeasonEN season);

void ModifySeason (SeasonEN season);


void DestroySeason (int id
                    );


SeasonEN GetSeasonByID (int id
                        );


System.Collections.Generic.IList<SeasonEN> GetAllSeasons (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.SeasonEN> GetSeasonByCompetition (int id);
}
}
