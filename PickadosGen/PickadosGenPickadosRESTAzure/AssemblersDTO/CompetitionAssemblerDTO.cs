using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class CompetitionAssemblerDTO {
public static IList<CompetitionEN> ConvertList (IList<CompetitionDTO> lista)
{
        IList<CompetitionEN> result = new List<CompetitionEN>();
        foreach (CompetitionDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CompetitionEN Convert (CompetitionDTO dto)
{
        CompetitionEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CompetitionEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Name = dto.Name;

                        if (dto.Event_ != null) {
                                PickadosGenNHibernate.CAD.Pickados.IEvent_CAD event_CAD = new PickadosGenNHibernate.CAD.Pickados.Event_CAD ();

                                newinstance.Event_ = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.Event_EN>();
                                foreach (Event_DTO entry in dto.Event_) {
                                        newinstance.Event_.Add (Event_AssemblerDTO.Convert (entry));
                                }
                        }
                        if (dto.Sport_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ISportCAD sportCAD = new PickadosGenNHibernate.CAD.Pickados.SportCAD ();

                                newinstance.Sport = sportCAD.ReadOIDDefault (dto.Sport_oid);
                        }
                        newinstance.Place = dto.Place;
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
