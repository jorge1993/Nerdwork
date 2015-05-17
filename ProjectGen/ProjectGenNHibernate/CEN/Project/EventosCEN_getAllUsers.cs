
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
public partial class EventosCEN : BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> GetAllUsers (int arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Eventos_getAllUsers) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> lista = new System.Collections.Generic.List<UsuarioEN>();
        try
        {
                SessionInitializeTransaction ();
                UsuarioCAD usuariocad = new UsuarioCAD (session);
                EventosCAD evecad = new EventosCAD (session);
                EventosEN eveen = evecad.ReadOIDDefault (arg0);

                foreach (UsuarioEN us in eveen.Usuario) {
                        lista.Add (us);
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
