
public class Magic : Enemy
{
    public Magic(string name, List<Attack> atkList) : base(name, atkList)
    {
        Health = 80;
    }

    public void Heal(Enemy Target)
    {
        Target.Health += 40;
        Console.WriteLine($"{Name} heals {Target.Name} for 40 health Leaving him with {Target.Health}");
    } 

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        base.PerformAttack(Target, ChosenAttack);
    }
}