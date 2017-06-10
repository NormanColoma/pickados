using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class PostAssemblerDTO {
public static IList<PostEN> ConvertList (IList<PostDTO> lista)
{
        IList<PostEN> result = new List<PostEN>();
        foreach (PostDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static PostEN Convert (PostDTO dto)
{
        PostEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PostEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Created_at = dto.Created_at;
                        newinstance.Modified_at = dto.Modified_at;
                        newinstance.Stake = dto.Stake;
                        newinstance.Description = dto.Description;
                        newinstance.Private_ = dto.Private_;
                        if (dto.Pick_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IPickCAD pickCAD = new PickadosGenNHibernate.CAD.Pickados.PickCAD ();

                                newinstance.Pick = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
                                foreach (int entry in dto.Pick_oid) {
                                        newinstance.Pick.Add (pickCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Tipster_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ITipsterCAD tipsterCAD = new PickadosGenNHibernate.CAD.Pickados.TipsterCAD ();

                                newinstance.Tipster = tipsterCAD.ReadOIDDefault (dto.Tipster_oid);
                        }
                        newinstance.TotalOdd = dto.TotalOdd;
                        newinstance.PostResult = dto.PostResult;
                        if (dto.Request_oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IRequestCAD requestCAD = new PickadosGenNHibernate.CAD.Pickados.RequestCAD ();

                                newinstance.Request = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.RequestEN>();
                                foreach (int entry in dto.Request_oid) {
                                        newinstance.Request.Add (requestCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Likeit = dto.Likeit;
                        newinstance.Report = dto.Report;
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
