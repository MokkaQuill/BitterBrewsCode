using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;

public class Customers : MonoBehaviour
    // This script sits on the customer game object. It handles the logic about which customer to display
{
    // Create an array of all the scriptable object customers. These need to be added in the inspector
    [SerializeField] SO_Customers[] customerList;
    SO_Customers currentCustomer;

    // References to other scripts
    [SerializeField] PotionMaking potionMaking;
    [SerializeField] DialogueRunner dialogue;

    [SerializeField] Image customerImage;
    [SerializeField] Animator animator;
    private int customerNumber = 0;

    // References to the description text boxes in the top right
    [SerializeField] TMP_Text nameBox;
    [SerializeField] TMP_Text magicBox;
    [SerializeField] TMP_Text tasteBox;
    [SerializeField] TMP_Text typeBox;
    [SerializeField] TMP_Text descriptionBox;

    // Create an array of all the ingredient game objects
    [SerializeField] GameObject[] newIngredients;


    void Start()
    {
        currentCustomer = customerList[0];
        customerImage.sprite = currentCustomer.artwork; 
    }

    public void ServeButton()
    {
       // TO BE CALLED BY YARN
       // When this function is called, if the current brew matches the current customers favourite drink, stop current dialogue, start success dialogue and empty the brew box
            if (potionMaking.currentBrew == currentCustomer.favouriteDrink)
            {
                dialogue.Stop();
                dialogue.StartDialogue(currentCustomer.customerSuccess);
                potionMaking.DiscardBrew();
                                             
            }
        //Else stop current dialogue, start failure dialogue and empty the brew box
        else
        {
                dialogue.Stop();
                dialogue.StartDialogue(currentCustomer.customerFail);
                potionMaking.DiscardBrew();
            }
        

    
    }

    // THE FOLLOWING IS YARN SETUP

    // Animation for leaving customer
    [YarnCommand("CustomerOut")]
        public void CustomerOut()
    {
        animator.Play("CustomerAnimationLeft");

    }

    // Switch the customer to the next in the array, along with the art
    [YarnCommand("SwapCustomer")]
    public void SwapCustomer()
    {
         currentCustomer = customerList[++customerNumber];
         customerImage.sprite = currentCustomer.artwork;
        Debug.Log("current customer = " + currentCustomer.name);
    }

    // Animation for entering customer
    [YarnCommand("CustomerIn")]
    public void CustomerIn()
    {
        animator.Play("CustomerAnimationRight");
    }


    // Make the first set of new ingredients available
    [YarnCommand("AddIngredients01")]
    public void AddIngredients01()
    {
        Debug.Log("IngredientsHit");
        newIngredients[0].SetActive(true);
        Debug.Log("IngredientSetActive");
        newIngredients[1].SetActive(true);
        newIngredients[2].SetActive(true);
    }

    // Make the second set of new ingredients available
    [YarnCommand("AddIngredients02")]
    public void AddIngredients02()
    {
        newIngredients[3].SetActive(true);
        newIngredients[4].SetActive(true);
        newIngredients[5].SetActive(true);
    }

    // Make the third set of new ingredients available
    [YarnCommand("AddIngredients03")]
    public void AddIngredients03()
    {
        newIngredients[6].SetActive(true);
        newIngredients[7].SetActive(true);
        newIngredients[8].SetActive(true);
    }
}
