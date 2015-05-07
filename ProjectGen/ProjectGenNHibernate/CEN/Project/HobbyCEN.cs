

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
public partial class HobbyCEN
{
private IHobbyCAD _IHobbyCAD;

public HobbyCEN()
{
        this._IHobbyCAD = new HobbyCAD ();
}

public HobbyCEN(IHobbyCAD _IHobbyCAD)
{
        this._IHobbyCAD = _IHobbyCAD;
}

public IHobbyCAD get_IHobbyCAD ()
{
        return this._IHobbyCAD;
}

public string Create (string p_name)
{
        HobbyEN hobbyEN = null;
        string oid;

        //Initialized HobbyEN
        hobbyEN = new HobbyEN ();
        hobbyEN.Name = p_name;

        //Call to HobbyCAD

        oid = _IHobbyCAD.Create (hobbyEN);
        return oid;
}

public HobbyEN Search (string name)
{
        HobbyEN hobbyEN = null;

        hobbyEN = _IHobbyCAD.Search (name);
        return hobbyEN;
}

public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> GetAllHobby ()
{
        return _IHobbyCAD.GetAllHobby ();
}
}
}
