using static System.Console;
using System.Runtime.CompilerServices;
using enemies1;

//Selection keys
const ConsoleKey Z = ConsoleKey.Z;
const ConsoleKey X = ConsoleKey.X;
const ConsoleKey C = ConsoleKey.C;
const ConsoleKey V = ConsoleKey.V;
const ConsoleKey B = ConsoleKey.B;

//Gets player choices
ConsoleKey ChoiceSelection()
{
    ConsoleKey choice = ReadKey(true).Key;
    WriteLine();
    return choice;
}

//Character Classes
Character Swashbuckler = new("Swashbuckler", 15, 5, 10, 5);
Character Scallywag = new("Scallywag", 12, 3, 15, 3);
Character Captain = new("Captain", 15, 7, 8, 10);

Character SelectedCharacter = Swashbuckler;

bool ClassSelectionState = true;

Enemies CommonThug = new("Common Thug", 10, 5, 9, 15, 15);
Enemies RatKing = new("Rat King", 125, 8, 10, 75, 150);
Enemies RichMansSkeleton = new("Elon Musk", 30, 3, 5, 10, 100);

//Locations
Location Ship = new() { LocationDescription = "Your ship. It's not big or flashy, but its yours.", LocationHostility = "It's YOUR ship. Of course there's no enemies!" };
Location Port = new() { LocationDescription = "The port is bustling with all kinds of people. From innocent children to slimy merchants. You even see a fish vendor waving you down.", LocationHostility = "Besides a few street thugs its realtively peacful, but the bounties on those low level thugs are still worth gold!" };
Location CityMarket = new() { LocationDescription = "The market is busy, there's many things to buy", LocationHostility = "Aside from the hostile business practice theres not much going on here." };
Location Cave = new() { LocationDescription = "A dark, damp cave. You can hear the scurrying of rats echoing through the caverns.", LocationHostility = "You sense danger lurking in the shadows." };
Location Graveyard = new() { LocationDescription = "An old graveyard filled with crumbling tombstones and overgrown weeds. The air is thick with an eerie silence.", LocationHostility = "There might be some ghosts looking at you. Who knows." };

WriteLine();
WriteLine("Select your class:");
WriteLine("Z: {0}", Swashbuckler);
WriteLine("X: {0}", Scallywag);
WriteLine("C: {0}", Captain);

while (ClassSelectionState == true)
{
    try
    {
        switch (ChoiceSelection())
        {
            case Z:
                SelectedCharacter = Swashbuckler;
                WriteLine("You have selected {0}", SelectedCharacter);
                ClassSelectionState = false;
                break;

            case X:
                SelectedCharacter = Scallywag;
                WriteLine("You have selected {0}", SelectedCharacter);
                ClassSelectionState = false;
                break;

            case C:
                SelectedCharacter = Captain;
                WriteLine("You have selected {0}", SelectedCharacter);
                ClassSelectionState = false;
                break;
        }
    }
    catch (Exception)
    {
        WriteLine("Please Select a Class");
    }
}

WriteLine();
WriteLine("You awaken on your ship to a brand new day with new oppurtunities!");

bool GameState = true;

void CheckDeath()
{
    if (SelectedCharacter.PlayerHealth <= 0)
    {
        WriteLine("You Have Died.");
        WriteLine();
        WriteLine("GAME OVER");
        GameState = false;
    }
    else
    {
        GameState = true;
    }
}

