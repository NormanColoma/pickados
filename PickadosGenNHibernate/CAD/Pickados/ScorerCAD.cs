
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
 * Clase Scorer:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class ScorerCAD : BasicCAD, IScorerCAD
{
public ScorerCAD() : base ()
{
}

public ScorerCAD(ISession sessionAux) : base (sessionAux)
{
}



public ScorerEN ReadOIDDefault (int id
                                )
{
        ScorerEN scorerEN = null;

        try
        {
                SessionInitializeTransaction ();
                scorerEN = (ScorerEN)session.Get (typeof(ScorerEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in ScorerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return scorerEN;
}

public System.Collections.Generic.IList<ScorerEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ScorerEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ScorerEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ScorerEN>();
                        else
                                result = session.CreateCriteria (typeof(ScorerEN)).List<ScorerEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in ScorerCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ScorerEN scorer)
{
        try
        {
                SessionInitializeTransaction ();
                ScorerEN scorerEN = (ScorerEN)session.Load (typeof(ScorerEN), scorer.Id);

                scorerEN.Scorer_name = scorer.Scorer_name;


                session.Update (scorerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in ScorerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewScorer (ScorerEN scorer)
{
        try
        {
                SessionInitializeTransaction ();
                if (scorer.Event_rel != null) {
                        // Argumento OID y no colección.
                        scorer.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), scorer.Event_rel.Id);

                        scorer.Event_rel.Pick_rel
                        .Add (scorer);
                }
                if (scorer.Player != null) {
                        // Argumento OID y no colección.
                        scorer.Player = (PickadosGenNHibernate.EN.Pickados.PlayerEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.PlayerEN), scorer.Player.Id);

                        scorer.Player.Scorer
                        .Add (scorer);
                }

                session.Save (scorer);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in ScorerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return scorer.Id;
}

public void Modify (ScorerEN scorer)
{
        try
        {
                SessionInitializeTransaction ();
                ScorerEN scorerEN = (ScorerEN)session.Load (typeof(ScorerEN), scorer.Id);

                scorerEN.Odd = scorer.Odd;


                scorerEN.Description = scorer.Description;


                scorerEN.PickResult = scorer.PickResult;


                scorerEN.Bookie = scorer.Bookie;


                scorerEN.Scorer_name = scorer.Scorer_name;

                session.Update (scorerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in ScorerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ScorerEN scorerEN = (ScorerEN)session.Load (typeof(ScorerEN), id);
                session.Delete (scorerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in ScorerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
