using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class PostDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private Nullable<DateTime> created_at;
public Nullable<DateTime> Created_at
{
        get { return created_at; }
        set { created_at = value; }
}

private string description;
public string Description
{
        get { return description; }
        set { description = value; }
}

private PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum postResult;
public PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum PostResult
{
        get { return postResult; }
        set { postResult = value; }
}

private double stake;
public double Stake
{
        get { return stake; }
        set { stake = value; }
}

private double totalOdd;
public double TotalOdd
{
        get { return totalOdd; }
        set { totalOdd = value; }
}


/* Rol: Post o--> Pick */
private IList<PickDTOA> getAllPickOfPost;
public IList<PickDTOA> GetAllPickOfPost
{
        get { return getAllPickOfPost; }
        set { getAllPickOfPost = value; }
}

        private String tipster;

        public String Tipster
        {
            get { return tipster; }
            set { tipster = value; }
        }
    }
}


