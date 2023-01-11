using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BrewIcon : MonoBehaviour
// This script sits on the box that shows the brew that has been made. It handles the display of stats from the current brew, to be displayed in the top right of the game.

{
    // References to the Brews Scriptable Object
    public SO_Brews ingredient;

    // References in the Inspector for all of the on screen fields to be updated by this script
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] TMP_Text magicText;
    [SerializeField] TMP_Text tasteText;
    [SerializeField] TMP_Text typeText;
    [SerializeField] Image itemImage;

    private void Start()
    {
        baseDescription();
    }

    private void OnMouseOver()
    {
        // When the box is hovered, show the stats of whatever brew has been made, if there is one
        if (ingredient != null)
        {
            DisplayStats();
        }

    }

    public void DisplayStats()
    {
       // Brew stat text
        itemName.text = ingredient.name;
        itemDescription.text = ingredient.description;
        magicText.text = ingredient.magic.ToString();
        tasteText.text = ingredient.taste.ToString();
        typeText.text = ingredient.itemType.ToString();
    }

    public void baseDescription()
    {
        // Sets the decription box to empty
        itemName.text = "";
        itemDescription.text = "";
        magicText.text = "";
        tasteText.text = "";
        typeText.text = "";
    }

}
