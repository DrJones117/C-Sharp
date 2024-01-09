class Enemy
{
    private string _Name;
    public string Name { get {return _Name;} set{_Name = value;}}
    private int _Health;
    public int Health { get {return _Health;} set{_Health = value;}}
    public List<Attack> AttackList;

    public Enemy(string name, List<Attack> attackList)
    {
        Name = name;
        Health = 100;
        AttackList = attackList;
    }

    public virtual void RandomAttack()
    {
        Console.WriteLine("Attacking");
        Random rand = new Random();
        int attack = rand.Next(0, AttackList.Count);
        Console.WriteLine($"Enemy used {AttackList[attack].Name}");
    }
}