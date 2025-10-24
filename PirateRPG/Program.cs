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

Enemies CommonThug = new("Common Thug", 10, 5, 9, 15, 2);

//Locations
Location Ship = new() { LocationDescription = "Your ship. It's not big or flashy, but its yours.", LocationHostility = "It's YOUR ship. Of course there's no enemies!" };
Location Port = new() { LocationDescription = "The port is bustling with all kinds of people. From innocent children to slimy merchants. You even see a fish vendor waving you down.", LocationHostility = "Besides a few street thugs its realtively peacful, but the bounties on those low level thugs are still worht gold!" };
Location CityMarket = new() { LocationDescription = "The market is busy, there's many things to buy", LocationHostility = "not that hostile" };

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
    bool OnShip = true;
    bool AtPort = false;
    bool AtCityMarket = false;
    bool InCave = false;
    bool AtGraveyard = false;

    OnShipLoop();

    void OnShipLoop()
    {
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
                    AtCityMarket = false;
                    CityMarketEnemyEncounterLoop();
                    break;
                case V:
                    AtCityMarket = false;
                    InLocationSelection = true;
                    LocationSelectionLoop();
                    break;

            }
        }
    }
    void CityMarketEnemyEncounterLoop() // finish this later
    {
        bool ViewingEnemy = true;
        WriteLine();
        WriteLine("Fight? Z = Yes, X = No");
    }

    void CityMarketDescriptionLoop()
    {
        bool TalkingToBlacksmith = true;
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
        while (BrowsingBlacksmith = true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("Weapons available: Z = Cutlass, X = Dagger, C = Flintlock Pistols, V = Exit Blacksmith");
                    BrowsingBlacksmith = false;
                    WeaponsLoop();
                    break;
                case X:
                    BrowsingBlacksmith = false;
                    WeaponsLoop();
                    break;
                case C:
                    BrowsingBlacksmith = false;
                    WeaponsLoop();
                    break;
                case V:
                    BrowsingBlacksmith = false;
                    AtCityMarketLoop();
                    break;
            }
        }
    }
    
    void WeaponsLoop()
    {
        bool ChooseWeapon = true;
        while (ChooseWeapon = true)
        {
            switch (ChoiceSelection())
            {
                case Z:
                    WriteLine("You chose the cutlass, a short sword good for close combat! Str: +20");
                    ChooseWeapon = false;
                    AtCityMarket = true;
                    AtCityMarketLoop();
                    break;
                case X:
                    WriteLine("You chose the Dagger, a short blade good for close combat! Str: +10 ");
                    ChooseWeapon = false;
                    AtCityMarket = true;
                    AtCityMarketLoop();
                    break;
                case C:
                    WriteLine("You chose the Flintlock Pistols, single hand firearms often used in pairs and good for close combat! Str: +40 ");
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
                        ViewingEnemy = false;
                        PortFightLoop();
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
            while (PortFight == true)
            {
                if (SelectedCharacter.PlayerSpeed < CommonThug.speed)
                {
                    while (SelectedCharacter.PlayerHealth > 0 & CommonThug.hitpoints > 0)
                    {
                        WriteLine("Too Slow! The Thug Struck First!");
                        SelectedCharacter.PlayerHealth -= CommonThug.strength;
                        CheckDeath();
                        WriteLine("What will you do? Z = Check Enemy, X = Attack, C = Check Health, V = Run Away.");
                        switch (ChoiceSelection())
                        {
                            case Z:
                                WriteLine("{0}", CommonThug);
                                break;
                            case X:
                                CommonThug.hitpoints -= SelectedCharacter.PlayerStrength;
                                WriteLine("You hit the thug for {0} damage!", SelectedCharacter.PlayerStrength);
                                break;
                            case C:
                                WriteLine("Your Health is {0}.", SelectedCharacter.PlayerHealth);
                                break;
                            case V:
                                if (SelectedCharacter.PlayerSpeed > CommonThug.speed)
                                {
                                    PortFight = false;
                                    AtPortLoop();
                                }
                                else
                                {
                                    WriteLine("Too slow! Can't get away!");
                                }
                                break;
                        }
                    }

                }
                else
                {
                    while (SelectedCharacter.PlayerHealth > 0 && CommonThug.hitpoints > 0)
                {
                        WriteLine("What will you do? Z = Check Enemy, X = Attack, C = Check Health, V = Run Away.");
                        switch (ChoiceSelection())
                        {
                            case Z:
                                WriteLine("{0}", CommonThug);
                                break;
                            case X:
                                CommonThug.hitpoints -= SelectedCharacter.PlayerStrength;
                                WriteLine("You hit the thug for {0} damage!", SelectedCharacter.PlayerStrength);
                                break;
                            case C:
                                WriteLine("Your Health is {0}.", SelectedCharacter.PlayerHealth);
                                break;
                            case V:
                                if (SelectedCharacter.PlayerSpeed > CommonThug.speed)
                                {
                                    PortFight = false;
                                    AtPortLoop();
                                }
                                else
                                {
                                    WriteLine("Too slow! Can't get away!");
                                }
                                break;
                        }
                    }
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
                        break;
                    case B:
                        WriteLine("Heading to the graveyard.");
                        InLocationSelection = false;
                        AtGraveyard = true;
                        break;
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
            NM = name;
            HP = hitpoints;
            STR = strength;
            SPD = speed;
            GOLD = goldDrops;
            EXP = experienceDrops;
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

record Location
{
    public string LocationDescription { get; init; }
    public string LocationHostility { get; init; }
}