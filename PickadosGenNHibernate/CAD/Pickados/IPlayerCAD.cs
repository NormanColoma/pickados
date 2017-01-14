
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IPlayerCAD
{
PlayerEN ReadOIDDefault (int id
                         );

void ModifyDefault (PlayerEN player);



int New_ (PlayerEN player);

void Modify (PlayerEN player);


void Destroy (int id
              );


void JoinClubTeam (int p_Player_OID, int p_club_team_OID);

void JoinNationalTeam (int p_Player_OID, int p_national_team_OID);

void UnlinkClubTeam (int p_Player_OID, int p_club_team_OID);

void UnlinkNationalTeam (int p_Player_OID, int p_national_team_OID);
}
}
