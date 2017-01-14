

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
 *      Definition of the class CompetitionCEN
 *
 */
public partial class CompetitionCEN
{
private ICompetitionCAD _ICompetitionCAD;

public CompetitionCEN()
{
        this._ICompetitionCAD = new CompetitionCAD ();
}

public CompetitionCEN(ICompetitionCAD _ICompetitionCAD)
{
        this._ICompetitionCAD = _ICompetitionCAD;
}

public ICompetitionCAD get_ICompetitionCAD ()
{
        return this._ICompetitionCAD;
}

public int NewCompetition (string p_name, int p_sport)
{
        CompetitionEN competitionEN = null;
        int oid;

        //Initialized CompetitionEN
        competitionEN = new CompetitionEN ();
        competitionEN.Name = p_name;


        if (p_sport != -1) {
                // El argumento p_sport -> Property sport es oid = false
                // Lista de oids id
                competitionEN.Sport = new PickadosGenNHibernate.EN.Pickados.SportEN ();
                competitionEN.Sport.Id = p_sport;
        }

        //Call to CompetitionCAD

        oid = _ICompetitionCAD.NewCompetition (competitionEN);
        return oid;
}

public void ModifyCompetition (int p_Competition_OID, string p_name)
{
        CompetitionEN competitionEN = null;

        //Initialized CompetitionEN
        competitionEN = new CompetitionEN ();
        competitionEN.Id = p_Competition_OID;
        competitionEN.Name = p_name;
        //Call to CompetitionCAD

        _ICompetitionCAD.ModifyCompetition (competitionEN);
}

public void DeleteCompetition (int id
                               )
{
        _ICompetitionCAD.DeleteCompetition (id);
}
}
}
