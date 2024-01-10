
public class Melee : Enemy
{
    public Melee(string name, List<Attack> atkList) : base(name, atkList)
    {
        Health = 120;
    }

    public void Rage(Enemy Target, List<Attack> atkList)
    {
        Random rand = new Random();

        int attack = rand.Next(0, atkList.Count);
        int rageDamage = atkList[attack].Damage + 10;
        Target.Health -= rageDamage;
        Console.WriteLine("Rage Attack!!!");
        Console.WriteLine("+10 damage.");
        Console.WriteLine($"{Name} attacks {Target.Name} with {atkList[attack].Name}, dealing {rageDamage} damage and reducing {Target.Name}'s health to {Target.Health}!!");
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        base.PerformAttack(Target, ChosenAttack);
    }
}