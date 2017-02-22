
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IPlayerCAD
{
PlayerEN ReadOIDDefault (int id
                         );

void ModifyDefault (PlayerEN player);

System.Collections.Generic.IList<PlayerEN> ReadAllDefault (int first, int size);



int NewPlayer (PlayerEN player);

void ModifyPlayer (PlayerEN player);


void DeletePlayer (int id
                   );


void JoinClubTeam (int p_Player_OID, int p_club_team_OID);

void JoinNationalTeam (int p_Player_OID, int p_national_team_OID);

void UnlinkClubTeam (int p_Player_OID, int p_club_team_OID);

void UnlinkNationalTeam (int p_Player_OID, int p_national_team_OID);

PlayerEN GetPlayerById (int id
                        );


System.Collections.Generic.IList<PlayerEN> GetAllPlayers (int first, int size);
}
}
