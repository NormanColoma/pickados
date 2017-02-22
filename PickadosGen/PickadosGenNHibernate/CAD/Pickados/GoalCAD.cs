
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
 * Clase Goal:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class GoalCAD : BasicCAD, IGoalCAD
{
public GoalCAD() : base ()
{
}

public GoalCAD(ISession sessionAux) : base (sessionAux)
{
}



public GoalEN ReadOIDDefault (int id
                              )
{
        GoalEN goalEN = null;

        try
        {
                SessionInitializeTransaction ();
                goalEN = (GoalEN)session.Get (typeof(GoalEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in GoalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return goalEN;
}

public System.Collections.Generic.IList<GoalEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GoalEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GoalEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GoalEN>();
                        else
                                result = session.CreateCriteria (typeof(GoalEN)).List<GoalEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in GoalCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (GoalEN goal)
{
        try
        {
                SessionInitializeTransaction ();
                GoalEN goalEN = (GoalEN)session.Load (typeof(GoalEN), goal.Id);

                goalEN.Line = goal.Line;


                goalEN.Quantity = goal.Quantity;


                goalEN.Asian = goal.Asian;

                session.Update (goalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in GoalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewGoal (GoalEN goal)
{
        try
        {
                SessionInitializeTransaction ();
                if (goal.Event_rel != null) {
                        // Argumento OID y no colección.
                        goal.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), goal.Event_rel.Id);

                        goal.Event_rel.Pick_rel
                        .Add (goal);
                }

                session.Save (goal);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in GoalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return goal.Id;
}

public void ModifyGoal (GoalEN goal)
{
        try
        {
                SessionInitializeTransaction ();
                GoalEN goalEN = (GoalEN)session.Load (typeof(GoalEN), goal.Id);

                goalEN.Odd = goal.Odd;


                goalEN.Description = goal.Description;


                goalEN.PickResult = goal.PickResult;


                goalEN.Bookie = goal.Bookie;


                goalEN.Line = goal.Line;


                goalEN.Quantity = goal.Quantity;


                goalEN.Asian = goal.Asian;

                session.Update (goalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in GoalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteGoal (int id
                        )
{
        try
        {
                SessionInitializeTransaction ();
                GoalEN goalEN = (GoalEN)session.Load (typeof(GoalEN), id);
                session.Delete (goalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in GoalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
