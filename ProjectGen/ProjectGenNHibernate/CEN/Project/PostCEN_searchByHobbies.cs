
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
    public partial class PostCEN : BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> SearchByHobbies (string arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Post_searchByHobbies) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> lista = new System.Collections.Generic.List<PostEN>();
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> listaux = new System.Collections.Generic.List<PostEN>();
        try
        {
                SessionInitializeTransaction ();
                HobbyCAD hobbycad = new HobbyCAD (session);
                PostCAD postcad = new PostCAD (session);
                listaux = postcad.GetAllPost ();

                foreach (PostEN eve in listaux) {
                        foreach (HobbyEN ho in eve.Hobby) {
                                if (ho.Name.Contains (arg0)) {
                                        lista.Add (eve);
                                        break;
                                }
                        }
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
