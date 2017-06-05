using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class TipsterAssemblerDTO {
public static IList<TipsterEN> ConvertList (IList<TipsterDTO> lista)
{
        IList<TipsterEN> result = new List<TipsterEN>();
        foreach (TipsterDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static TipsterEN Convert (TipsterDTO dto)
{
        TipsterEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new TipsterEN ();




                        if (dto.MonthlyStats != null) {
                                PickadosGenNHibernate.CAD.Pickados.IStatsCAD statsCAD = new PickadosGenNHibernate.CAD.Pickados.StatsCAD ();

                                newinstance.MonthlyStats = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.StatsEN>();
                                foreach (StatsDTO entry in dto.MonthlyStats) {
                                        newinstance.MonthlyStats.Add (StatsAssemblerDTO.Convert (entry));
                                }
                        }

                        if (dto.Post != null) {
                                PickadosGenNHibernate.CAD.Pickados.IPostCAD postCAD = new PickadosGenNHibernate.CAD.Pickados.PostCAD ();

                                newinstance.Post = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PostEN>();
                                foreach (PostDTO entry in dto.Post) {
                                        newinstance.Post.Add (PostAssemblerDTO.Convert (entry));
                                }
                        }
                        if (dto.Follow_to_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.ITipsterCAD tipsterCAD = new PickadosGenNHibernate.CAD.Pickados.TipsterCAD ();

                                newinstance.Follow_to = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                                foreach (int entry in dto.Follow_to_oid) {
                                        newinstance.Follow_to.Add (tipsterCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Followed_by_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.ITipsterCAD tipsterCAD = new PickadosGenNHibernate.CAD.Pickados.TipsterCAD ();

                                newinstance.Followed_by = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
                                foreach (int entry in dto.Followed_by_oid) {
                                        newinstance.Followed_by.Add (tipsterCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Premium = dto.Premium;
                        newinstance.Subscription_fee = dto.Subscription_fee;
                        newinstance.Locked = dto.Locked;
                        newinstance.Id = dto.Id;
                        newinstance.Alias = dto.Alias;
                        newinstance.Email = dto.Email;
                        newinstance.Password = dto.Password;
                        newinstance.Created_at = dto.Created_at;
                        newinstance.Updated_at = dto.Updated_at;
                        newinstance.Nif = dto.Nif;
                        newinstance.Admin = dto.Admin;
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
