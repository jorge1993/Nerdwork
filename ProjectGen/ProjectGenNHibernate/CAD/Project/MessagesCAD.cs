
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
public partial class MessagesCAD : BasicCAD, IMessagesCAD
{
public MessagesCAD() : base ()
{
}

public MessagesCAD(ISession sessionAux) : base (sessionAux)
{
}



public MessagesEN ReadOIDDefault (int id)
{
        MessagesEN messagesEN = null;

        try
        {
                SessionInitializeTransaction ();
                messagesEN = (MessagesEN)session.Get (typeof(MessagesEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in MessagesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return messagesEN;
}


public int Create (MessagesEN messages)
{
        try
        {
                SessionInitializeTransaction ();
                if (messages.Userreceive != null) {
                        messages.Userreceive = (ProjectGenNHibernate.EN.Project.UserEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UserEN), messages.Userreceive.Nickname);

                        messages.Userreceive.Messagesreceive.Add (messages);
                }
                if (messages.Usersend != null) {
                        messages.Usersend = (ProjectGenNHibernate.EN.Project.UserEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UserEN), messages.Usersend.Nickname);

                        messages.Usersend.Messagessend.Add (messages);
                }

                session.Save (messages);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in MessagesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return messages.Id;
}

public void Delete (int id)
{
        try
        {
                SessionInitializeTransaction ();
                MessagesEN messagesEN = (MessagesEN)session.Load (typeof(MessagesEN), id);
                session.Delete (messagesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in MessagesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
