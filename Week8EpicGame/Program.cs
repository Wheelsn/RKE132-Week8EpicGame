
string folderPath = @"C:\data";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath,heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath,villainFile));
string[] weapons = { "comically large spoon", "la chancla", "shield", "rock", "knuckle sandwich" };


string villain = GetRandomValue(villains);
int VillainHP = GetCharacterHP(villain);
int villainStrikeStrength = VillainHP;

string hero = GetRandomValue(heroes);
int HeroHP = GetCharacterHP(hero);
int heroStrikeStrength = HeroHP;

Console.WriteLine($"{hero} came to save us from {villain}!");
string weapon = GetRandomValue(weapons);
string heroWeapon = GetRandomValue(weapons);
string villainWeapon = GetRandomValue(weapons);


Console.WriteLine($"Oh no {villain} ({VillainHP} HP) is using {villainWeapon} but look {hero}({HeroHP} HP) has {heroWeapon} we are saved!");
while (HeroHP > 0 && VillainHP > 0)
{
    HeroHP = HeroHP - Hit(villain, villainStrikeStrength);
    VillainHP = VillainHP - Hit(hero, heroStrikeStrength );
}

Console.WriteLine($"{hero} has {HeroHP} HP left");
Console.WriteLine($"{villain} has {VillainHP} HP left");

if (HeroHP > 0)
{
    Console.WriteLine($"Yes {hero} saved us!");
}
else if (VillainHP > 0)
{
    Console.WriteLine($"Nooo we are doomed {villain} won!");
}
else
{
    Console.WriteLine($"Noo {hero} cant win but {villain} is also too weakened to win!");
}





static string GetRandomValue(string[] someArray)
{
    Random random = new Random();
    int randomIndex = random.Next(0, someArray.Length);
    string randomString = someArray[randomIndex];
    return randomString;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 6 )
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
        
}

static int Hit(string CharacterName, int CharacterHP)
{
    Random random = new Random();
    int strike = random.Next(0, CharacterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{CharacterName} missed!");
    }
    else if (strike == CharacterHP - 1)
    {
        Console.WriteLine($"Critical hit! {CharacterName} hit for {strike} damage!");
    }
    else
    {
        Console.WriteLine($"{CharacterName} hit for {strike} damage!");
    }
    return strike;
}