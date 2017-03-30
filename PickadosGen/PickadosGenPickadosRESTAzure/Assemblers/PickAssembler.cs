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
public static class PickAssembler
{
public static PickDTOA Convert (PickEN en, NHibernate.ISession session = null)
{
        PickDTOA dto = null;
        PickRESTCAD pickRESTCAD = null;
        PickCEN pickCEN = null;
        PickCP pickCP = null;

        if (en != null) {
                dto = new PickDTOA ();
                pickRESTCAD = new PickRESTCAD (session);
                pickCEN = new PickCEN (pickRESTCAD);
                pickCP = new PickCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Odd = en.Odd;
                dto.PickResult = en.PickResult;
                dto.Bookie = en.Bookie;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
