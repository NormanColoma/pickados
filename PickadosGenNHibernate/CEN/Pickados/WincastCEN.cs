

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
     *      Definition of the class WincastCEN
     *
     */
    public partial class WincastCEN
    {
        private IWincastCAD _IWincastCAD;

        public WincastCEN()
        {
            this._IWincastCAD = new WincastCAD();
        }

        public WincastCEN(IWincastCAD _IWincastCAD)
        {
            this._IWincastCAD = _IWincastCAD;
        }

        public IWincastCAD get_IWincastCAD()
        {
            return this._IWincastCAD;
        }

        public int NewWincast(double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel, string p_scorer_name, int p_player, string p_team_name)
        {
            WincastEN wincastEN = null;
            int oid;

            //Initialized WincastEN
            wincastEN = new WincastEN();
            wincastEN.Odd = p_odd;

            wincastEN.Description = p_description;

            wincastEN.PickResult = p_pickResult;

            wincastEN.Bookie = p_bookie;


            if (p_event_rel != -1)
            {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                wincastEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN();
                wincastEN.Event_rel.Id = p_event_rel;
            }

            wincastEN.Scorer_name = p_scorer_name;


            if (p_player != -1)
            {
                // El argumento p_player -> Property player es oid = false
                // Lista de oids id
                wincastEN.Player = new PickadosGenNHibernate.EN.Pickados.PlayerEN();
                wincastEN.Player.Id = p_player;
            }

            wincastEN.Team_name = p_team_name;

            //Call to WincastCAD

            oid = _IWincastCAD.NewWincast(wincastEN);
            return oid;
        }

        public void ModifyWincast(int p_Wincast_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, string p_scorer_name, string p_team_name)
        {
            WincastEN wincastEN = null;

            //Initialized WincastEN
            wincastEN = new WincastEN();
            wincastEN.Id = p_Wincast_OID;
            wincastEN.Odd = p_odd;
            wincastEN.Description = p_description;
            wincastEN.PickResult = p_pickResult;
            wincastEN.Bookie = p_bookie;
            wincastEN.Scorer_name = p_scorer_name;
            wincastEN.Team_name = p_team_name;
            //Call to WincastCAD

            _IWincastCAD.ModifyWincast(wincastEN);
        }

        public void DeleteWincast(int id
                                   )
        {
            _IWincastCAD.DeleteWincast(id);
        }
    }
}
