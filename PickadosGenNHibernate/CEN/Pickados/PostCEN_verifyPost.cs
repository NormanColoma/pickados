
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using System.Linq;
using PickadosGenNHibernate.Enumerated.Pickados;


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Post_verifyPost) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class PostCEN
{
public void VerifyPost (int p_oid, PostCEN postCEN, TipsterCEN tipsterCEN, StatsCEN statsCEN)
{
            /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Post_verifyPost) ENABLED START*/

            // Write here your custom code...
           
            
            PostEN postEN = postCEN.GetByID(p_oid);

            if (postEN != null) {

                //Comprobamos que el pick o los picks hayan finalizado
                if(postEN.Pick!=null && postEN.Pick.Any())
                {
                    Boolean finished = true;
                    foreach (PickEN pick in postEN.Pick)
                    {
                        if (pick.PickResult.Equals(PickResultEnum.unfinished) ||
                           pick.PickResult.Equals(PickResultEnum.unstarted)) {
                            finished = false;
                        }
                    }

                    if (finished) {

                        
                        
                        TipsterEN tipsterEN = tipsterCEN.GetByID(postEN.Tipster.Id);

                        //Comprueba si hay stats creadas, si no, crea para este mes
                        
                            
                            
                            StatsEN statsEN = new StatsEN();
                            statsEN.Tipster = postEN.Tipster;
                            int id_stats = 0;
                        if (tipsterEN.MonthlyStats != null && !tipsterEN.MonthlyStats.Any())
                        {
                            id_stats = statsCEN.get_IStatsCAD().NewMonthlyStats(statsEN);
                        }
                        else {
                            Boolean exist = false;
                            StatsEN statsENaux = new StatsEN();

                            //Comprobamos entre las existentes si hay alguna de este mes.
                            //Se puede mejorar accediendo directamente a la última creada
                            foreach (StatsEN stats in tipsterEN.MonthlyStats)
                            {
                                
                                if (stats.InitialDate.Value.Month.Equals(DateTime.Now.Month) )
                                {
                                    
                                    id_stats = stats.Id;
                                    exist = true;
                                }
                            }


                            if (!exist)
                            {
                                id_stats = statsCEN.get_IStatsCAD().NewMonthlyStats(statsEN);
                            }

                        }

                        statsEN = statsCEN.GetByID(id_stats);
                        statsEN.TotalPicks += 1;
                        statsEN.OddAccumulator += postEN.TotalOdd;
                        statsEN.TotalStaked += postEN.Stake;
                        statsEN.OddAverage = statsEN.OddAccumulator / statsEN.TotalPicks;
                        statsEN.StakeAverage = statsEN.TotalStaked / statsEN.TotalPicks;


                        //TODO- Compute multiple picks with some push one
                        //Verifying pick results
                        postEN.PostResult = PickResultEnum.won;

                        if (postEN.Pick.Count() == 1) postEN.PostResult = postEN.Pick.First().PickResult;
                        else {
                            foreach (PickEN pick in postEN.Pick)
                            {
                                if (pick.PickResult.Equals(PickResultEnum.lost))
                                {
                                    postEN.PostResult  = PickResultEnum.lost;
                                }
                            }
                        }


                        
                        switch (postEN.PostResult)
                            {
                                case PickResultEnum.won:
                                double benef = postEN.TotalOdd * postEN.Stake - postEN.Stake;
                                statsEN.Benefit += benef;
                                
                                    break;
                                case PickResultEnum.lost:
                                statsEN.Benefit -= postEN.Stake;
                                    //statsEN.Yield
                                    break;
                                default:
                                    Console.WriteLine("Not recognise ");
                                    break;
                            }

                        statsEN.Yield = (float) (statsEN.Benefit / statsEN.TotalStaked * 100);

                        //Actualizamos y guardamos las stats

                        statsCEN.get_IStatsCAD().ModifyMonthlyStats(statsEN);
                    }
                }


            }

        /*PROTECTED REGION END*/
}
}
}
