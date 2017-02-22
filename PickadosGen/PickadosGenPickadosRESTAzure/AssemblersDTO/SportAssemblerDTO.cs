using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class SportAssemblerDTO {
public static IList<SportEN> ConvertList (IList<SportDTO> lista)
{
        IList<SportEN> result = new List<SportEN>();
        foreach (SportDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static SportEN Convert (SportDTO dto)
{
        SportEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new SportEN ();




                        if (dto.Competition != null) {
                                PickadosGenNHibernate.CAD.Pickados.ICompetitionCAD competitionCAD = new PickadosGenNHibernate.CAD.Pickados.CompetitionCAD ();

                                newinstance.Competition = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.CompetitionEN>();
                                foreach (CompetitionDTO entry in dto.Competition) {
                                        newinstance.Competition.Add (CompetitionAssemblerDTO.Convert (entry));
                                }
                        }
                        newinstance.Id = dto.Id;
                        newinstance.Name = dto.Name;
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
