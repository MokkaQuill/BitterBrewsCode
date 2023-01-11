using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PotionMaking : MonoBehaviour
// This script handles the potion making mechanics, and sits on the cauldron game object, which also acts a game manager
{
    // References to the three image boxes that show what ingredients you have added to the potion, and the potion image
    [SerializeField] Image itemBox01;
    [SerializeField] Image itemBox02;
    [SerializeField] Image itemBox03;
    [SerializeField] Image brewImage;

    // An array of all Brew scriptable objects
    [SerializeField] SO_Brews[] brewList;

    // Creating references to handle the three ingredients in the potion
    SO_Ingredients ingredient01;
    SO_Ingredients ingredient02;
    SO_Ingredients ingredient03;

    // Reference to the BrewIcon script
    [SerializeField] BrewIcon brewIconScript;

    // Other variables
    bool ingredient01Filled = false;
    bool ingredient02Filled = false;
    bool ingredient03Filled = false;
    public Sprite blankSprite;
    public SO_Brews currentBrew;
    public SO_Brews sludge;
    
    
    // Handles adding ingredients to the current potion
    // Checks to see if a game object has stopped colliding with this (the cauldron), if the left mouse button was released, and which slot to fill, if any 
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Colliding");
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("CollisionExit");
            if (!ingredient01Filled)
            {
                SO_Ingredients ingredient = collision.gameObject.transform.parent.gameObject.GetComponent<IngredientIcons>().ingredient;
                itemBox01.sprite = ingredient.artwork;
                ingredient01 = ingredient;
                ingredient01Filled = true;

            }
            else if (!ingredient02Filled)
            {
                SO_Ingredients ingredient = collision.gameObject.transform.parent.gameObject.GetComponent<IngredientIcons>().ingredient;
                itemBox02.sprite = ingredient.artwork;
                ingredient02 = ingredient;
                ingredient02Filled = true;
            }
            else if (!ingredient03Filled)
            {
                SO_Ingredients ingredient = collision.gameObject.transform.parent.gameObject.GetComponent<IngredientIcons>().ingredient;
                itemBox03.sprite = ingredient.artwork;
                ingredient03 = ingredient;
                ingredient03Filled = true;
            }
            else
            {
                return;
            }
        }

        
    }

    // Call this function to make a potion
    // Checks for duplicate ingredients, then checks against the brews list to see if it a valid recipe. If it is, then it updates the brew to match, else creates a failed potion.
    public void MixBrew()
    {
        if (ingredient01Filled && ingredient02Filled && ingredient03Filled)
        {
            Debug.Log(ingredient01.name);
            Debug.Log(ingredient02.name);
            Debug.Log(ingredient03.name);
            
                if (ingredient01 == ingredient02 || ingredient02 == ingredient03 || ingredient01 == ingredient03) 
                {
                    currentBrew = sludge;
                    brewImage.sprite = sludge.artwork;
                    brewIconScript.ingredient = sludge;
                    brewIconScript.DisplayStats();
                    Debug.Log("Potion Failed  - Duplicate!");
                    return;
                }

            foreach (SO_Brews brew in brewList)
            {
                if (brew.ingredient.Contains(ingredient01) && brew.ingredient.Contains(ingredient02) && brew.ingredient.Contains(ingredient03))
                {
                    currentBrew = brew;
                    brewImage.sprite = brew.artwork;
                    brewIconScript.ingredient = brew;
                    brewIconScript.DisplayStats();
                    Debug.Log("Potion made!");
                    return;
                }
                else
                {
                   currentBrew = sludge;
                   brewImage.sprite = sludge.artwork;
                   brewIconScript.ingredient = sludge;
                   brewIconScript.DisplayStats();
                    Debug.Log("Potion Failed - Invalid Recipe!");
                }
            }
        }

    }

    // Function to reset potion making. Empties all ingredients, current brew and resets to default.
    public void DiscardBrew()
    {
        Debug.Log("Press");
        ingredient01Filled = false;
        ingredient02Filled = false;
        ingredient03Filled = false;
        currentBrew = null;
        itemBox01.sprite = blankSprite; Debug.Log("Sprite");
        itemBox02.sprite = blankSprite;
        itemBox03.sprite = blankSprite;
        brewImage.sprite = blankSprite;
        brewIconScript.ingredient = null;
        brewIconScript.baseDescription();
    }

  

}
