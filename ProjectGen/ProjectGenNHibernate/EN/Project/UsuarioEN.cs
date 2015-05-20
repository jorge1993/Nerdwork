
using System;

namespace ProjectGenNHibernate.EN.Project
{
public partial class UsuarioEN
{
/**
 *
 */

private string nickname;

/**
 *
 */

private string email;

/**
 *
 */

private string password;

/**
 *
 */

private string name;

/**
 *
 */

private string surname;

/**
 *
 */

private string phone;

/**
 *
 */

private string avatar;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagesreceive;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagessend;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> groups;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> eventos;





public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}


public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual string Password {
        get { return password; } set { password = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual string Surname {
        get { return surname; } set { surname = value;  }
}


public virtual string Phone {
        get { return phone; } set { phone = value;  }
}


public virtual string Avatar {
        get { return avatar; } set { avatar = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> Messagesreceive {
        get { return messagesreceive; } set { messagesreceive = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> Post {
        get { return post; } set { post = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> Messagessend {
        get { return messagessend; } set { messagessend = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> Hobby {
        get { return hobby; } set { hobby = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> Groups {
        get { return groups; } set { groups = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> Eventos {
        get { return eventos; } set { eventos = value;  }
}





public UsuarioEN()
{
        messagesreceive = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.MessagesEN>();
        post = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.PostEN>();
        messagessend = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.MessagesEN>();
        hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
        groups = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.GroupsEN>();
        eventos = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.EventosEN>();
}



public UsuarioEN(string nickname, string email, string password, string name, string surname, string phone, string avatar, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagesreceive, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagessend, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> groups, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> eventos)
{
        this.init (nickname, email, password, name, surname, phone, avatar, messagesreceive, post, messagessend, hobby, groups, eventos);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Nickname, usuario.Email, usuario.Password, usuario.Name, usuario.Surname, usuario.Phone, usuario.Avatar, usuario.Messagesreceive, usuario.Post, usuario.Messagessend, usuario.Hobby, usuario.Groups, usuario.Eventos);
}

private void init (string nickname, string email, string password, string name, string surname, string phone, string avatar, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagesreceive, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagessend, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> groups, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> eventos)
{
        this.Nickname = nickname;


        this.Email = email;

        this.Password = password;

        this.Name = name;

        this.Surname = surname;

        this.Phone = phone;

        this.Avatar = avatar;

        this.Messagesreceive = messagesreceive;

        this.Post = post;

        this.Messagessend = messagessend;

        this.Hobby = hobby;

        this.Groups = groups;

        this.Eventos = eventos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Nickname.Equals (t.Nickname))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nickname.GetHashCode ();
        return hash;
}
}
}
