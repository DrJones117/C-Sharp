// See https://aka.ms/new-console-template for more information

// Goblin section =====

Attack Slice = new("Slice", 20);
Attack Grab = new("Grab", 5);
Attack GutPunch = new("GutPunch", 10);

List<Attack> goblinAttacks = new([])
{
    Slice,
    Grab,
    GutPunch
};

Enemy goblin = new("Gorbag", goblinAttacks);

// Melee section =====

Attack Punch = new("Punch", 20);
Attack Kick = new("Kick", 15);
Attack Tackle = new("Tackle", 25);


List<Attack> meleeAttacks = new([])
{
    Punch,
    Kick,
    Tackle
};

Melee MeleeFighter = new("Monk", meleeAttacks);

// Ranged section =====

Attack ShootArrow = new("Shoot an Arrow", 20);
Attack ThrowKnife = new("Throw a Knife", 15);

List<Attack> rangedAttacks = new([])
{
    ShootArrow,
    ThrowKnife
};

Ranged RangedFighter = new("Archer", rangedAttacks);

// Magic section

Attack FireBall = new("Fire Ball", 25);
Attack LightingBolt = new("Lighting Bolt", 20);
Attack StaffStrike = new("Staff Strike", 10);

List<Attack> magicAttacks = new([])
{
    FireBall,
    LightingBolt,
    StaffStrike
};


Magic MagicCaster = new("Wizard", magicAttacks);

// Action section =====
MeleeFighter.PerformAttack(RangedFighter, Kick);

MeleeFighter.Rage(MagicCaster, meleeAttacks);

RangedFighter.PerformAttack(MeleeFighter, ShootArrow);

RangedFighter.Dash();

RangedFighter.PerformAttack(MeleeFighter, ShootArrow);

MagicCaster.PerformAttack(MeleeFighter, FireBall);

MagicCaster.Heal(RangedFighter);

MagicCaster.Heal(MagicCaster);