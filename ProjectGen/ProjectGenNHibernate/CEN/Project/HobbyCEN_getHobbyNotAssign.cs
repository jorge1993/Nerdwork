
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
public partial class HobbyCEN : BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> GetHobbyNotAssign (string p_oid)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Hobby_getHobbyNotAssign) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> lista = new System.Collections.Generic.List<HobbyEN>();
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> listaTotal = new System.Collections.Generic.List<HobbyEN>();
        try
        {
                SessionInitializeTransaction ();
                HobbyCAD hobbycad = new HobbyCAD (session);
                UsuarioCAD usercad = new UsuarioCAD (session);
                UsuarioEN useren = usercad.ReadOIDDefault (p_oid);
                HobbyCEN todosloahobbies = new HobbyCEN ();
                lista = todosloahobbies.GetAllHobby ();

                foreach (HobbyEN hobianos in lista) {
                        if (!useren.Hobby.Contains (hobianos))
                                listaTotal.Add (hobianos);
                }
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
        }
        return listaTotal;



        /*PROTECTED REGION END*/
}
}
}
