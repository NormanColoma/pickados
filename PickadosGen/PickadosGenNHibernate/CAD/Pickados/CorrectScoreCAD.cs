
using System;
using System.Text;
using PickadosGenNHibernate.CEN.Pickados;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Exceptions;


/*
 * Clase CorrectScore:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial class CorrectScoreCAD : BasicCAD, ICorrectScoreCAD
    {
        public CorrectScoreCAD() : base()
        {
        }

        public CorrectScoreCAD(ISession sessionAux) : base(sessionAux)
        {
        }



        public CorrectScoreEN ReadOIDDefault(int id
                                              )
        {
            CorrectScoreEN correctScoreEN = null;

            try
            {
                SessionInitializeTransaction();
                correctScoreEN = (CorrectScoreEN)session.Get(typeof(CorrectScoreEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in CorrectScoreCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return correctScoreEN;
        }

        public System.Collections.Generic.IList<CorrectScoreEN> ReadAllDefault(int first, int size)
        {
            System.Collections.Generic.IList<CorrectScoreEN> result = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (size > 0)
                        result = session.CreateCriteria(typeof(CorrectScoreEN)).
                                 SetFirstResult(first).SetMaxResults(size).List<CorrectScoreEN>();
                    else
                        result = session.CreateCriteria(typeof(CorrectScoreEN)).List<CorrectScoreEN>();
                }
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in CorrectScoreCAD.", ex);
            }

            return result;
        }

        // Modify default (Update all attributes of the class)

        public void ModifyDefault(CorrectScoreEN correctScore)
        {
            try
            {
                SessionInitializeTransaction();
                CorrectScoreEN correctScoreEN = (CorrectScoreEN)session.Load(typeof(CorrectScoreEN), correctScore.Id);

                correctScoreEN.HomeScore = correctScore.HomeScore;


                correctScoreEN.AwayScore = correctScore.AwayScore;

                session.Update(correctScoreEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in CorrectScoreCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }


        public int NewCorrectScore(CorrectScoreEN correctScore)
        {
            try
            {
                SessionInitializeTransaction();
                if (correctScore.Event_rel != null)
                {
                    // Argumento OID y no colección.
                    correctScore.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load(typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), correctScore.Event_rel.Id);

                    correctScore.Event_rel.Pick_rel
                    .Add(correctScore);
                }

                session.Save(correctScore);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in CorrectScoreCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return correctScore.Id;
        }

        public void ModifyCorrectScore(CorrectScoreEN correctScore)
        {
            try
            {
                SessionInitializeTransaction();
                CorrectScoreEN correctScoreEN = (CorrectScoreEN)session.Load(typeof(CorrectScoreEN), correctScore.Id);

                correctScoreEN.Odd = correctScore.Odd;


                correctScoreEN.Description = correctScore.Description;


                correctScoreEN.PickResult = correctScore.PickResult;


                correctScoreEN.Bookie = correctScore.Bookie;


                correctScoreEN.HomeScore = correctScore.HomeScore;


                correctScoreEN.AwayScore = correctScore.AwayScore;

                session.Update(correctScoreEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in CorrectScoreCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        public void DeleteCorrectScore(int id
                                        )
        {
            try
            {
                SessionInitializeTransaction();
                CorrectScoreEN correctScoreEN = (CorrectScoreEN)session.Load(typeof(CorrectScoreEN), id);
                session.Delete(correctScoreEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in CorrectScoreCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
    }
}
