
using System;

namespace ProjectGenNHibernate.EN.Project
{
public partial class HobbyEN
{
/**
 *
 */

private string name;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> user;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> groups;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> events;





public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> Post {
        get { return post; } set { post = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> User {
        get { return user; } set { user = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> Groups {
        get { return groups; } set { groups = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> Events {
        get { return events; } set { events = value;  }
}





public HobbyEN()
{
        post = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.PostEN>();
        user = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
        groups = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.GroupsEN>();
        events = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.EventosEN>();
}



public HobbyEN(string name, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> user, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> groups, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> events)
{
        this.init (name, post, user, groups, events);
}


public HobbyEN(HobbyEN hobby)
{
        this.init (hobby.Name, hobby.Post, hobby.User, hobby.Groups, hobby.Events);
}

private void init (string name, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> user, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> groups, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> events)
{
        this.Name = name;


        this.Post = post;

        this.User = user;

        this.Groups = groups;

        this.Events = events;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        HobbyEN t = obj as HobbyEN;
        if (t == null)
                return false;
        if (Name.Equals (t.Name))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Name.GetHashCode ();
        return hash;
}
}
}
