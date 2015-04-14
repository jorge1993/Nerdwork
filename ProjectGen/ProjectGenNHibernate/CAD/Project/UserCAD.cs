
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
public partial class UserCAD : BasicCAD, IUserCAD
{
public UserCAD() : base ()
{
}

public UserCAD(ISession sessionAux) : base (sessionAux)
{
}



public UserEN ReadOIDDefault (string nickname)
{
        UserEN userEN = null;

        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Get (typeof(UserEN), nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userEN;
}


public string Create (UserEN user)
{
        try
        {
                SessionInitializeTransaction ();
                if (user.Hobby != null) {
                        for (int i = 0; i < user.Hobby.Count; i++) {
                                user.Hobby [i] = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), user.Hobby [i].Name);
                                user.Hobby [i].User.Add (user);
                        }
                }

                session.Save (user);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return user.Nickname;
}

public void Modify (UserEN user)
{
        try
        {
                SessionInitializeTransaction ();
                UserEN userEN = (UserEN)session.Load (typeof(UserEN), user.Nickname);

                userEN.Email = user.Email;


                userEN.Password = user.Password;


                userEN.Name = user.Name;


                userEN.Surname = user.Surname;


                userEN.Phone = user.Phone;


                userEN.Avatar = user.Avatar;

                session.Update (userEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
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
                UserEN userEN = (UserEN)session.Load (typeof(UserEN), nickname);
                session.Delete (userEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public UserEN Searchbynick (string nickname)
{
        UserEN userEN = null;

        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Get (typeof(UserEN), nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userEN;
}
}
}
