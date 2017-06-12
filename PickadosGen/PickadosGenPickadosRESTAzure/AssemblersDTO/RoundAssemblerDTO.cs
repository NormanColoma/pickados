using System;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenPickadosRESTAzure.DTO;

namespace PickadosGenPickadosRESTAzure.AssemblersDTO
{
public class RoundAssemblerDTO {
public static IList<RoundEN> ConvertList (IList<RoundDTO> lista)
{
        IList<RoundEN> result = new List<RoundEN>();
        foreach (RoundDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static RoundEN Convert (RoundDTO dto)
{
        RoundEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new RoundEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Season_oid != -1) {
                                PickadosGenNHibernate.CAD.Pickados.ISeasonCAD seasonCAD = new PickadosGenNHibernate.CAD.Pickados.SeasonCAD ();

                                newinstance.Season = seasonCAD.ReadOIDDefault (dto.Season_oid);
                        }
                        if (dto.Event__oid != null) {
                                PickadosGenNHibernate.CAD.Pickados.IEvent_CAD event_CAD = new PickadosGenNHibernate.CAD.Pickados.Event_CAD ();

                                newinstance.Event_ = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.Event_EN>();
                                foreach (int entry in dto.Event__oid) {
                                        newinstance.Event_.Add (event_CAD.ReadOIDDefault (entry));
                                }
                        }
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
