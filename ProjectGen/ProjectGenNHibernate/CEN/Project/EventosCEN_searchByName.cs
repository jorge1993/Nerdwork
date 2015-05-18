
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
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> SearchByName (string arg1)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Eventos_searchByName) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> lista = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.EventosEN>();
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> ret = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.EventosEN>();
        ProjectGenNHibernate.CEN.Project.EventosCEN evencen = new EventosCEN ();

        try
        {
                SessionInitializeTransaction ();
                EventosCAD evecad = new EventosCAD (session);
                //EventosCEN eve = new EventosCEN(session);
                lista = evecad.GetAllEventos ();

                foreach (EventosEN h in lista) {
                        if (h.Name.Contains (arg1)) {
                                ret.Add (h);
                        }
                }
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
        }

        return ret;

        /*PROTECTED REGION END*/
}
}
}
