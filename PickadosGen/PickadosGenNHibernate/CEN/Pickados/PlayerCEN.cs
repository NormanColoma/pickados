

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


namespace PickadosGenNHibernate.CEN.Pickados
{
    /*
     *      Definition of the class PlayerCEN
     *
     */
    public partial class PlayerCEN
    {
        private IPlayerCAD _IPlayerCAD;

        public PlayerCEN()
        {
            this._IPlayerCAD = new PlayerCAD();
        }

        public PlayerCEN(IPlayerCAD _IPlayerCAD)
        {
            this._IPlayerCAD = _IPlayerCAD;
        }

        public IPlayerCAD get_IPlayerCAD()
        {
            return this._IPlayerCAD;
        }

        public int NewPlayer(string p_name)
        {
            PlayerEN playerEN = null;
            int oid;

            //Initialized PlayerEN
            playerEN = new PlayerEN();
            playerEN.Name = p_name;

            //Call to PlayerCAD

            oid = _IPlayerCAD.NewPlayer(playerEN);
            return oid;
        }

        public void ModifyPlayer(int p_Player_OID, string p_name)
        {
            PlayerEN playerEN = null;

            //Initialized PlayerEN
            playerEN = new PlayerEN();
            playerEN.Id = p_Player_OID;
            playerEN.Name = p_name;
            //Call to PlayerCAD

            _IPlayerCAD.ModifyPlayer(playerEN);
        }

        public void DeletePlayer(int id
                                  )
        {
            _IPlayerCAD.DeletePlayer(id);
        }

        public void JoinClubTeam(int p_Player_OID, int p_club_team_OID)
        {
            //Call to PlayerCAD

            _IPlayerCAD.JoinClubTeam(p_Player_OID, p_club_team_OID);
        }
        public void JoinNationalTeam(int p_Player_OID, int p_national_team_OID)
        {
            //Call to PlayerCAD

            _IPlayerCAD.JoinNationalTeam(p_Player_OID, p_national_team_OID);
        }
        public void UnlinkClubTeam(int p_Player_OID, int p_club_team_OID)
        {
            //Call to PlayerCAD

            _IPlayerCAD.UnlinkClubTeam(p_Player_OID, p_club_team_OID);
        }
        public void UnlinkNationalTeam(int p_Player_OID, int p_national_team_OID)
        {
            //Call to PlayerCAD

            _IPlayerCAD.UnlinkNationalTeam(p_Player_OID, p_national_team_OID);
        }
        public PlayerEN GetPlayerById(int id
                                       )
        {
            PlayerEN playerEN = null;

            playerEN = _IPlayerCAD.GetPlayerById(id);
            return playerEN;
        }

        public System.Collections.Generic.IList<PlayerEN> GetAllPlayers(int first, int size)
        {
            System.Collections.Generic.IList<PlayerEN> list = null;

            list = _IPlayerCAD.GetAllPlayers(first, size);
            return list;
        }
    }
}
