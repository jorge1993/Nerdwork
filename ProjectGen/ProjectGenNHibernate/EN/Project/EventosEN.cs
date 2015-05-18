
using System;

namespace ProjectGenNHibernate.EN.Project
{
public partial class EventosEN
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

private string dateStart;

/**
 *
 */

private string dateEnd;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> usuario;





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


public virtual string DateStart {
        get { return dateStart; } set { dateStart = value;  }
}


public virtual string DateEnd {
        get { return dateEnd; } set { dateEnd = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> Hobby {
        get { return hobby; } set { hobby = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public EventosEN()
{
        hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
        usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
}



public EventosEN(int id, string name, string description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum state, string dateStart, string dateEnd, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> usuario)
{
        this.init (id, name, description, state, dateStart, dateEnd, hobby, usuario);
}


public EventosEN(EventosEN eventos)
{
        this.init (eventos.Id, eventos.Name, eventos.Description, eventos.State, eventos.DateStart, eventos.DateEnd, eventos.Hobby, eventos.Usuario);
}

private void init (int id, string name, string description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum state, string dateStart, string dateEnd, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> usuario)
{
        this.Id = Id;


        this.Name = name;

        this.Description = description;

        this.State = state;

        this.DateStart = dateStart;

        this.DateEnd = dateEnd;

        this.Hobby = hobby;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EventosEN t = obj as EventosEN;
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
