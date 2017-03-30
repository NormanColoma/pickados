using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class UsuarioAssemblerDTO {
public static IList<UsuarioEN> ConvertList (IList<UsuarioDTO> lista)
{
        IList<UsuarioEN> result = new List<UsuarioEN>();
        foreach (UsuarioDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static UsuarioEN Convert (UsuarioDTO dto)
{
        UsuarioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new UsuarioEN ();



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
