

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
     *      Definition of the class ScorerCEN
     *
     */
    public partial class ScorerCEN
    {
        private IScorerCAD _IScorerCAD;

        public ScorerCEN()
        {
            this._IScorerCAD = new ScorerCAD();
        }

        public ScorerCEN(IScorerCAD _IScorerCAD)
        {
            this._IScorerCAD = _IScorerCAD;
        }

        public IScorerCAD get_IScorerCAD()
        {
            return this._IScorerCAD;
        }

        public int NewScorer(double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel, string p_scorer_name, int p_player)
        {
            ScorerEN scorerEN = null;
            int oid;

            //Initialized ScorerEN
            scorerEN = new ScorerEN();
            scorerEN.Odd = p_odd;

            scorerEN.Description = p_description;

            scorerEN.PickResult = p_pickResult;

            scorerEN.Bookie = p_bookie;


            if (p_event_rel != -1)
            {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                scorerEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN();
                scorerEN.Event_rel.Id = p_event_rel;
            }

            scorerEN.Scorer_name = p_scorer_name;


            if (p_player != -1)
            {
                // El argumento p_player -> Property player es oid = false
                // Lista de oids id
                scorerEN.Player = new PickadosGenNHibernate.EN.Pickados.PlayerEN();
                scorerEN.Player.Id = p_player;
            }

            //Call to ScorerCAD

            oid = _IScorerCAD.NewScorer(scorerEN);
            return oid;
        }

        public void ModifyScorer(int p_Scorer_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, string p_scorer_name)
        {
            ScorerEN scorerEN = null;

            //Initialized ScorerEN
            scorerEN = new ScorerEN();
            scorerEN.Id = p_Scorer_OID;
            scorerEN.Odd = p_odd;
            scorerEN.Description = p_description;
            scorerEN.PickResult = p_pickResult;
            scorerEN.Bookie = p_bookie;
            scorerEN.Scorer_name = p_scorer_name;
            //Call to ScorerCAD

            _IScorerCAD.ModifyScorer(scorerEN);
        }

        public void DeleteScorer(int id
                                  )
        {
            _IScorerCAD.DeleteScorer(id);
        }
    }
}
