
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
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> GetSend (string emisor)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Messages_getSend) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> lista = new System.Collections.Generic.List<MessagesEN>();
        try
        {
                SessionInitializeTransaction ();
                MessagesCAD mes = new MessagesCAD (session);
                UsuarioCAD usercad = new UsuarioCAD (session);
                UsuarioEN useren = usercad.ReadOIDDefault (emisor);

                foreach (MessagesEN message in useren.Messagessend) {
                        if (message.Usersend.Nickname.Equals (emisor))
                                lista.Add (message);
                }
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
        }

        return lista;

        //throw new NotImplementedException ("Method GetSend() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
