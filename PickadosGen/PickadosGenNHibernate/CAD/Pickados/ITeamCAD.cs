
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ITeamCAD
{
TeamEN ReadOIDDefault (int id
                       );

void ModifyDefault (TeamEN team);

System.Collections.Generic.IList<TeamEN> ReadAllDefault (int first, int size);



int NewTeam (TeamEN team);

void ModifyTeam (TeamEN team);


void DeleteTeam (int id
                 );


TeamEN GetTeamById (int id
                    );


System.Collections.Generic.IList<TeamEN> GetAllTeams (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TeamEN> GetTeamByCompetition (int id);


void AddCompetition (int p_Team_OID, System.Collections.Generic.IList<int> p_competition_OIDs);
}
}
