
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using ProjectGenNHibernate.EN.Project;
using ProjectGenNHibernate.CAD.Project;

namespace ProjectGenNHibernate.CEN.Project
{
public partial class HobbyCEN
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> GetHobbybyID (int p_oid)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Hobby_getHobbybyID) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> lista = new System.Collections.Generic.List<HobbyEN>();
        try
        {
                SessionInitializeTransaction ();
                HobbyCAD hobbycad = new HobbyCAD (session);
                PostCAD postcad = new PostCAD (session);
                PostEN posten = postcad.ReadOIDDefault (p_oid);

                foreach (HobbyEN hobianos in posten.Hobby) {
                        lista.Add (hobianos);
                }
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
        }
        return lista;

        /*PROTECTED REGION END*/
}
}
}
