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
public static class LoggedInAdminAssembler
{
public static LoggedInAdminDTOA Convert (AdminEN en, NHibernate.ISession session = null)
{
        LoggedInAdminDTOA dto = null;
        LoggedInAdminRESTCAD loggedInAdminRESTCAD = null;
        AdminCEN adminCEN = null;
        AdminCP adminCP = null;

        if (en != null) {
                dto = new LoggedInAdminDTOA ();
                loggedInAdminRESTCAD = new LoggedInAdminRESTCAD (session);
                adminCEN = new AdminCEN (loggedInAdminRESTCAD);
                adminCP = new AdminCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Email = en.Email;
                dto.Alias = en.Alias;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
