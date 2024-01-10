
public class Ranged : Enemy
{
    public int Distance;
    public Ranged(string name, List<Attack> atkList) : base(name, atkList)
    {
        Distance = 5;
    }

    public void Dash()
    {
        Distance += 10;
        Console.WriteLine($"Distance increased to {Distance}");
    }

    public override void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        if (Distance < 10)
        {
            Console.WriteLine($"{Name} is too close to shoot!");
        }
        else 
        {
            base.PerformAttack(Target, ChosenAttack);
        }
    }
}
