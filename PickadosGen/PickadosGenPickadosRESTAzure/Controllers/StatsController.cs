using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PickadosGenPickadosRESTAzure.DTO;
using PickadosGenPickadosRESTAzure.DTOA;
using PickadosGenPickadosRESTAzure.CAD;
using PickadosGenPickadosRESTAzure.Assemblers;
using PickadosGenPickadosRESTAzure.AssemblersDTO;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.CP.Pickados;


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_StatsControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Stats")]
public class StatsController : BasicController
{
// Voy a generar el readAll













// No pasa el slEnables: getStatsByTipster

[HttpGet]

[Route ("~/api/Stats/GetStatsByTipster")]

public HttpResponseMessage GetStatsByTipster (string p_tipster_name)
{
        // CAD, CEN, EN, returnValue

        StatsRESTCAD statsRESTCAD = null;
        StatsCEN statsCEN = null;


        System.Collections.Generic.List<StatsEN> en;

        System.Collections.Generic.List<StatsDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                statsRESTCAD = new StatsRESTCAD (session);
                statsCEN = new StatsCEN (statsRESTCAD);

                // CEN return



                en = statsCEN.GetStatsByTipster (p_tipster_name).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<StatsDTOA>();
                        foreach (StatsEN entry in en)
                                returnValue.Add (StatsAssembler.Convert (entry, session));
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(PickadosGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(PickadosGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - Empty
        if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}


// No pasa el slEnables: getStatsByMonthTipster

[HttpGet]

[Route ("~/api/Stats/GetStatsByMonthTipster")]

public HttpResponseMessage GetStatsByMonthTipster (string p_tipster_name, PickadosGenNHibernate.Enumerated.Pickados.MonthsEnum p_stats_month, int p_stats_year)
{
        // CAD, CEN, EN, returnValue

        StatsRESTCAD statsRESTCAD = null;
        StatsCEN statsCEN = null;


        System.Collections.Generic.List<StatsEN> en;

        System.Collections.Generic.List<StatsDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                statsRESTCAD = new StatsRESTCAD (session);
                statsCEN = new StatsCEN (statsRESTCAD);

                // CEN return



                en = statsCEN.GetStatsByMonthTipster (p_tipster_name, p_stats_month, p_stats_year).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<StatsDTOA>();
                        foreach (StatsEN entry in en)
                                returnValue.Add (StatsAssembler.Convert (entry, session));
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(PickadosGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(PickadosGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - Empty
        if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}
















/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_StatsControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