while (GameState == true)
{
    bool InLocationSelection = false;
    bool OnShip = false;
    bool AtPort = false;
    bool AtCityMarket = false;
    bool InCave = false;
    bool AtGraveyard = false;

    OnShipLoop();

    void OnShipLoop()
    {
        OnShip = true;
        while (OnShip == true)
        {
            WriteLine();
            WriteLine("What will you do? Z = Check Location, X = Check Character Info, C = Check Location Hostility, V = Explore.");
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("{0}", Ship.LocationDescription);
                    break;
                case X:
                    WriteLine("{0}", SelectedCharacter);
                    break;
                case C:
                    WriteLine("{0}", Ship.LocationHostility);
                    break;
                case V:
                    OnShip = false;
                    InLocationSelection = true;
                    LocationSelectionLoop();
                    break;
            }
        }
    }

    void AtPortLoop()
    {
        WriteLine();
        WriteLine("What will you do? Z = Check Location, X = Check Character Info, C = Check Location Hostility, V = Explore.");
        while (AtPort == true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("{0}", Port.LocationDescription);
                    AtPort = false;
                    PortDescriptionLoop();
                    break;
                case X:
                    WriteLine("{0}", SelectedCharacter);
                    AtPortLoop();
                    break;
                case C:
                    WriteLine("{0}", Port.LocationHostility);
                    AtPort = false;
                    PortEnemyEncounterLoop();
                    break;
                case V:
                    AtPort = false;
                    InLocationSelection = true;
                    LocationSelectionLoop();
                    break;

            }
        }
    }
    void PortDescriptionLoop()
    {
        bool TalkingToVendor = true;
        WriteLine("Do you go over to the vendor? Z = Yes, X = No.");
        while (TalkingToVendor = true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("Hello fine traveler. Care to browse my wares?");
                    WriteLine();
                    WriteLine("Items Available for Purchase: Z: Tuna(Heal 5 HP,cost = 3 GLD), X: Stop Browsing");
                    TalkingToVendor = false;
                    VendorBrowseLoop();
                    break;
                case X:
                    TalkingToVendor = false;
                    AtPort = true;
                    AtPortLoop();
                    break;
            }
        }
    }

    void AtCityMarketLoop()
    {
        WriteLine("");
        WriteLine("What will you do? Z = Check Location, X = Check Character Info, C = Check Location Hostility, V = Explore.");
        while (AtCityMarket == true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("{0}", CityMarket.LocationDescription);
                    AtCityMarket = false;
                    CityMarketDescriptionLoop();
                    break;
                case X:
                    WriteLine("{0}", SelectedCharacter);
                    AtCityMarketLoop();
                    break;
                case C:
                    WriteLine("{0}", CityMarket.LocationHostility);
                    AtCityMarketLoop();
                    break;
                case V:
                    AtCityMarket = false;
                    InLocationSelection = true;
                    LocationSelectionLoop();
                    break;

            }
        }
    }
    void InCaveLoop()
    {
        WriteLine();
        WriteLine("What will you do? Z = Check Location, X = Check Character Info, C = Check Location Hostility, V = Explore.");
        while (InCave == true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("{0}", Cave.LocationDescription);
                    InCave = false;
                    CaveDescriptionLoop();
                    break;
                case X:
                    WriteLine("{0}", SelectedCharacter);
                    InCaveLoop();
                    break;
                case C:
                    WriteLine("{0}", Cave.LocationHostility);
                    InCave = false;
                    InCaveEnemyEncounterLoop();
                    break;
                case V:
                    InCave = false;
                    InLocationSelection = true;
                    LocationSelectionLoop();
                    break;
            }
        }
    }
    void CaveDescriptionLoop()
    {
        bool SearchForTreasure = true;
        WriteLine();
        WriteLine("You see a shambling mound in the corner, best too ignore it.");
        WriteLine("Search For Treasure? Z = Yes, X = No.");
        while (SearchForTreasure = true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("You search for treasure");
                    WriteLine();
                    WriteLine("You found a small pouch of gold! +5 Gold");
                    SelectedCharacter.PlayerGold += 5;
                    SearchForTreasure = false;
                    InCave = true;
                    InCaveLoop();
                    break;
                case X:
                    SearchForTreasure = false;
                    InCave = true;
                    InCaveLoop();
                    break;
            }
        }
    }
    void AtGraveyardLoop()
    {
        WriteLine();
        WriteLine("What will you do? Z = Check Location, X = Check Character Info, C = Check Location Hostility, V = Explore.");
        while (AtGraveyard == true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("{0}", Graveyard.LocationDescription);
                    AtGraveyard = false;
                    AtGraveyardDescriptionLoop();
                    break;
                case X:
                    WriteLine("{0}", SelectedCharacter);
                    AtGraveyardLoop();
                    break;
                case C:
                    WriteLine("{0}", Graveyard.LocationHostility);
                    AtGraveyardLoop();
                    break;
                case V:
                    AtGraveyard = false;
                    InLocationSelection = true;
                    LocationSelectionLoop();
                    break;
            }
        }
    }
    void AtGraveyardDescriptionLoop()
    {
        bool DigUpAGrave = true;
        WriteLine();
        WriteLine("While walking around you notice the grave of a very rich man decorated in gold lining.");
        WriteLine("Dig up the grave? Z = Yes, X = No.");
        while (DigUpAGrave = true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    if (RichMansSkeleton.hitpoints > 0)
                    {
                        WriteLine("You dig up the grave of merchant Elon Musk.");
                        WriteLine();
                        WriteLine("It seems he didn't take too kindly to that!");
                        DigUpAGrave = false;
                        GraveyardFightLoop();
                    }
                    else
                    {
                        WriteLine("You've done enough grave robbing for one day don't ya think?");
                        DigUpAGrave = false;
                        AtGraveyard = true;
                        AtGraveyardLoop();
                    }
                    break;
                case X:
                    DigUpAGrave = false;
                    AtGraveyard = true;
                    AtGraveyardLoop();
                    break;
            }
        }
    }

    void CityMarketDescriptionLoop()
    {
        bool TalkingToBlacksmith = true;
        WriteLine("There's not many stores that catch your eye, except a blacksmith.");
        WriteLine("Do you want to visit the blacksmith? Z = Yes, X = No");
        while (TalkingToBlacksmith = true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("Would you like to upgrade your weapons? Z = Yes, X = No");
                    TalkingToBlacksmith = false;
                    BlacksmithLoop();
                    break;
                case X:
                    TalkingToBlacksmith = false;
                    AtCityMarket = true;
                    AtCityMarketLoop();
                    break;

            }
        }
    }
    void BlacksmithLoop()
    {
        bool BrowsingBlacksmith = true;
        while (BrowsingBlacksmith == true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("Weapons available: Z = Cutlass(+20 STR -25 GLD), X = Dagger(+10 STR -15GLD), C = Flintlock Pistols(+40 STR -45 GLD), V = Exit Blacksmith");
                    BrowsingBlacksmith = false;
                    WeaponsLoop();
                    break;
                case X:
                    BrowsingBlacksmith = false;
                    AtCityMarket = true;
                    AtCityMarketLoop();
                    break;
            }
        }
    }

    void WeaponsLoop()
    {
        bool ChooseWeapon = true;
        while (ChooseWeapon == true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    if (SelectedCharacter.PlayerGold >= 25)
                    {
                        WriteLine("You chose the cutlass, a short sword good for close combat! Str: +20");
                        SelectedCharacter.PlayerStrength += (int)Strength.Cutlass;
                        SelectedCharacter.PlayerGold -= 25;
                        WriteLine("Strength is now: {0}", SelectedCharacter.PlayerStrength);
                        ChooseWeapon = false;
                        AtCityMarket = true;
                        AtCityMarketLoop();
                    }
                    else
                    {
                        WriteLine("No gold no weapons! Now get out of my shop!");
                        ChooseWeapon = false;
                        AtCityMarket = true;
                        AtCityMarketLoop();
                    }
                    break;
                case X:
                    if (SelectedCharacter.PlayerGold >= 15)
                    {
                        WriteLine("You chose the Dagger, a short blade good for close combat! Str: +10 ");
                        SelectedCharacter.PlayerStrength += (int)Strength.Dagger;
                        SelectedCharacter.PlayerGold -= 15;
                        WriteLine("Strength is now: {0}", SelectedCharacter.PlayerStrength);
                        ChooseWeapon = false;
                        AtCityMarket = true;
                        AtCityMarketLoop();
                    }
                    else
                    {
                        WriteLine("No gold no weapons! Now get out of my shop!");
                        ChooseWeapon = false;
                        AtCityMarket = true;
                        AtCityMarketLoop();
                    }
                    break;
                case C:
                    if (SelectedCharacter.PlayerGold >= 45)
                    {
                        WriteLine("You chose the Flintlock Pistols, single hand firearms often used in pairs and good for close combat! Str: +40 ");
                        SelectedCharacter.PlayerStrength += (int)Strength.FlintlockPistols;
                        SelectedCharacter.PlayerGold -= 45;
                        WriteLine("Strength is now: {0}", SelectedCharacter.PlayerStrength);
                        ChooseWeapon = false;
                        AtCityMarket = true;
                        AtCityMarketLoop();
                    }
                    else
                    {
                        WriteLine("No gold no weapons! Now get out of my shop!");
                        ChooseWeapon = false;
                        AtCityMarket = true;
                        AtCityMarketLoop();
                    }
                    break;
                case V:
                    ChooseWeapon = false;
                    AtCityMarket = true;
                    AtCityMarketLoop();
                    break;
            }
        }
    }




    void VendorBrowseLoop()
    {
        bool BrowsingVendor = true;
        while (BrowsingVendor == true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    if (SelectedCharacter.PlayerGold >= 3)
                    {
                        SelectedCharacter.PlayerGold -= 3;
                        SelectedCharacter.PlayerHealth += 5;
                        WriteLine("Thanks kind traveler! Come again anytime!");
                        BrowsingVendor = false;
                        AtPort = true;
                        AtPortLoop();
                    }
                    else
                    {
                        WriteLine("Don't try to buy something you don't have the gold to pay for!");
                        BrowsingVendor = false;
                        AtPort = true;
                        AtPortLoop();
                    }
                    break;
                case X:
                    BrowsingVendor = false;
                    AtPort = true;
                    AtPortLoop();
                    break;


            }
        }
    }

    void PortEnemyEncounterLoop()
    {
        bool ViewingEnemy = true;

        WriteLine();
        WriteLine("Fight? Z = Yes, X = No");
        while (ViewingEnemy == true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    if (CommonThug.hitpoints > 0)
                    {
                        ViewingEnemy = false;
                        PortFightLoop();
                    }
                    else
                    {
                        WriteLine("You've alread defeated the thug in this location.");
                        ViewingEnemy = false;
                        AtPort = true;
                        AtPortLoop();
                    }
                    break;
                case X:
                    WriteLine("Playing it safe is always an option.");
                    ViewingEnemy = false;
                    AtPort = true;
                    AtPortLoop();
                    break;
            }
        }
    }

    void PortFightLoop()
    {
        bool PortFight = true;
        while (PortFight && SelectedCharacter.PlayerHealth > 0 && CommonThug.hitpoints > 0)
        {
            if (SelectedCharacter.PlayerSpeed < CommonThug.speed)
            {
                WriteLine("What will you do? Z = Check Enemy, X = Attack, C = Check Health.");
                switch (ChoiceSelection())
                {
                    case Z:
                        WriteLine("{0} HP, {1} STR, {2} SPD", CommonThug.hitpoints, CommonThug.strength, CommonThug.speed);
                        break;
                    case X:
                        WriteLine("Too Slow! The Thug Struck First!");
                        SelectedCharacter.PlayerHealth -= CommonThug.strength;
                        CheckDeath();
                        if (SelectedCharacter.PlayerHealth > 0)
                        {
                            CommonThug.hitpoints -= SelectedCharacter.PlayerStrength;
                            WriteLine("You hit the thug for {0} damage!", SelectedCharacter.PlayerStrength);
                        }
                        break;
                    case C:
                        WriteLine("Your Health is {0}.", SelectedCharacter.PlayerHealth);
                        break;
                }
            }
            else
            {
                while (SelectedCharacter.PlayerHealth > 0 && CommonThug.hitpoints > 0)
                {
                    WriteLine("What will you do? Z = Check Enemy, X = Attack, C = Check Health.");
                    switch (ChoiceSelection())
                    {
                        case Z:
                            WriteLine("{0} HP, {1} STR, {2} SPD", CommonThug.hitpoints, CommonThug.strength, CommonThug.speed);
                            break;
                        case X:
                            CommonThug.hitpoints -= SelectedCharacter.PlayerStrength;
                            WriteLine("You hit the thug for {0} damage!", SelectedCharacter.PlayerStrength);
                            if (CommonThug.hitpoints > 0)
                            {
                                SelectedCharacter.PlayerHealth -= CommonThug.strength;
                                WriteLine("The thug retaliated and did {0} damage!", CommonThug.strength);
                            }
                            break;
                        case C:
                            WriteLine("Your Health is {0}.", SelectedCharacter.PlayerHealth);
                            break;
                    }
                }
            }
            if (CommonThug.hitpoints < 0)
            {
                WriteLine();
                WriteLine("You've dealt the final blow, and the thug has fallen!");
                SelectedCharacter.PlayerGold += CommonThug.goldDrops;
                WriteLine();
                WriteLine("Player has receieved {0} gold!", CommonThug.goldDrops);
                PortFight = false;
                AtPort = true;
                AtPortLoop();
            }

        }
    }

    void LocationSelectionLoop()
    {
        while (InLocationSelection == true)
        {

            WriteLine();
            WriteLine("Available Locations: Z = Ship, X = Port, C = City Market, V = Cave, B = Graveyard.");
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("Heading to your ship.");
                    InLocationSelection = false;
                    OnShip = true;
                    OnShipLoop();
                    break;
                case X:
                    WriteLine("Heading to the port.");
                    InLocationSelection = false;
                    AtPort = true;
                    AtPortLoop();
                    break;
                case C:
                    WriteLine("Heading to the market.");
                    InLocationSelection = false;
                    AtCityMarket = true;
                    AtCityMarketLoop();
                    break;
                case V:
                    WriteLine("Heading to the cave.");
                    InLocationSelection = false;
                    InCave = true;
                    InCaveLoop();
                    break;
                case B:
                    WriteLine("Heading to the graveyard.");
                    InLocationSelection = false;
                    AtGraveyard = true;
                    AtGraveyardLoop();
                    break;
            }
        }
    }
    void InCaveEnemyEncounterLoop()
        {
            bool ViewingEnemy = true;
            WriteLine();
            WriteLine("That weird mound moving around is the only movement you spot. Surely it's alive.");
            WriteLine("Fight? Z = Yes, X = No");
            while (ViewingEnemy == true)
            {
            switch (ChoiceSelection())
            {
                case Z:
                    if (RatKing.hitpoints > 0)
                    {
                        ViewingEnemy = false;
                        CaveFightLoop();
                    }
                    else
                    {
                        WriteLine("The Rat King has already been felled from his throne.");
                        ViewingEnemy = false;
                        InCave = true;
                        InCaveLoop();
                    }
                        break;
                    case X:
                        WriteLine("Playing it safe is always an option.");
                        ViewingEnemy = false;
                        InCave = true;
                        InCaveLoop();
                        break;
                }
            }
        }

        void CaveFightLoop()
        {
            bool CaveFight = true;
            WriteLine();
            WriteLine("That shambling mound was the Rat King and his Horde!");
            while (CaveFight && SelectedCharacter.PlayerHealth > 0 && RatKing.hitpoints > 0)
            {
                if (SelectedCharacter.PlayerSpeed < RatKing.speed)
                {
                    WriteLine("What will you do? Z = Check Enemy, X = Attack, C = Check Health.");
                    switch (ChoiceSelection())
                    {
                        case Z:
                            WriteLine("{0} HP, {1} STR, {2} SPD", RatKing.hitpoints, RatKing.strength, RatKing.speed);
                            break;
                        case X:
                            WriteLine("Too Slow! The Rat King's Horde Struck First!");
                            SelectedCharacter.PlayerHealth -= RatKing.strength;
                            CheckDeath();
                        if (SelectedCharacter.PlayerHealth > 0)
                        {
                            RatKing.hitpoints -= SelectedCharacter.PlayerStrength;
                            WriteLine("You hit the thug for {0} damage!", SelectedCharacter.PlayerStrength);
                        }
                            break;
                        case C:
                            WriteLine("Your Health is {0}.", SelectedCharacter.PlayerHealth);
                            break;
                    }
                }
                    else
            {
                    while (SelectedCharacter.PlayerHealth > 0 && RatKing.hitpoints > 0)
                {
                    WriteLine("What will you do? Z = Check Enemy, X = Attack, C = Check Health."); 
                        switch (ChoiceSelection())
                        {
                            case Z:
                                WriteLine("{0} HP, {1} STR, {2} SPD", RatKing.hitpoints, RatKing.strength, RatKing.speed);
                                break;
                            case X:
                                RatKing.hitpoints -= SelectedCharacter.PlayerStrength;
                                WriteLine("You strike into the Rat King and his Horde  for {0} damage!", SelectedCharacter.PlayerStrength);
                            if (RatKing.hitpoints > 0)
                            {
                                SelectedCharacter.PlayerHealth -= RatKing.strength;
                                WriteLine("The Rat King screeches and does {0} damage!", RatKing.strength);
                            }
                                break;
                            case C:
                                WriteLine("Your Health is {0}.", SelectedCharacter.PlayerHealth);
                                break;
                        }
                    }
                }
                if (RatKing.hitpoints < 0)
            {
                WriteLine();
                WriteLine("You've dealt the final blow, and the thug has fallen!");
                SelectedCharacter.PlayerGold += RatKing.goldDrops;
                WriteLine();
                WriteLine("Player has receieved {0} gold!", RatKing.goldDrops);
                CaveFight = false;
                InCave = true;
                InCaveLoop();
            }
                
            }
        }

        void GraveyardFightLoop()
        {
            bool GraveyardFight = true;
            while (GraveyardFight && SelectedCharacter.PlayerHealth > 0 && RichMansSkeleton.hitpoints > 0)
            {
                if (SelectedCharacter.PlayerSpeed < RichMansSkeleton.speed)
                {
                    WriteLine("What will you do? Z = Check Enemy, X = Attack, C = Check Health.");
                    switch (ChoiceSelection())
                    {
                        case Z:
                            WriteLine("{0} HP, {1} STR, {2} SPD", RichMansSkeleton.hitpoints, RichMansSkeleton.strength, RichMansSkeleton.speed);
                            break;
                        case X:
                            WriteLine("Too Slow! The Thug Struck First!");
                            SelectedCharacter.PlayerHealth -= RichMansSkeleton.strength;
                            CheckDeath();
                        if (SelectedCharacter.PlayerHealth > 0)
                        {
                            RichMansSkeleton.hitpoints -= SelectedCharacter.PlayerStrength;
                            WriteLine("You hit the thug for {0} damage!", SelectedCharacter.PlayerStrength);
                        }
                            break;
                        case C:
                            WriteLine("Your Health is {0}.", SelectedCharacter.PlayerHealth);
                            break;
                    }
                }
                    else
            {
                    while (SelectedCharacter.PlayerHealth > 0 && RichMansSkeleton.hitpoints > 0)
                {
                    WriteLine("What will you do? Z = Check Enemy, X = Attack, C = Check Health."); 
                        switch (ChoiceSelection())
                        {
                            case Z:
                                WriteLine("{0} HP, {1} STR, {2} SPD", RichMansSkeleton.hitpoints, RichMansSkeleton.strength, RichMansSkeleton.speed);
                                break;
                            case X:
                                RichMansSkeleton.hitpoints -= SelectedCharacter.PlayerStrength;
                                WriteLine("You hit the thug for {0} damage!", SelectedCharacter.PlayerStrength);
                            if (RichMansSkeleton.hitpoints > 0)
                            {
                                SelectedCharacter.PlayerHealth -= RichMansSkeleton.strength;
                                WriteLine("The thug retaliated and did {0} damage!", RichMansSkeleton.strength);
                            }                          
                                break;
                            case C:
                                WriteLine("Your Health is {0}.", SelectedCharacter.PlayerHealth);
                                break;
                        }
                    }
                }
                if (RichMansSkeleton.hitpoints < 0)
            {
                WriteLine();
                WriteLine("You've dealt the final blow, and the thug has fallen!");
                SelectedCharacter.PlayerGold += RichMansSkeleton.goldDrops;
                WriteLine();
                WriteLine("Player has received {0} gold!", RichMansSkeleton.goldDrops);
                GraveyardFight = false;
                AtGraveyard = true;
                AtGraveyardLoop();
            }
                
            }
        }
}
    

    

