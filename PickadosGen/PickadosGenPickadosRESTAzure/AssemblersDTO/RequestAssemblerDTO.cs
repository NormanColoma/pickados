using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class RequestAssemblerDTO {
public static IList<RequestEN> ConvertList (IList<RequestDTO> lista)
{
        IList<RequestEN> result = new List<RequestEN>();
        foreach (RequestDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static RequestEN Convert (RequestDTO dto)
{
        RequestEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new RequestEN ();



                        if (dto.Post_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.IPostCAD postCAD = new PickadosGenNHibernate.CAD.Pickados.PostCAD ();

                                newinstance.Post = postCAD.ReadOIDDefault (dto.Post_oid);
                        }
                        newinstance.Id = dto.Id;
                        newinstance.Type = dto.Type;
                        newinstance.Reason = dto.Reason;
                        newinstance.State = dto.State;
                        newinstance.Date = dto.Date;
                        newinstance.AdminComment = dto.AdminComment;
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
