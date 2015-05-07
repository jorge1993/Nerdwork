
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
public partial class UsuarioCEN : BasicCAD
{
public bool HasHobbies (string p_oid)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Usuario_hasHobbies) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> lista = new System.Collections.Generic.List<HobbyEN>();
        try
        {
                SessionInitializeTransaction ();
                HobbyCAD hobbycad = new HobbyCAD (session);
                UsuarioCAD usercad = new UsuarioCAD (session);
                UsuarioEN useren = usercad.ReadOIDDefault (p_oid);

                foreach (HobbyEN hobianos in useren.Hobby) {
                        if (hobianos.User == useren)
                                lista.Add (hobianos);
                }
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
        }
        //return lista;
        return false;

        /*PROTECTED REGION END*/
}
}
}
