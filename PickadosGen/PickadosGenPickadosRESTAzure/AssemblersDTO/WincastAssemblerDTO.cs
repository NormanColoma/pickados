using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class WincastAssemblerDTO {
public static IList<WincastEN> ConvertList (IList<WincastDTO> lista)
{
        IList<WincastEN> result = new List<WincastEN>();
        foreach (WincastDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static WincastEN Convert (WincastDTO dto)
{
        WincastEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new WincastEN ();



                        newinstance.Team_name = dto.Team_name;
                        newinstance.Scorer_name = dto.Scorer_name;
                        if (dto.Player_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.IPlayerCAD playerCAD = new PickadosGenNHibernate.CAD.Pickados.PlayerCAD ();

                                newinstance.Player = playerCAD.ReadOIDDefault (dto.Player_oid);
                        }
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
