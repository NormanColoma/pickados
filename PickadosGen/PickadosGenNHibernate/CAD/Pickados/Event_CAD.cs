
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
 * Clase Event:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class Event_CAD : BasicCAD, IEvent_CAD
{
public Event_CAD() : base ()
{
}

public Event_CAD(ISession sessionAux) : base (sessionAux)
{
}



public Event_EN ReadOIDDefault (int id
                                )
{
        Event_EN event_EN = null;

        try
        {
                SessionInitializeTransaction ();
                event_EN = (Event_EN)session.Get (typeof(Event_EN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return event_EN;
}

public System.Collections.Generic.IList<Event_EN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Event_EN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Event_EN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Event_EN>();
                        else
                                result = session.CreateCriteria (typeof(Event_EN)).List<Event_EN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Event_EN event_)
{
        try
        {
                SessionInitializeTransaction ();
                Event_EN event_EN = (Event_EN)session.Load (typeof(Event_EN), event_.Id);



                event_EN.Date = event_.Date;


                session.Update (event_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewEvent (Event_EN event_)
{
        try
        {
                SessionInitializeTransaction ();
                if (event_.Round != null) {
                        // Argumento OID y no colección.
                        event_.Round = (PickadosGenNHibernate.EN.Pickados.RoundEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.RoundEN), event_.Round.Id);

                        event_.Round.Event_
                        .Add (event_);
                }

                session.Save (event_);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return event_.Id;
}

public void ModifyEvent (Event_EN event_)
{
        try
        {
                SessionInitializeTransaction ();
                Event_EN event_EN = (Event_EN)session.Load (typeof(Event_EN), event_.Id);

                event_EN.Date = event_.Date;

                session.Update (event_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteEvent (int id
                         )
{
        try
        {
                SessionInitializeTransaction ();
                Event_EN event_EN = (Event_EN)session.Load (typeof(Event_EN), id);
                session.Delete (event_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetEventById
//Con e: Event_EN
public Event_EN GetEventById (int id
                              )
{
        Event_EN event_EN = null;

        try
        {
                SessionInitializeTransaction ();
                event_EN = (Event_EN)session.Get (typeof(Event_EN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return event_EN;
}

public System.Collections.Generic.IList<Event_EN> GetAllEvents (int first, int size)
{
        System.Collections.Generic.IList<Event_EN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(Event_EN)).
                                 SetFirstResult (first).SetMaxResults (size).List<Event_EN>();
                else
                        result = session.CreateCriteria (typeof(Event_EN)).List<Event_EN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void JoinCompetition (int p_Event_OID, int p_competition_OID)
{
        PickadosGenNHibernate.EN.Pickados.Event_EN event_EN = null;
        try
        {
                SessionInitializeTransaction ();
                event_EN = (Event_EN)session.Load (typeof(Event_EN), p_Event_OID);
                event_EN.Competition = (PickadosGenNHibernate.EN.Pickados.CompetitionEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.CompetitionEN), p_competition_OID);

                event_EN.Competition.Event_.Add (event_EN);



                session.Update (event_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void UnlinkCompetition (int p_Event_OID, int p_competition_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PickadosGenNHibernate.EN.Pickados.Event_EN event_EN = null;
                event_EN = (Event_EN)session.Load (typeof(Event_EN), p_Event_OID);

                if (event_EN.Competition.Id == p_competition_OID) {
                        event_EN.Competition = null;
                }
                else
                        throw new ModelException ("The identifier " + p_competition_OID + " in p_competition_OID you are trying to unrelationer, doesn't exist in Event_EN");

                session.Update (event_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in Event_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
