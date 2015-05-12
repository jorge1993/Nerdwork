
using System;

namespace ProjectGenNHibernate.EN.Project
{
public partial class GroupsEN
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

private ProjectGenNHibernate.EN.Project.PostEN post;

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


public virtual ProjectGenNHibernate.EN.Project.PostEN Post {
        get { return post; } set { post = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> Hobby {
        get { return hobby; } set { hobby = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public GroupsEN()
{
        hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
        usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
}



public GroupsEN(int id, string name, string description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum state, ProjectGenNHibernate.EN.Project.PostEN post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> usuario)
{
        this.init (id, name, description, state, post, hobby, usuario);
}


public GroupsEN(GroupsEN groups)
{
        this.init (groups.Id, groups.Name, groups.Description, groups.State, groups.Post, groups.Hobby, groups.Usuario);
}

private void init (int id, string name, string description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum state, ProjectGenNHibernate.EN.Project.PostEN post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> usuario)
{
        this.Id = Id;


        this.Name = name;

        this.Description = description;

        this.State = state;

        this.Post = post;

        this.Hobby = hobby;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GroupsEN t = obj as GroupsEN;
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
