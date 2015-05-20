
using System;

namespace ProjectGenNHibernate.EN.Project
{
public partial class PostEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string description;

/**
 *
 */

private ProjectGenNHibernate.EN.Project.UsuarioEN user;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby;

/**
 *
 */

private ProjectGenNHibernate.EN.Project.GroupsEN groups;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Description {
        get { return description; } set { description = value;  }
}


public virtual ProjectGenNHibernate.EN.Project.UsuarioEN User {
        get { return user; } set { user = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> Hobby {
        get { return hobby; } set { hobby = value;  }
}


public virtual ProjectGenNHibernate.EN.Project.GroupsEN Groups {
        get { return groups; } set { groups = value;  }
}





public PostEN()
{
        hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
}



public PostEN(int id, string description, ProjectGenNHibernate.EN.Project.UsuarioEN user, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby, ProjectGenNHibernate.EN.Project.GroupsEN groups)
{
        this.init (id, description, user, hobby, groups);
}


public PostEN(PostEN post)
{
        this.init (post.Id, post.Description, post.User, post.Hobby, post.Groups);
}

private void init (int id, string description, ProjectGenNHibernate.EN.Project.UsuarioEN user, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby, ProjectGenNHibernate.EN.Project.GroupsEN groups)
{
        this.Id = id;


        this.Description = description;

        this.User = user;

        this.Hobby = hobby;

        this.Groups = groups;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PostEN t = obj as PostEN;
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
