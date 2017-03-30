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
public static class RequestAssembler
{
public static RequestDTOA Convert (RequestEN en, NHibernate.ISession session = null)
{
        RequestDTOA dto = null;
        RequestRESTCAD requestRESTCAD = null;
        RequestCEN requestCEN = null;
        RequestCP requestCP = null;

        if (en != null) {
                dto = new RequestDTOA ();
                requestRESTCAD = new RequestRESTCAD (session);
                requestCEN = new RequestCEN (requestRESTCAD);
                requestCP = new RequestCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Type = en.Type;
                dto.Reason = en.Reason;
                dto.State = en.State;
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
