// See https://aka.ms/new-console-template for more information

Attack Slice = new("Slice", 20);
Attack Grab = new("Grab", 5);
Attack GutPunch = new("GutPunch", 10);

List<Attack> attacks = new([])
{
    Slice,
    Grab,
    GutPunch
};

Enemy goblin = new("Gorbag", attacks);

goblin.RandomAttack();