
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
public partial class UsuarioCEN
{
public bool HasHobbies (string p_oid)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Usuario_hasHobbies) ENABLED START*/

        // Write here your custom code...

        try
        {
                SessionInitializeTransaction ();
                HobbyCAD mes = new HobbyCAD (session);
                UsuarioCAD usercad = new UsuarioCAD (session);
                UsuarioEN useren = usercad.ReadOIDDefault (p_oid);
                int i = 0;
                foreach (HobbyEN hobby in useren.Hobby) {
                        i++;
                }
                SessionCommit ();
                if (i != 0) return true;
                else return false;
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                return false;
        }

        /*PROTECTED REGION END*/
}
}
}
