using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class PostDTOA
{
private double stake;
public double Stake
{
        get { return stake; }
        set { stake = value; }
}

private Nullable<DateTime> modified_at;
public Nullable<DateTime> Modified_at
{
        get { return modified_at; }
        set { modified_at = value; }
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

private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


/* Rol: Post o--> Pick */
private IList<PickDTOA> getAllPickOfPost;
public IList<PickDTOA> GetAllPickOfPost
{
        get { return getAllPickOfPost; }
        set { getAllPickOfPost = value; }
}
}
}
