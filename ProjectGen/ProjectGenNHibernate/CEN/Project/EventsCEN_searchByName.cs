
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
public partial class EventsCEN
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventsEN> SearchByName (string arg1)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Events_searchByName) ENABLED START*/

        // Write here your custom code...
    System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventsEN> lista = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.EventsEN>();
    System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventsEN> ret = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.EventsEN>();
    ProjectGenNHibernate.CEN.Project.EventsCEN evencen = new EventsCEN();

    try
    {
        SessionInitializeTransaction();
        EventsCAD eve = new EventsCAD(session);
        EventsCAD evecad = new EventsCAD(session);
        lista = eve.GetAll();

        foreach (EventsEN h in lista)
        {
            if(h.Name.Contains(arg1)){
                ret.Add(h);
            }
        }
        SessionCommit();
    }
    catch (Exception ex)
    {
        SessionRollBack();
    }

    return ret;
        //throw new NotImplementedException ("Method SearchByName() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
