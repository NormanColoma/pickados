
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using System.Linq;


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Post_verifyPost) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class PostCEN
{
public void VerifyPost (int p_oid)
{
            /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Post_verifyPost) ENABLED START*/

            // Write here your custom code...
            PostCAD postCAD = new PostCAD();
            PostCEN postCEN = new PostCEN(postCAD);
            PostEN postEN = postCEN.GetByID(p_oid);

            if (postEN != null) {

                //Comprobamos que el pick o los picks hayan finalizado
                if(postEN.Pick!=null && postEN.Pick.Any())
                {
                    Boolean finished = true;
                    foreach (PickEN pick in postEN.Pick)
                    {
                        if (pick.PickResult.Equals(Enumerated.Pickados.PickResultEnum.unfinished) ||
                           pick.PickResult.Equals(Enumerated.Pickados.PickResultEnum.unstarted)) {
                            finished = false;
                        }
                    }

                    if (finished) {

                        TipsterCAD tipsterCAD = new TipsterCAD();
                        TipsterCEN tipsterCEN = new TipsterCEN(tipsterCAD);
                        TipsterEN tipsterEN = tipsterCEN.GetByID(postEN.Tipster.Id);

                        //Comprueba si hay stats creadas, si no, crea para este mes


                        //Si hay stats, actualiza la existente de este mes
                    }
                }


            }

        /*PROTECTED REGION END*/
}
}
}
