
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
public partial class MessagesCEN : BasicCAD
{
public System.Collections.Generic.IList<string> GetUserReceive (string emisor)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Messages_getUserReceive) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<String> lista = new System.Collections.Generic.List<String>();
        try
        {
                SessionInitializeTransaction ();
                MessagesCAD mes = new MessagesCAD (session);
                UsuarioCAD usercad = new UsuarioCAD (session);
                UsuarioEN useren = usercad.ReadOIDDefault (emisor);

                foreach (MessagesEN message in useren.Messagesreceive) {
                        if (message.Userreceive.Nickname.Equals (emisor))
                                lista.Add (message.Usersend.Nickname.ToString ());
                }
                SessionCommit ();
                SessionClose ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
        }
        return lista;
        //throw new NotImplementedException ("Method GetUserReceive() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
