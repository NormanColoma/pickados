

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
     *      Definition of the class DoubleChanceCEN
     *
     */
    public partial class DoubleChanceCEN
    {
        private IDoubleChanceCAD _IDoubleChanceCAD;

        public DoubleChanceCEN()
        {
            this._IDoubleChanceCAD = new DoubleChanceCAD();
        }

        public DoubleChanceCEN(IDoubleChanceCAD _IDoubleChanceCAD)
        {
            this._IDoubleChanceCAD = _IDoubleChanceCAD;
        }

        public IDoubleChanceCAD get_IDoubleChanceCAD()
        {
            return this._IDoubleChanceCAD;
        }

        public int NewDobleChance(double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum p_result, PickadosGenNHibernate.Enumerated.Pickados.TimeEnum p_matchtime, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum p_result_b)
        {
            DoubleChanceEN doubleChanceEN = null;
            int oid;

            //Initialized DoubleChanceEN
            doubleChanceEN = new DoubleChanceEN();
            doubleChanceEN.Odd = p_odd;

            doubleChanceEN.Description = p_description;

            doubleChanceEN.PickResult = p_pickResult;

            doubleChanceEN.Bookie = p_bookie;


            if (p_event_rel != -1)
            {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                doubleChanceEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN();
                doubleChanceEN.Event_rel.Id = p_event_rel;
            }

            doubleChanceEN.Result = p_result;

            doubleChanceEN.Matchtime = p_matchtime;

            doubleChanceEN.Result_b = p_result_b;

            //Call to DoubleChanceCAD

            oid = _IDoubleChanceCAD.NewDobleChance(doubleChanceEN);
            return oid;
        }

        public void ModifyDobleChance(int p_DoubleChance_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum p_result, PickadosGenNHibernate.Enumerated.Pickados.TimeEnum p_matchtime, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum p_result_b)
        {
            DoubleChanceEN doubleChanceEN = null;

            //Initialized DoubleChanceEN
            doubleChanceEN = new DoubleChanceEN();
            doubleChanceEN.Id = p_DoubleChance_OID;
            doubleChanceEN.Odd = p_odd;
            doubleChanceEN.Description = p_description;
            doubleChanceEN.PickResult = p_pickResult;
            doubleChanceEN.Bookie = p_bookie;
            doubleChanceEN.Result = p_result;
            doubleChanceEN.Matchtime = p_matchtime;
            doubleChanceEN.Result_b = p_result_b;
            //Call to DoubleChanceCAD

            _IDoubleChanceCAD.ModifyDobleChance(doubleChanceEN);
        }

        public void DeleteDobleChance(int id
                                       )
        {
            _IDoubleChanceCAD.DeleteDobleChance(id);
        }
    }
}
