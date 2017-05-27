using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class TipsterDTO                 :                           UsuarioDTO


{
private System.Collections.Generic.IList<StatsDTO> monthlyStats;
public System.Collections.Generic.IList<StatsDTO> MonthlyStats {
        get { return monthlyStats; } set { monthlyStats = value;  }
}
private System.Collections.Generic.IList<PostDTO> post;
public System.Collections.Generic.IList<PostDTO> Post {
        get { return post; } set { post = value;  }
}


private System.Collections.Generic.IList<int> follow_to_oid;
public System.Collections.Generic.IList<int> Follow_to_oid {
        get { return follow_to_oid; } set { follow_to_oid = value;  }
}



private System.Collections.Generic.IList<int> followed_by_oid;
public System.Collections.Generic.IList<int> Followed_by_oid {
        get { return followed_by_oid; } set { followed_by_oid = value;  }
}

private bool premium;
public bool Premium {
        get { return premium; } set { premium = value;  }
}
private double subscription_fee;
public double Subscription_fee {
        get { return subscription_fee; } set { subscription_fee = value;  }
}
private bool locked;
public bool Locked {
        get { return locked; } set { locked = value;  }
}
}
}
