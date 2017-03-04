
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CEN.Pickados;



/*PROTECTED REGION ID(usingPickadosGenNHibernate.CP.Pickados_Post_verifyPost) ENABLED START*/
using System.Linq;
using PickadosGenNHibernate.Enumerated.Pickados;
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CP.Pickados
{
public partial class PostCP : BasicCP
{
public void VerifyPost (int p_oid)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CP.Pickados_Post_verifyPost) ENABLED START*/

        IPostCAD postCAD = null;
        PostCEN postCEN = null;
        ITipsterCAD tipsterCAD = null;
        TipsterCEN tipsterCEN = null;
        IStatsCAD statsCAD = null;
        StatsCEN statsCEN = null;


        try
        {
                SessionInitializeTransaction ();
                postCAD = new PostCAD (session);
                postCEN = new PostCEN (postCAD);
                tipsterCAD = new TipsterCAD (session);
                tipsterCEN = new TipsterCEN (tipsterCAD);
                statsCAD = new StatsCAD (session);
                statsCEN = new StatsCEN (statsCAD);

                PostEN postEN = postCEN.GetPostById (p_oid);

                if (postEN != null) {
                        //Comprobamos que el pick o los picks hayan finalizado
                        if (postEN.Pick != null && postEN.Pick.Any ()) {
                                Boolean finished = true;
                                foreach (PickEN pick in postEN.Pick) {
                                        if (pick.PickResult.Equals (PickResultEnum.unfinished) ||
                                            pick.PickResult.Equals (PickResultEnum.unstarted)) {
                                                finished = false;
                                        }
                                }

                                if (finished) {
                                        TipsterEN tipsterEN = tipsterCEN.GetTipsterById (postEN.Tipster.Id);

                                        //Comprueba si hay stats creadas, si no, crea para este mes



                                        StatsEN statsEN = new StatsEN ();
                                        statsEN.Tipster = postEN.Tipster;
                                        statsEN.InitialDate = DateTime.Now;
                                        int id_stats = 0;
                                        if (tipsterEN.MonthlyStats != null && !tipsterEN.MonthlyStats.Any ()) {
                                                id_stats = statsCEN.get_IStatsCAD ().NewMonthlyStats (statsEN);
                                        }
                                        else{
                                                Boolean exist = false;
                                                StatsEN statsENaux = new StatsEN ();

                                                //Comprobamos entre las existentes si hay alguna de este mes.
                                                //Se puede mejorar accediendo directamente a la �ltima creada
                                                foreach (StatsEN stats in tipsterEN.MonthlyStats) {
                                                        if (stats.InitialDate.Value.Month.Equals (DateTime.Now.Month)) {
                                                                id_stats = stats.Id;
                                                                exist = true;
                                                        }
                                                }


                                                if (!exist) {
                                                        id_stats = statsCEN.get_IStatsCAD ().NewMonthlyStats (statsEN);
                                                }
                                        }

                                        statsEN = statsCEN.GetStatById (id_stats);

                                        StatsEN statsEN_aux = new StatsEN ();
                                        statsEN_aux = updateStats (statsEN, postEN);
                                        //Actualizamos y guardamos las stats

                                        statsCEN.get_IStatsCAD ().ModifyMonthlyStats (statsEN_aux);
                                }
                        }
                }



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
}

public StatsEN updateStats (StatsEN stats, PostEN post)
{
        stats.TotalPicks += 1;
        stats.OddAccumulator += post.TotalOdd;
        stats.TotalStaked += post.Stake;
        stats.OddAverage = stats.OddAccumulator / stats.TotalPicks;
        stats.StakeAverage = stats.TotalStaked / stats.TotalPicks;


        //TODO- Compute multiple picks with some push one
        //Verifying pick results
        post.PostResult = PickResultEnum.won;

        if (post.Pick.Count () == 1) post.PostResult = post.Pick.First ().PickResult;
        else{
                foreach (PickEN pick in post.Pick) {
                        if (pick.PickResult.Equals (PickResultEnum.lost)) {
                                post.PostResult = PickResultEnum.lost;
                        }
                }
        }



        switch (post.PostResult) {
        case PickResultEnum.won:
                double benef = post.TotalOdd * post.Stake - post.Stake;
                stats.Benefit += benef;

                break;

        case PickResultEnum.lost:
                stats.Benefit -= post.Stake;
                //statsEN.Yield
                break;

        default:
                Console.WriteLine ("Not recognise ");
                break;
        }

        stats.Yield = (float)(stats.Benefit / stats.TotalStaked * 100);

        return stats;
}
/*PROTECTED REGION END*/
}
}
