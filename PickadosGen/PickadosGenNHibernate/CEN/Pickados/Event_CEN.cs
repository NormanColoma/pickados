

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
 *      Definition of the class Event_CEN
 *
 */
public partial class Event_CEN
{
private IEvent_CAD _IEvent_CAD;

public Event_CEN()
{
        this._IEvent_CAD = new Event_CAD ();
}

public Event_CEN(IEvent_CAD _IEvent_CAD)
{
        this._IEvent_CAD = _IEvent_CAD;
}

public IEvent_CAD get_IEvent_CAD ()
{
        return this._IEvent_CAD;
}

public int NewEvent (Nullable<DateTime> p_date)
{
        Event_EN event_EN = null;
        int oid;

        //Initialized Event_EN
        event_EN = new Event_EN ();
        event_EN.Date = p_date;

        //Call to Event_CAD

        oid = _IEvent_CAD.NewEvent (event_EN);
        return oid;
}

public void ModifyEvent (int p_Event_OID, Nullable<DateTime> p_date)
{
        Event_EN event_EN = null;

        //Initialized Event_EN
        event_EN = new Event_EN ();
        event_EN.Id = p_Event_OID;
        event_EN.Date = p_date;
        //Call to Event_CAD

        _IEvent_CAD.ModifyEvent (event_EN);
}

public void DeleteEvent (int id
                         )
{
        _IEvent_CAD.DeleteEvent (id);
}

public Event_EN GetEventById (int id
                              )
{
        Event_EN event_EN = null;

        event_EN = _IEvent_CAD.GetEventById (id);
        return event_EN;
}

public System.Collections.Generic.IList<Event_EN> GetAllEvents (int first, int size)
{
        System.Collections.Generic.IList<Event_EN> list = null;

        list = _IEvent_CAD.GetAllEvents (first, size);
        return list;
}
public void JoinCompetition (int p_Event_OID, int p_competition_OID)
{
        //Call to Event_CAD

        _IEvent_CAD.JoinCompetition (p_Event_OID, p_competition_OID);
}
public void UnlinkCompetition (int p_Event_OID, int p_competition_OID)
{
        //Call to Event_CAD

        _IEvent_CAD.UnlinkCompetition (p_Event_OID, p_competition_OID);
}
}
}
