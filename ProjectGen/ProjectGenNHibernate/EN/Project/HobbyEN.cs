
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

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UserEN> user;





public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> Post {
        get { return post; } set { post = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UserEN> User {
        get { return user; } set { user = value;  }
}





public HobbyEN()
{
        post = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.PostEN>();
        user = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UserEN>();
}



public HobbyEN(string name, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UserEN> user)
{
        this.init (name, post, user);
}


public HobbyEN(HobbyEN hobby)
{
        this.init (hobby.Name, hobby.Post, hobby.User);
}

private void init (string name, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UserEN> user)
{
        this.Name = name;


        this.Post = post;

        this.User = user;
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
