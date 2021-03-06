
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
public partial class EventosCEN :BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> SearchByHobbies (string name)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Eventos_searchByHobbies) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> lista = new System.Collections.Generic.List<EventosEN>();
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> listaux = new System.Collections.Generic.List<EventosEN>();
        try
        {
                SessionInitializeTransaction ();
                HobbyCAD hobbycad = new HobbyCAD (session);
                EventosCAD evecad = new EventosCAD (session);
                listaux = evecad.GetAllEventos ();

                foreach (EventosEN eve in listaux) {
                        foreach (HobbyEN ho in eve.HobbyEvent) {
                                if (ho.Name.IndexOf (name) >= 0) {
                                        lista.Add (eve);
                                        break;
                                }
                        }
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
