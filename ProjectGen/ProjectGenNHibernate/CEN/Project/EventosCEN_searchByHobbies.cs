
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
public partial class EventosCEN
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> SearchByHobbies (string hobby)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Eventos_searchByHobbies) ENABLED START*/

        // Write here your custom code...

    System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> lista = new System.Collections.Generic.List<EventosEN>();
    System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> listaux = new System.Collections.Generic.List<EventosEN>();
    try
    {
        SessionInitializeTransaction();
        HobbyCAD hobbycad = new HobbyCAD(session);
        EventosCAD evecad = new EventosCAD(session);
        listaux = evecad.GetAll();

        foreach (EventosEN eve in listaux)
        {
            foreach (HobbyEN ho in eve.Hobby)
            {
                if (ho.Name.Contains(hobby))
                {
                    lista.Add(eve);
                    break;
                }
            }

        }
        SessionCommit();
    }
    catch (Exception ex)
    {
        SessionRollBack();
    }
    return lista;

        /*PROTECTED REGION END*/
}
}
}
