

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
     *      Definition of the class ResultCEN
     *
     */
    public partial class ResultCEN
    {
        private IResultCAD _IResultCAD;

        public ResultCEN()
        {
            this._IResultCAD = new ResultCAD();
        }

        public ResultCEN(IResultCAD _IResultCAD)
        {
            this._IResultCAD = _IResultCAD;
        }

        public IResultCAD get_IResultCAD()
        {
            return this._IResultCAD;
        }

        public int NewResult(double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum p_result, PickadosGenNHibernate.Enumerated.Pickados.TimeEnum p_matchtime)
        {
            ResultEN resultEN = null;
            int oid;

            //Initialized ResultEN
            resultEN = new ResultEN();
            resultEN.Odd = p_odd;

            resultEN.Description = p_description;

            resultEN.PickResult = p_pickResult;

            resultEN.Bookie = p_bookie;


            if (p_event_rel != -1)
            {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                resultEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN();
                resultEN.Event_rel.Id = p_event_rel;
            }

            resultEN.Result = p_result;

            resultEN.Matchtime = p_matchtime;

            //Call to ResultCAD

            oid = _IResultCAD.NewResult(resultEN);
            return oid;
        }

        public void ModifyResult(int p_Result_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum p_result, PickadosGenNHibernate.Enumerated.Pickados.TimeEnum p_matchtime)
        {
            ResultEN resultEN = null;

            //Initialized ResultEN
            resultEN = new ResultEN();
            resultEN.Id = p_Result_OID;
            resultEN.Odd = p_odd;
            resultEN.Description = p_description;
            resultEN.PickResult = p_pickResult;
            resultEN.Bookie = p_bookie;
            resultEN.Result = p_result;
            resultEN.Matchtime = p_matchtime;
            //Call to ResultCAD

            _IResultCAD.ModifyResult(resultEN);
        }

        public void DeleteResult(int id
                                  )
        {
            _IResultCAD.DeleteResult(id);
        }
    }
}
