using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class RequestDTO
{
private int post_oid;
public int Post_oid {
        get { return post_oid; } set { post_oid = value;  }
}

private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum type;
public PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum Type {
        get { return type; } set { type = value;  }
}
private string reason;
public string Reason {
        get { return reason; } set { reason = value;  }
}
private PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum state;
public PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum State {
        get { return state; } set { state = value;  }
}
private Nullable<DateTime> date;
public Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}
private string adminComment;
public string AdminComment {
        get { return adminComment; } set { adminComment = value;  }
}
}
}
