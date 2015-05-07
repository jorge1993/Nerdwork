
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
public partial class PostCEN :BasicCAD
{
public int GetMax ()
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Post_getMax) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> result = new System.Collections.Generic.List<PostEN>();
        try
        {
                SessionInitializeTransaction ();

                String sql = @"FROM PostEN self where select Max(post.id) FROM PostEN as post";
                IQuery query = session.CreateQuery (sql);

                // IList<PostEn> p = pos.



                /*UsuarioEN useren = usercad.ReadOIDDefault(emisor);
                 *
                 * foreach (MessagesEN message in useren.Messagessend)
                 * {
                 *  lista.Add(message);
                 * }*/
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
        }
        return result [0].Id;
        throw new NotImplementedException ("Method GetMax() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
