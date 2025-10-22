using static System.Console;
using System.Runtime.CompilerServices;

//Selection keys
const ConsoleKey Z = ConsoleKey.Z;
const ConsoleKey X = ConsoleKey.X;
const ConsoleKey C = ConsoleKey.C;
const ConsoleKey V = ConsoleKey.V;

//Gets player choices
ConsoleKey ChoiceSelection()
{
    ConsoleKey choice = ReadKey(true).Key;
    WriteLine();
    return choice;
}

//Character Classes
Character Swashbuckler = new("Swashbuckler", 15, 5, 10);
Character Scallywag = new("Scallywag", 12, 3, 15);
Character Captain = new("Captain", 15, 7, 8);

Character SelectedCharacter = Swashbuckler;

bool ClassSelectionState = true;

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



class Character
{
    //Player Information
    private string PlayerClass = "";
    private int PlayerHealth;
    private int PlayerStrength;
    private int PlayerSpeed;

    public Character() { }
    public Character(string Class, int HP, int STR, int SPD)
    {
        PlayerClass = Class;
        PlayerHealth = HP;
        PlayerStrength = STR;
        PlayerSpeed = SPD;
    }

    public override string ToString()
    {
        return $"{PlayerClass} (HP: {PlayerHealth}, STR: {PlayerStrength}, SPD: {PlayerSpeed})";
    }
}

//Enemy Info
namespace enemies1
{

    public class Enemies
    {

        private string name;
        private int hitpoints;

        private int strength;

        private int speed;

        private int experienceDrops;

        private int goldDrops;
        private bool isAlive;

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