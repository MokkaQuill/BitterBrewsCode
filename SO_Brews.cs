using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Brew", menuName = "Brew")]

// Scriptable Object setup for Brew Ingredients. It also handles assigning labels automatically based on the ingredients that make them.

public class SO_Brews : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;
    public Sprite bigArtwork;

    public SO_Ingredients[] ingredient;


    public ENUM_Modifiers.Taste taste { get 
        { 
          // If two or more ingredients have the same taste, return that taste, else label as plain
            if (ingredient[0].taste == ingredient[1].taste || ingredient[0].taste == ingredient[2].taste)
            {
                return ingredient[0].taste;
            }
            if (ingredient[1].taste == ingredient[2].taste)
            {
                return ingredient[1].taste;
            }
            else
            {
                return ENUM_Modifiers.Taste.Plain;
            }
        } 
    }

    public ENUM_Modifiers.Magic magic { get
        {
            // If two or more ingredients have the same magic type, return that magic type, else label as ordinary
            if (ingredient[0].magic == ingredient[1].magic || ingredient[0].magic == ingredient[2].magic)
            {
                return ingredient[0].magic;
            }
            if (ingredient[1].magic == ingredient[2].magic)
            {
                return ingredient[1].magic;
            }
            else
            {
                return ENUM_Modifiers.Magic.Ordinary;
            }
        }
    }

    public ENUM_Modifiers.ItemType itemType { get
        {
            // If an ingredient is labeled as meaty or veggie, assign it to the relevant var
            var isMeaty = ingredient.Any(name => name.itemType == ENUM_Modifiers.ItemType.Meaty);
            var hasVeggie = ingredient.Any(name => name.itemType == ENUM_Modifiers.ItemType.Veggie);

           // Meaty > Veggie > Commodity
            if (isMeaty == true)
            {
                return ENUM_Modifiers.ItemType.Meaty;
            }
            else if (hasVeggie == true)
            {
                return ENUM_Modifiers.ItemType.Veggie;
            }
            else
            {
                return ENUM_Modifiers.ItemType.Commodity;
            }
        }
    }


}