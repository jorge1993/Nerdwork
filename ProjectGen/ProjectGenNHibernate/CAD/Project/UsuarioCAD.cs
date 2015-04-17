
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
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (string nickname)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}


public string Create (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                if (usuario.Hobby != null) {
                        for (int i = 0; i < usuario.Hobby.Count; i++) {
                                usuario.Hobby [i] = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), usuario.Hobby [i].Name);
                                usuario.Hobby [i].User.Add (usuario);
                        }
                }

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Nickname;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Nickname);

                usuarioEN.Email = usuario.Email;


                usuarioEN.Password = usuario.Password;


                usuarioEN.Name = usuario.Name;


                usuarioEN.Surname = usuario.Surname;


                usuarioEN.Phone = usuario.Phone;


                usuarioEN.Avatar = usuario.Avatar;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Delete (string nickname)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), nickname);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public UsuarioEN Searchbynick (string nickname)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}
}
}
