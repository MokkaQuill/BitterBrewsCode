using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Scriptable Object setup for Potion Ingredients

[System.Serializable]
[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class SO_Ingredients : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;
    public Sprite bigArtwork;

    public ENUM_Modifiers.Taste taste;
    public ENUM_Modifiers.Magic magic;
    public ENUM_Modifiers.ItemType itemType;

}

