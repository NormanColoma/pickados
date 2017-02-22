using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class Event_AssemblerDTO {
public static IList<Event_EN> ConvertList (IList<Event_DTO> lista)
{
        IList<Event_EN> result = new List<Event_EN>();
        foreach (Event_DTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static Event_EN Convert (Event_DTO dto)
{
        Event_EN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new Event_EN ();



                        newinstance.Id = dto.Id;
                        if (dto.Competition_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ICompetitionCAD competitionCAD = new PickadosGenNHibernate.CAD.Pickados.CompetitionCAD ();

                                newinstance.Competition = competitionCAD.ReadOIDDefault (dto.Competition_oid);
                        }

                        if (dto.Pick_rel != null) {
                                PickadosGenNHibernate.CAD.Pickados.IPickCAD pickCAD = new PickadosGenNHibernate.CAD.Pickados.PickCAD ();

                                newinstance.Pick_rel = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
                                foreach (PickDTO entry in dto.Pick_rel) {
                                        newinstance.Pick_rel.Add (PickAssemblerDTO.Convert (entry));
                                }
                        }
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
