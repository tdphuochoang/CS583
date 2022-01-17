using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using Random = System.Random;


public class RollCharacterControl : CharacterVar
{
    //list containing the values for race and class
    List<string> charList = new List<string>() { "Select Character", "Dragonborn", "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human", "Tiefling" };
    List<string> charListdesc = new List<string>() {
        "Character Description",
        "Your draconic heritage manifests in a variety of traits you share with other dragonborn.",
        "Your dwarf character has an assortment of abilities, part and parcel of dwarven nature.",
        "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement.",
        "Your gnome character has certain characteristics in common with all other gnomes.",
        "Your half-elf character has some qualities in common with elves and some that are unique to half-elves.",
        "Your half-orc character has certain traits deriving from your orc ancestry.",
        "Your halfling character has a number of traits in common with all other halflings.",
        "It's hard to make generalizations about humans, but your human character has these traits.",
        "Tieflings share certain racial traits as a result of their infernal descent." };
    List<string> classList = new List<string>() { "Select Class", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
    List<string> classListdesc = new List<string>() {
        "Class Description",
        "In battle, you fight with primal ferocity. For some barbarians, rage is a means to an end–that end being violence.",
        "Whether singing folk ballads in taverns or elaborate compositions in royal courts, bards use their gifts to hold audiences spellbound.",
        "Clerics act as conduits of divine power.",
        "Druids venerate the forces of nature themselves. Druids holds certain plants and animals to be sacred, and most druids are devoted to one of the many nature deities",
        "Different fighters choose different approaches to perfecting their fighting prowess, but they all end up perfecting it.",
        "Coming from monasteries, monks are masters of martial arts combat and meditators with the ki living forces.",
        "Paladins are the ideal of the knight in shining armor; they uphold ideals of justice, virtue, and order and use righteous might to meet their ends.",
        "Acting as a bulwark between civilization and the terrors of the wilderness, rangers study, track, and hunt their favored enemies.",
        "Rogues have many features in common, including their emphasis on perfecting their skills, their precise and deadly approach to combat, and their increasingly quick reflexes.",
        "An event in your past, or in the life of a parent or ancestor, left an indelible mark on you, infusing you with arcane magic. As a sorcerer the power of your magic relies on your ability to project your will into the world.",
        "You struck a bargain with an otherworldly being of your choice: the Archfey, the Fiend, or the Great Old One who has imbued you with mystical powers, granted you knowledge of occult lore, bestowed arcane research and magic on you and thus has given you facility with spells",
        "The study of wizardry is ancient, stretching back to the earliest mortal discoveries of magic. As a student of arcane magic, you have a spellbook containing spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells."};
    List<string> alignmentList = new List<string>() { "Select Alignment", "Lawful good", "Neutral good", "Chaotic good", "Lawful neutral", "Neutral", "Chaotic neutral", "Lawful evil", "Neutral evil", "Chaotic evil" };

    //objects to be referenced in game
    public TMP_Dropdown dropdownRace;
    public TextMeshProUGUI charDesc;

    public TMP_Dropdown dropdownChar;
    public TextMeshProUGUI classDesc;

    public TMP_Dropdown dpAlign;

    public TextMeshProUGUI totalAvgDie;

    Random rnd = new Random();

    PlayerData pd = new PlayerData();

    //call the method to populate list
    void Start()
    {
        PopulateList();
    }

    //populates the dropdown list
    void PopulateList()
    {
        dropdownRace.AddOptions(charList);
        dropdownChar.AddOptions(classList);
        dpAlign.AddOptions(alignmentList);

    }

    //display race description and assign specified race to protected charRace var
    public void DropdownRaceDesc(int index)
    {
        charDesc.text = charListdesc[index];
        if (index > 0)
        {
            pd.charRace = charList[index];
        }

        Debug.Log("charRace = " + pd.charRace);
    }

    //display class description and assign specified class to protected charClass var
    public void DropdownClassDesc(int index)
    {
        classDesc.text = classListdesc[index];
        if (index > 0)
        {
            pd.charClass = classList[index];
        }
        Debug.Log("charClass = " + pd.charClass);


    }

    //assign specified alignment to align var
    public void DropdownAlignment(int index)
    {
        if (index > 0)
        {
            pd.align = alignmentList[index];
        }
        Debug.Log("alignment = " + pd.align);

    }


    //assign playerName to charName var
    public void OnValueChanged(string playerName)
    {
        pd.charName = playerName;
        Debug.Log("charName = " + pd.charName);
    }

    //assign strength points + 2 
    public void StrenChanged(string x)
    {
        pd.ability_Strength = float.Parse(x) + 2;
        Debug.Log("ability_Strength = " + pd.ability_Strength);
    }

    //assign constitution points + 2 
    public void ConstChanged(string x)
    {
        pd.ability_Constitution = float.Parse(x) + 2;
        Debug.Log("ability_Constitution = " + pd.ability_Constitution);
    }

    //assign dexterity points + 2 
    public void DexChanged(string x)
    {
        pd.ability_Dexterity = float.Parse(x) + 2;
        Debug.Log("ability_Dexterity = " + pd.ability_Dexterity);
    }

    //assign intelligence points + 2 
    public void IntChanged(string x)
    {
        pd.ability_Intelligence = float.Parse(x) + 2;
        Debug.Log("ability_Intelligence = " + pd.ability_Intelligence);
    }

    //assign charisma points + 2 
    public void CharChanged(string x)
    {
        pd.ability_Charisma = float.Parse(x) + 2;
        Debug.Log("ability_Charisma = " + pd.ability_Charisma);
    }

    //assign wisdom points + 2 
    public void WisChanged(string x)
    {
        pd.ability_Wisdom = float.Parse(x) + 2;
        Debug.Log("ability_Wisdom = " + pd.ability_Wisdom);
    }

    //assign the current experience
    public void ExpCurrentChanged(string x)
    {
        pd.expCurrent = int.Parse(x);
        Debug.Log("expCurrent = " + pd.expCurrent);
    }

    //assign the max experience
    public void ExpMaxChanged(string x)
    {
        pd.expMax = int.Parse(x);
        Debug.Log("expMax = " + pd.expMax);
    }

    //assign the current hit point
    public void HpCurrentChanged(string x)
    {
        pd.hpCurrent = int.Parse(x);
        Debug.Log("hpCurrent = " + pd.hpCurrent);
    }

    //assign the max hit point 
    public void HpMaxChanged(string x)
    {
        pd.hpMax = int.Parse(x);
        Debug.Log("hpMax = " + pd.hpMax);
    }

    //assign the armor class points
    public void ArmorClassChanged(string x)
    {
        pd.armorClass = int.Parse(x);
        Debug.Log("armorClass = " + pd.armorClass);
    }

    //assign the walking speed
    public void SWalkingChanged(string x)
    {
        pd.sWalking = int.Parse(x);
        Debug.Log("sWalking = " + pd.sWalking);
    }

    //assign the running speed
    public void SRunningChanged(string x)
    {
        pd.sRunning = int.Parse(x);
        Debug.Log("sRunning = " + pd.sRunning);
    }

    //assign the jumping speed
    public void SJumpChanged(string x)
    {
        pd.sJumpHeight = int.Parse(x);
        Debug.Log("sJumpHeight = " + pd.sJumpHeight);
    }


    //dice roll
    public void DiceOnClick()
    {
        int x, first, second, third;
        first = second = third = 000;
        int[] arr = new int[5];
        int y = 0;

        //populates array
        for (int i = 0; i < 5; i++)
        {
            x = rnd.Next(0, 7);
            arr[i] = x;
            Debug.Log(arr[i]);
        }

        //iterates through array to find the three largest numbers
        for (int i = 0; i < 5; i++)
        {
            if (arr[i] > first)
            {
                third = second;
                second = first;
                first = arr[i];
            }
            else if (arr[i] > second)
            {
                third = second;
                second = arr[i];
            }
            else if (arr[i] > third)
                third = arr[i];
        }
        y = first + second + third;
        totalAvgDie.text = y.ToString();
        Debug.Log("totalAvgDie = " + totalAvgDie.text);
    }

    //save the variables to a JSON string file
    public void JsonSave()
    {
        string json = JsonUtility.ToJson(pd);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
        Debug.Log(Application.dataPath);

    }

}


