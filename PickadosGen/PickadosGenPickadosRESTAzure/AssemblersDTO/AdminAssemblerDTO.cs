using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class AdminAssemblerDTO {
public static IList<AdminEN> ConvertList (IList<AdminDTO> lista)
{
        IList<AdminEN> result = new List<AdminEN>();
        foreach (AdminDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static AdminEN Convert (AdminDTO dto)
{
        AdminEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new AdminEN ();



                        newinstance.Id = dto.Id;
                        newinstance.CreatedAt = dto.CreatedAt;
                        newinstance.ModifiedAt = dto.ModifiedAt;
                        newinstance.Alias = dto.Alias;
                        newinstance.Email = dto.Email;
                        newinstance.Password = dto.Password;
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
