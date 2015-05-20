
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
public partial class EventsCEN : BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> GetAllHobbies (int arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Events_getAllHobbies) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> aux = new System.Collections.Generic.List<HobbyEN>();
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> lista = new System.Collections.Generic.List<HobbyEN>();
        try
        {
                SessionInitializeTransaction ();
                EventsCAD eve = new EventsCAD (session);
                HobbyCAD hobbycad = new HobbyCAD (session);
                EventsEN even = eve.ReadOIDDefault (arg0);
                aux = hobbycad.GetAllHobby ();

                foreach (HobbyEN h in aux) {
                        if (h.Name.Equals (even.Hobby))
                                lista.Add (h);
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
