

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


namespace PickadosGenNHibernate.CEN.Pickados
{
/*
 *      Definition of the class SeasonCEN
 *
 */
public partial class SeasonCEN
{
private ISeasonCAD _ISeasonCAD;

public SeasonCEN()
{
        this._ISeasonCAD = new SeasonCAD ();
}

public SeasonCEN(ISeasonCAD _ISeasonCAD)
{
        this._ISeasonCAD = _ISeasonCAD;
}

public ISeasonCAD get_ISeasonCAD ()
{
        return this._ISeasonCAD;
}

public int NewSeason (Nullable<DateTime> p_initDate, Nullable<DateTime> p_finalDate)
{
        SeasonEN seasonEN = null;
        int oid;

        //Initialized SeasonEN
        seasonEN = new SeasonEN ();
        seasonEN.InitDate = p_initDate;

        seasonEN.FinalDate = p_finalDate;

        //Call to SeasonCAD

        oid = _ISeasonCAD.NewSeason (seasonEN);
        return oid;
}

public void ModifySeason (int p_Season_OID, Nullable<DateTime> p_initDate, Nullable<DateTime> p_finalDate)
{
        SeasonEN seasonEN = null;

        //Initialized SeasonEN
        seasonEN = new SeasonEN ();
        seasonEN.Id = p_Season_OID;
        seasonEN.InitDate = p_initDate;
        seasonEN.FinalDate = p_finalDate;
        //Call to SeasonCAD

        _ISeasonCAD.ModifySeason (seasonEN);
}

public void DestroySeason (int id
                           )
{
        _ISeasonCAD.DestroySeason (id);
}

public SeasonEN GetSeasonByID (int id
                               )
{
        SeasonEN seasonEN = null;

        seasonEN = _ISeasonCAD.GetSeasonByID (id);
        return seasonEN;
}

public System.Collections.Generic.IList<SeasonEN> GetAllSeasons (int first, int size)
{
        System.Collections.Generic.IList<SeasonEN> list = null;

        list = _ISeasonCAD.GetAllSeasons (first, size);
        return list;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.SeasonEN> GetSeasonByCompetition (int id)
{
        return _ISeasonCAD.GetSeasonByCompetition (id);
}
}
}
