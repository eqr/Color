using System.Collections.Generic;

namespace DDDConcepts {
public partial class Account
{
    public string Email { get; }
    public string Password { get; }

    private readonly List<Role> roles = new List<Role>();
    public IEnumerable<Role> Roles
    {
        get { return roles; }
    }
    public Account(string email, string password)
    {
        Email = email;
        Password = password;
        AddRole(Role.Member);
    }
    public void AddRole(Role role)
    {
        if (roles.Contains(role))
            return;

        roles.Add(role);
    }
} }