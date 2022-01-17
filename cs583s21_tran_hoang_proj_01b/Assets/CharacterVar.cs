using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVar : MonoBehaviour
{
    protected class PlayerData
    {
        public string charName;
        public string charRace;
        public string charClass;
        public float ability_Strength;
        public float ability_Constitution;
        public float ability_Dexterity;
        public float ability_Intelligence;
        public float ability_Charisma;
        public float ability_Wisdom;
        public string align;
        public int expCurrent;
        public int expMax;
        public int hpCurrent;
        public int hpMax;
        public int armorClass;
        public int sWalking;
        public int sRunning;
        public int sJumpHeight;

        //empty list for item list
        public List<string> itemList = new List<string>() { };
    }
}


