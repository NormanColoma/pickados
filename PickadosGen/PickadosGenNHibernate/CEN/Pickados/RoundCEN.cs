

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
 *      Definition of the class RoundCEN
 *
 */
public partial class RoundCEN
{
private IRoundCAD _IRoundCAD;

public RoundCEN()
{
        this._IRoundCAD = new RoundCAD ();
}

public RoundCEN(IRoundCAD _IRoundCAD)
{
        this._IRoundCAD = _IRoundCAD;
}

public IRoundCAD get_IRoundCAD ()
{
        return this._IRoundCAD;
}

public int NewRound (int p_season, string p_name)
{
        RoundEN roundEN = null;
        int oid;

        //Initialized RoundEN
        roundEN = new RoundEN ();

        if (p_season != -1) {
                // El argumento p_season -> Property season es oid = false
                // Lista de oids id
                roundEN.Season = new PickadosGenNHibernate.EN.Pickados.SeasonEN ();
                roundEN.Season.Id = p_season;
        }

        roundEN.Name = p_name;

        //Call to RoundCAD

        oid = _IRoundCAD.NewRound (roundEN);
        return oid;
}

public void ModifyRound (int p_Round_OID, string p_name)
{
        RoundEN roundEN = null;

        //Initialized RoundEN
        roundEN = new RoundEN ();
        roundEN.Id = p_Round_OID;
        roundEN.Name = p_name;
        //Call to RoundCAD

        _IRoundCAD.ModifyRound (roundEN);
}

public void DestroyRound (int id
                          )
{
        _IRoundCAD.DestroyRound (id);
}

public RoundEN ReadOID (int id
                        )
{
        RoundEN roundEN = null;

        roundEN = _IRoundCAD.ReadOID (id);
        return roundEN;
}

public System.Collections.Generic.IList<RoundEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RoundEN> list = null;

        list = _IRoundCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RoundEN> GetRoundBySeason (int id)
{
        return _IRoundCAD.GetRoundBySeason (id);
}
}
}
