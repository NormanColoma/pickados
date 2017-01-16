

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
     *      Definition of the class HandicapCEN
     *
     */
    public partial class HandicapCEN
    {
        private IHandicapCAD _IHandicapCAD;

        public HandicapCEN()
        {
            this._IHandicapCAD = new HandicapCAD();
        }

        public HandicapCEN(IHandicapCAD _IHandicapCAD)
        {
            this._IHandicapCAD = _IHandicapCAD;
        }

        public IHandicapCAD get_IHandicapCAD()
        {
            return this._IHandicapCAD;
        }

        public int NewHandicap(double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel, PickadosGenNHibernate.Enumerated.Pickados.LineEnum p_line, double p_quantity, bool p_asian, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum p_result)
        {
            HandicapEN handicapEN = null;
            int oid;

            //Initialized HandicapEN
            handicapEN = new HandicapEN();
            handicapEN.Odd = p_odd;

            handicapEN.Description = p_description;

            handicapEN.PickResult = p_pickResult;

            handicapEN.Bookie = p_bookie;


            if (p_event_rel != -1)
            {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                handicapEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN();
                handicapEN.Event_rel.Id = p_event_rel;
            }

            handicapEN.Line = p_line;

            handicapEN.Quantity = p_quantity;

            handicapEN.Asian = p_asian;

            handicapEN.Result = p_result;

            //Call to HandicapCAD

            oid = _IHandicapCAD.NewHandicap(handicapEN);
            return oid;
        }

        public void ModifyHandicap(int p_Handicap_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, PickadosGenNHibernate.Enumerated.Pickados.LineEnum p_line, double p_quantity, bool p_asian, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum p_result)
        {
            HandicapEN handicapEN = null;

            //Initialized HandicapEN
            handicapEN = new HandicapEN();
            handicapEN.Id = p_Handicap_OID;
            handicapEN.Odd = p_odd;
            handicapEN.Description = p_description;
            handicapEN.PickResult = p_pickResult;
            handicapEN.Bookie = p_bookie;
            handicapEN.Line = p_line;
            handicapEN.Quantity = p_quantity;
            handicapEN.Asian = p_asian;
            handicapEN.Result = p_result;
            //Call to HandicapCAD

            _IHandicapCAD.ModifyHandicap(handicapEN);
        }

        public void DeleteHandicap(int id
                                    )
        {
            _IHandicapCAD.DeleteHandicap(id);
        }
    }
}
