
using System;
using System.Text;
using ProjectGenNHibernate.CEN.Project;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProjectGenNHibernate.EN.Project;
using ProjectGenNHibernate.Exceptions;

namespace ProjectGenNHibernate.CAD.Project
{
public partial class PostCAD : BasicCAD, IPostCAD
{
public PostCAD() : base ()
{
}

public PostCAD(ISession sessionAux) : base (sessionAux)
{
}



public PostEN ReadOIDDefault (int id)
{
        PostEN postEN = null;

        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Get (typeof(PostEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return postEN;
}


public int Create (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                if (post.User != null) {
                        post.User = (ProjectGenNHibernate.EN.Project.UsuarioEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UsuarioEN), post.User.Nickname);

                        post.User.Post.Add (post);
                }

                session.Save (post);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return post.Id;
}

public void Delete (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), id);
                session.Delete (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
