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
                dto.Modified_at = en.Modified_at;
                dto.Created_at = en.Created_at;
                dto.Description = en.Description;
                dto.PostResult = en.PostResult;

                //
                // TravesalLink

                /* Rol: Post o--> Pick */
                dto.GetAllPickOfPost = null;
                List<PickEN> GetAllPickOfPost = postRESTCAD.GetAllPickOfPost (en.Id).ToList ();
                if (GetAllPickOfPost != null) {
                        dto.GetAllPickOfPost = new List<PickDTOA>();
                        foreach (PickEN entry in GetAllPickOfPost)
                                dto.GetAllPickOfPost.Add (PickAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
