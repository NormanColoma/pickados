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
public static class PostAssembler
{
public static PostDTOA Convert (PostEN en, NHibernate.ISession session = null)
{
        PostDTOA dto = null;
        PostRESTCAD postRESTCAD = null;
        PostCEN postCEN = null;
        PostCP postCP = null;

        if (en != null) {
                dto = new PostDTOA ();
                postRESTCAD = new PostRESTCAD (session);
                postCEN = new PostCEN (postRESTCAD);
                postCP = new PostCP (session);


                //
                // Attributes

                dto.Id = en.Id;
                dto.Stake = en.Stake;
                dto.Description = en.Description;
                dto.TotalOdd = en.TotalOdd;

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
