using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class PostDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private TimeSpan created_at;
public TimeSpan Created_at {
        get { return created_at; } set { created_at = value;  }
}
private TimeSpan modified_at;
public TimeSpan Modified_at {
        get { return modified_at; } set { modified_at = value;  }
}
private double stake;
public double Stake {
        get { return stake; } set { stake = value;  }
}
private string description;
public string Description {
        get { return description; } set { description = value;  }
}
private bool private_;
public bool Private_ {
        get { return private_; } set { private_ = value;  }
}


private System.Collections.Generic.IList<int> pick_oid;
public System.Collections.Generic.IList<int> Pick_oid {
        get { return pick_oid; } set { pick_oid = value;  }
}



private int tipster_oid;
public int Tipster_oid {
        get { return tipster_oid; } set { tipster_oid = value;  }
}

private double totalOdd;
public double TotalOdd {
        get { return totalOdd; } set { totalOdd = value;  }
}
private PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum postResult;
public PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum PostResult {
        get { return postResult; } set { postResult = value;  }
}
}
}
