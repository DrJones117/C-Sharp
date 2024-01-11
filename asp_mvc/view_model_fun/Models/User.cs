#pragma  warning disable CS8618

namespace view_model_fun.Models;

public class User{
    public string FirstName {get;set;}
    public string LastName {get;set;}

    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}