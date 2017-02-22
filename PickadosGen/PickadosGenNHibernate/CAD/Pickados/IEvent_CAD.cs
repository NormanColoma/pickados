
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial interface IEvent_CAD
    {
        Event_EN ReadOIDDefault(int id
                                 );

        void ModifyDefault(Event_EN event_);



        int NewEvent(Event_EN event_);

        void ModifyEvent(Event_EN event_);


        void DeleteEvent(int id
                          );


        Event_EN GetEventById(int id
                               );


        System.Collections.Generic.IList<Event_EN> GetAllEvents(int first, int size);


        void JoinCompetition(int p_Event_OID, int p_competition_OID);

        void UnlinkCompetition(int p_Event_OID, int p_competition_OID);
    }
}
