
using System;

namespace ProjectGenNHibernate.EN.Project
{
public partial class EventsEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string name;

/**
 *
 */

private string description;

/**
 *
 */

private ProjectGenNHibernate.Enumerated.Project.EstadoEnum state;

/**
 *
 */

private TimeSpan dateStart;

/**
 *
 */

private TimeSpan dateEnd;

/**
 *
 */

private string place;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> usuario;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual string Description {
        get { return description; } set { description = value;  }
}


public virtual ProjectGenNHibernate.Enumerated.Project.EstadoEnum State {
        get { return state; } set { state = value;  }
}


public virtual TimeSpan DateStart {
        get { return dateStart; } set { dateStart = value;  }
}


public virtual TimeSpan DateEnd {
        get { return dateEnd; } set { dateEnd = value;  }
}


public virtual string Place {
        get { return place; } set { place = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> Hobby {
        get { return hobby; } set { hobby = value;  }
}





public EventsEN()
{
        usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
        hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
}



public EventsEN(int id, string name, string description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum state, TimeSpan dateStart, TimeSpan dateEnd, string place, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> usuario, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby)
{
        this.init (id, name, description, state, dateStart, dateEnd, place, usuario, hobby);
}


public EventsEN(EventsEN events)
{
        this.init (events.Id, events.Name, events.Description, events.State, events.DateStart, events.DateEnd, events.Place, events.Usuario, events.Hobby);
}

private void init (int id, string name, string description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum state, TimeSpan dateStart, TimeSpan dateEnd, string place, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> usuario, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby)
{
        this.Id = Id;


        this.Name = name;

        this.Description = description;

        this.State = state;

        this.DateStart = dateStart;

        this.DateEnd = dateEnd;

        this.Place = place;

        this.Usuario = usuario;

        this.Hobby = hobby;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EventsEN t = obj as EventsEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
