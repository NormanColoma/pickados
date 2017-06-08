using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class LoginAssemblerDTO {
public static IList<LoginEN> ConvertList (IList<LoginDTO> lista)
{
        IList<LoginEN> result = new List<LoginEN>();
        foreach (LoginDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LoginEN Convert (LoginDTO dto)
{
        LoginEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LoginEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Alias = dto.Alias;
                        newinstance.Date = dto.Date;
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
