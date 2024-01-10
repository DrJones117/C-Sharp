public class Attack
{
    private string _Name;
    public string Name { get {return _Name;} set{_Name = value;}}
    public int Damage;

    public Attack(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
}