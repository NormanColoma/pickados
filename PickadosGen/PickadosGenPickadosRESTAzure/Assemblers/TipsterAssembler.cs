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
public static class TipsterAssembler
{
public static TipsterDTOA Convert (TipsterEN en, NHibernate.ISession session = null)
{
        TipsterDTOA dto = null;
        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;
        TipsterCP tipsterCP = null;

        if (en != null) {
                dto = new TipsterDTOA ();
                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);
                tipsterCP = new TipsterCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Alias = en.Alias;
                dto.Email = en.Email;
                dto.Created_at = en.Created_at;
                dto.Premium = en.Premium;
                dto.Subscription_fee = en.Subscription_fee;
                dto.Nif = en.Nif;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
