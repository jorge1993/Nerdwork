
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
    public partial class GroupsCEN : BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> GetAllPost (int arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Groups_getAllPost) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> lista = new System.Collections.Generic.List<PostEN>();
        try
        {
                SessionInitializeTransaction ();
                PostCAD postcad = new PostCAD (session);
                GroupsCAD groupcad = new GroupsCAD (session);
                GroupsEN groupen = groupcad.ReadOIDDefault (arg0);

                foreach (PostEN pos in groupen.Post) {
                        lista.Add (pos);
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
