using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using PickadosGenPickadosRESTAzure.DTOA;
using PickadosGenPickadosRESTAzure.CAD;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CP.Pickados;

namespace PickadosGenPickadosRESTAzure.Assemblers
{
public static class Event_Assembler
{
public static Event_DTOA Convert (Event_EN en, NHibernate.ISession session = null)
{
        Event_DTOA dto = null;
        Event_RESTCAD event_RESTCAD = null;
        Event_CEN event_CEN = null;
        Event_CP event_CP = null;

        if (en != null) {
                dto = new Event_DTOA ();
                event_RESTCAD = new Event_RESTCAD (session);
                event_CEN = new Event_CEN (event_RESTCAD);
                event_CP = new Event_CP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Date = en.Date;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
