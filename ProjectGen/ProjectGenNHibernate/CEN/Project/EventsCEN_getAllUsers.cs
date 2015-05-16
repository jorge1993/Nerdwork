
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
public partial class EventsCEN :BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> GetAllUsers (int arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Events_getAllUsers) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> aux = new System.Collections.Generic.List<UsuarioEN>();
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> lista = new System.Collections.Generic.List<UsuarioEN>();
        try
        {
                SessionInitializeTransaction ();
                EventsCAD eve = new EventsCAD (session);
                UsuarioCAD usercad = new UsuarioCAD (session);
                EventsEN even = eve.ReadOIDDefault (arg0);
                aux = usercad.GetAllUsers ();

                foreach (UsuarioEN u in aux) {
                        if (u.Nickname.Equals (even.Usuario))
                                lista.Add (u);
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
