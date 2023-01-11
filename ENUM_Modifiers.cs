using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The brews and ingredients all have three modifier labels. This enum defines their values.
public class ENUM_Modifiers
{
    public enum Taste
    {
        Spicy,
        Sweet,
        Bitter,
        Plain
    }

    public enum Magic
    {
        Enchanted,
        Ordinary,
        Cursed
    }

    public enum ItemType
    {
        Meaty,
        Veggie,
        Commodity
    }
}
