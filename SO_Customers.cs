using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

// Scriptable Object setup for Customers

[System.Serializable]
[CreateAssetMenu(fileName = "New Customer", menuName = "Customer")]
public class SO_Customers : ScriptableObject
{
    public new string name;

    public Sprite artwork;

    public SO_Brews favouriteDrink;

    public string customerSuccess;
    public string customerFail;
    public string customerIntro;



}
