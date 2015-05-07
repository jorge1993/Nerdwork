
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
public partial class PostCEN
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> GetUserPosts (string userNickname)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Post_getUserPosts) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> lista = new System.Collections.Generic.List<PostEN>();
        try
        {
                SessionInitializeTransaction ();
                PostCAD postcad = new PostCAD (session);
                UsuarioCAD usercad = new UsuarioCAD (session);
                UsuarioEN useren = usercad.ReadOIDDefault (userNickname);

                foreach (PostEN post in useren.Post) {
                        lista.Add (post);
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
