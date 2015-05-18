
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
public partial class GroupsCEN : BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> SearchByName (string arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Groups_searchByName) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> lista = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.GroupsEN>();
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> ret = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.GroupsEN>();
        ProjectGenNHibernate.CEN.Project.GroupsCEN evencen = new GroupsCEN ();

        try
        {
                SessionInitializeTransaction ();
                GroupsCAD groupcad = new GroupsCAD (session);
                //EventosCEN eve = new EventosCEN(session);
                lista = groupcad.GetAllGroups ();

                foreach (GroupsEN h in lista) {
                        if (h.Name.Contains (arg0)) {
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
