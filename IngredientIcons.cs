using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// This script handles the logic for the ingredients - as well as displaying the information about them from their scriptable objects. It sits on the boxes that display ingredients.

public class IngredientIcons : MonoBehaviour
{
    // Get a reference to the scriptable object class and all of the text and images they will affect in the scene
    public SO_Ingredients ingredient;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] TMP_Text magicText;
    [SerializeField] TMP_Text tasteText;
    [SerializeField] TMP_Text typeText;
    [SerializeField] Image itemImage;

    private void Start()
    {
        itemImage.sprite = ingredient.artwork;
    }

   // When an ingredient is hovered, show it's information in the top right
    private void OnMouseOver()
    {
        itemName.text = ingredient.name;
        itemDescription.text = ingredient.description;
        magicText.text = ingredient.magic.ToString();
        tasteText.text = ingredient.taste.ToString();
        typeText.text = ingredient.itemType.ToString();
        
    }

 

}
