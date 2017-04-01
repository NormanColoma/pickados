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
public static class AdminAssembler
{
public static AdminDTOA Convert (AdminEN en, NHibernate.ISession session = null)
{
        AdminDTOA dto = null;
        AdminRESTCAD adminRESTCAD = null;
        AdminCEN adminCEN = null;
        AdminCP adminCP = null;

        if (en != null) {
                dto = new AdminDTOA ();
                adminRESTCAD = new AdminRESTCAD (session);
                adminCEN = new AdminCEN (adminRESTCAD);
                adminCP = new AdminCP (session);


                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
