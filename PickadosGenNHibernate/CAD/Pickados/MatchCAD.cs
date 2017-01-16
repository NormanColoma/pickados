
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
 * Clase Match:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial class MatchCAD : BasicCAD, IMatchCAD
    {
        public MatchCAD() : base()
        {
        }

        public MatchCAD(ISession sessionAux) : base(sessionAux)
        {
        }



        public MatchEN ReadOIDDefault(int id
                                       )
        {
            MatchEN matchEN = null;

            try
            {
                SessionInitializeTransaction();
                matchEN = (MatchEN)session.Get(typeof(MatchEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return matchEN;
        }

        public System.Collections.Generic.IList<MatchEN> ReadAllDefault(int first, int size)
        {
            System.Collections.Generic.IList<MatchEN> result = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (size > 0)
                        result = session.CreateCriteria(typeof(MatchEN)).
                                 SetFirstResult(first).SetMaxResults(size).List<MatchEN>();
                    else
                        result = session.CreateCriteria(typeof(MatchEN)).List<MatchEN>();
                }
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }

            return result;
        }

        // Modify default (Update all attributes of the class)

        public void ModifyDefault(MatchEN match)
        {
            try
            {
                SessionInitializeTransaction();
                MatchEN matchEN = (MatchEN)session.Load(typeof(MatchEN), match.Id);



                matchEN.Stadium = match.Stadium;

                session.Update(matchEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }


        public int NewMatch(MatchEN match)
        {
            try
            {
                SessionInitializeTransaction();
                if (match.Away != null)
                {
                    // Argumento OID y no colección.
                    match.Away = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load(typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), match.Away.Id);

                    match.Away.Event_away
                    .Add(match);
                }
                if (match.Home != null)
                {
                    // Argumento OID y no colección.
                    match.Home = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load(typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), match.Home.Id);

                    match.Home.Event_home
                    .Add(match);
                }

                session.Save(match);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return match.Id;
        }

        public void ModifyMatch(MatchEN match)
        {
            try
            {
                SessionInitializeTransaction();
                MatchEN matchEN = (MatchEN)session.Load(typeof(MatchEN), match.Id);

                matchEN.Date = match.Date;


                matchEN.Stadium = match.Stadium;

                session.Update(matchEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        public void DeleteMatch(int id
                                 )
        {
            try
            {
                SessionInitializeTransaction();
                MatchEN matchEN = (MatchEN)session.Load(typeof(MatchEN), id);
                session.Delete(matchEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }

        //Sin e: GetMatchById
        //Con e: MatchEN
        public MatchEN GetMatchById(int id
                                     )
        {
            MatchEN matchEN = null;

            try
            {
                SessionInitializeTransaction();
                matchEN = (MatchEN)session.Get(typeof(MatchEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return matchEN;
        }

        public System.Collections.Generic.IList<MatchEN> GetAllMatches(int first, int size)
        {
            System.Collections.Generic.IList<MatchEN> result = null;
            try
            {
                SessionInitializeTransaction();
                if (size > 0)
                    result = session.CreateCriteria(typeof(MatchEN)).
                             SetFirstResult(first).SetMaxResults(size).List<MatchEN>();
                else
                    result = session.CreateCriteria(typeof(MatchEN)).List<MatchEN>();
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }

        public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByTeam(string team)
        {
            System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> result;
            try
            {
                SessionInitializeTransaction();
                //String sql = @"FROM MatchEN self where FROM MatchEN m WHERE m.home := team or m.away := team";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery("MatchENgetMatchByTeamHQL");
                query.SetParameter("home", team);
                query.SetParameter("away", team);

                result = query.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }

        public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByCompetition(string competition)
        {
            System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> result;
            try
            {
                SessionInitializeTransaction();
                //String sql = @"FROM MatchEN self where FROM MatchEN m where m.competition := competition";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery("MatchENgetMatchByCompetitionHQL");
                query.SetParameter("competition", competition);

                result = query.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in MatchCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
