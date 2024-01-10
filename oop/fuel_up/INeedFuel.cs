
interface INeedFuel
{
    string FuelType {get;set;}

    string Name {get;set;}
    int FuelTotal {get;set;}
    void GiveFuel(int Amount);
}

