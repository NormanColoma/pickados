using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class HandicapAssemblerDTO {
public static IList<HandicapEN> ConvertList (IList<HandicapDTO> lista)
{
        IList<HandicapEN> result = new List<HandicapEN>();
        foreach (HandicapDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static HandicapEN Convert (HandicapDTO dto)
{
        HandicapEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new HandicapEN ();



                        newinstance.Result = dto.Result;
                        newinstance.Line = dto.Line;
                        newinstance.Quantity = dto.Quantity;
                        newinstance.Asian = dto.Asian;
                        newinstance.Id = dto.Id;
                        newinstance.Odd = dto.Odd;
                        newinstance.Description = dto.Description;
                        newinstance.PickResult = dto.PickResult;
                        newinstance.Bookie = dto.Bookie;
                        if (dto.Post_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IPostCAD postCAD = new PickadosGenNHibernate.CAD.Pickados.PostCAD ();

                                newinstance.Post = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PostEN>();
                                foreach (int entry in dto.Post_oid) {
                                        newinstance.Post.Add (postCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Event_rel_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.IEvent_CAD event_CAD = new PickadosGenNHibernate.CAD.Pickados.Event_CAD ();

                                newinstance.Event_rel = event_CAD.ReadOIDDefault (dto.Event_rel_oid);
                        }
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
