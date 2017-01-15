
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
public void VerifyPost (int p_oid)
{
            /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Post_verifyPost) ENABLED START*/

            // Write here your custom code...
            PostCAD postCAD = new PostCAD();
            PostCEN postCEN = new PostCEN(postCAD);
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

                        TipsterCAD tipsterCAD = new TipsterCAD();
                        TipsterCEN tipsterCEN = new TipsterCEN(tipsterCAD);
                        TipsterEN tipsterEN = tipsterCEN.GetByID(postEN.Tipster.Id);

                        //Comprueba si hay stats creadas, si no, crea para este mes
                        
                            StatsCAD statsCAD = new StatsCAD();
                            StatsCEN statsCEN = new StatsCEN(statsCAD);
                            StatsEN statsEN = new StatsEN();
                            statsEN.Tipster = postEN.Tipster;

                        if (tipsterEN.MonthlyStats != null && !tipsterEN.MonthlyStats.Any())
                        {
                            statsCAD.NewMonthlyStats(statsEN);
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
                                    statsENaux = statsCEN.GetByID(stats.Id);
                                    exist = true;
                                }
                            }


                            if (exist)
                            {
                                    //ACTUALIA EXISTENTE
                            }
                            else {
                                statsCAD.NewMonthlyStats(statsEN);

                            }
                        }

                        statsEN.InitialDate = DateTime.Now;

                            statsEN.TotalPicks += 1;
                           // statsEN.OddAverage = postEN.TotalOdd;
                            //statsEN.StakeAverage = postEN.Stake;

                            //TODO- AQUÍ recorrería los picks por si se trata de combinada, para fijar el pickresult de post.
                            postEN.PostResult = PickResultEnum.won;


                            //HACE FALTA UN ACUMULATEODD Y TOTALSTAKED
                            switch (postEN.PostResult)
                            {
                                case PickResultEnum.won:
                                    statsEN.Benefit += postEN.TotalOdd * postEN.Stake - postEN.Stake;
                                    //statsEN.Yield = benefit / totalstaked * 100
                                    break;
                                case PickResultEnum.lost:
                                    statsEN.Benefit -= postEN.Stake;
                                    //statsEN.Yield
                                    break;
                                case PickResultEnum.push:
                                    //statsEN.Yield
                                    break;
                                default:
                                    Console.WriteLine("Default case");
                                    break;
                            }
                        
                        //Si hay stats, actualiza la existente de este mes
                    }
                }


            }

        /*PROTECTED REGION END*/
}
}
}
