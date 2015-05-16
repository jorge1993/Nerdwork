
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
public partial class GroupsCEN
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> SearchByHobbies (string arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Groups_searchByHobbies) ENABLED START*/

        // Write here your custom code...

    System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> lista = new System.Collections.Generic.List<GroupsEN>();
    System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> listaux = new System.Collections.Generic.List<GroupsEN>();
    try
    {
        SessionInitializeTransaction();
        HobbyCAD hobbycad = new HobbyCAD(session);
        GroupsCAD evecad = new GroupsCAD(session);
        listaux = evecad.GetAllGroups();

        foreach (GroupsEN eve in listaux)
        {
            foreach (HobbyEN ho in eve.Hobby)
            {
                if (ho.Name.Contains(arg0))
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