class Character
{
    //Player Information
    public string PlayerClass = "";
    public int PlayerHealth;
    public int PlayerStrength;
    public int PlayerSpeed;
    public int PlayerGold;

    public Character() { }
    public Character(string Class, int HP, int STR, int SPD, int GLD)
    {
        PlayerClass = Class;
        PlayerHealth = HP;
        PlayerStrength = STR;
        PlayerSpeed = SPD;
        PlayerGold = GLD;
    }

    public override string ToString()
    {
        return $"{PlayerClass} (HP: {PlayerHealth}, STR: {PlayerStrength}, SPD: {PlayerSpeed}, GLD: {PlayerGold})";
    }
}

//Enemy Info
namespace enemies1
{

    public class Enemies
    {

        public string name;
        public int hitpoints;

        public int strength;

        public int speed;

        public int experienceDrops;

        public int goldDrops;
        public bool isAlive;

        public Enemies(string NM, int HP, int STR, int SPD, int EXP, int GOLD)
        {
            name = NM;
            hitpoints = HP;
            strength = STR;
            speed = SPD;
            goldDrops = GOLD;
            experienceDrops = EXP;
            if (hitpoints > 0)
            {
                isAlive = true;
            }
            else
            {
                isAlive = false;
            }

        }
        private bool deathCheck()
        {
            return isAlive;
        }
    }
}

//weapon initialization

enum Strength
{
    Cutlass = 20,
    Dagger = 10,
    FlintlockPistols = 40
}

record Location
{
    public string LocationDescription { get; init; }
    public string LocationHostility { get; init; }
}