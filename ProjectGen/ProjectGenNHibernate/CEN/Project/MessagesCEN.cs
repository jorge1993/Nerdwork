

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
public partial class MessagesCEN
{
private IMessagesCAD _IMessagesCAD;

public MessagesCEN()
{
        this._IMessagesCAD = new MessagesCAD ();
}

public MessagesCEN(IMessagesCAD _IMessagesCAD)
{
        this._IMessagesCAD = _IMessagesCAD;
}

public IMessagesCAD get_IMessagesCAD ()
{
        return this._IMessagesCAD;
}

public int Create (int p_id, string p_subject, string p_description, string p_userreceive, string p_usersend)
{
        MessagesEN messagesEN = null;
        int oid;

        //Initialized MessagesEN
        messagesEN = new MessagesEN ();
        messagesEN.Id = p_id;

        messagesEN.Subject = p_subject;

        messagesEN.Description = p_description;


        if (p_userreceive != null) {
                messagesEN.Userreceive = new ProjectGenNHibernate.EN.Project.UsuarioEN ();
                messagesEN.Userreceive.Nickname = p_userreceive;
        }


        if (p_usersend != null) {
                messagesEN.Usersend = new ProjectGenNHibernate.EN.Project.UsuarioEN ();
                messagesEN.Usersend.Nickname = p_usersend;
        }

        //Call to MessagesCAD

        oid = _IMessagesCAD.Create (messagesEN);
        return oid;
}

public void Delete (int id)
{
        _IMessagesCAD.Delete (id);
}
}
}
