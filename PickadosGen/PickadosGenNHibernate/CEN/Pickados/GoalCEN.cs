

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
     *      Definition of the class GoalCEN
     *
     */
    public partial class GoalCEN
    {
        private IGoalCAD _IGoalCAD;

        public GoalCEN()
        {
            this._IGoalCAD = new GoalCAD();
        }

        public GoalCEN(IGoalCAD _IGoalCAD)
        {
            this._IGoalCAD = _IGoalCAD;
        }

        public IGoalCAD get_IGoalCAD()
        {
            return this._IGoalCAD;
        }

        public int NewGoal(double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel, PickadosGenNHibernate.Enumerated.Pickados.LineEnum p_line, double p_quantity, bool p_asian)
        {
            GoalEN goalEN = null;
            int oid;

            //Initialized GoalEN
            goalEN = new GoalEN();
            goalEN.Odd = p_odd;

            goalEN.Description = p_description;

            goalEN.PickResult = p_pickResult;

            goalEN.Bookie = p_bookie;


            if (p_event_rel != -1)
            {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                goalEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN();
                goalEN.Event_rel.Id = p_event_rel;
            }

            goalEN.Line = p_line;

            goalEN.Quantity = p_quantity;

            goalEN.Asian = p_asian;

            //Call to GoalCAD

            oid = _IGoalCAD.NewGoal(goalEN);
            return oid;
        }

        public void ModifyGoal(int p_Goal_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, PickadosGenNHibernate.Enumerated.Pickados.LineEnum p_line, double p_quantity, bool p_asian)
        {
            GoalEN goalEN = null;

            //Initialized GoalEN
            goalEN = new GoalEN();
            goalEN.Id = p_Goal_OID;
            goalEN.Odd = p_odd;
            goalEN.Description = p_description;
            goalEN.PickResult = p_pickResult;
            goalEN.Bookie = p_bookie;
            goalEN.Line = p_line;
            goalEN.Quantity = p_quantity;
            goalEN.Asian = p_asian;
            //Call to GoalCAD

            _IGoalCAD.ModifyGoal(goalEN);
        }

        public void DeleteGoal(int id
                                )
        {
            _IGoalCAD.DeleteGoal(id);
        }
    }
}
