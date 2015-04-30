
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
                        messages.Userreceive = (ProjectGenNHibernate.EN.Project.UsuarioEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UsuarioEN), messages.Userreceive.Nickname);

                        messages.Userreceive.Messagesreceive.Add (messages);
                }
                if (messages.Usersend != null) {
                        messages.Usersend = (ProjectGenNHibernate.EN.Project.UsuarioEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UsuarioEN), messages.Usersend.Nickname);

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

public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> GetSend (string usuario)
{
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MessagesEN self where FROM MessagesEN Where usersend = :usuario ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MessagesENgetSendHQL");
                query.SetParameter ("usuario", usuario);

                result = query.List<ProjectGenNHibernate.EN.Project.MessagesEN>();
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

        return result;
}
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> GetMax ()
{
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MessagesEN self where select Max(message.id) FROM MessagesEN as message";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MessagesENgetMaxHQL");

                result = query.List<ProjectGenNHibernate.EN.Project.MessagesEN>();
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

        return result;
}
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> GetReceive (string arg0)
{
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MessagesEN self where FROM MessagesEN Where userreceive = :usuario ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MessagesENgetReceiveHQL");
                query.SetParameter ("arg0", arg0);

                result = query.List<ProjectGenNHibernate.EN.Project.MessagesEN>();
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

        return result;
}
}
}
