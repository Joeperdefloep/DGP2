using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item item;
    [Range(1, 999)]
    public int Amount;
}



[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;

    public bool CanCraft(CraftingInput inventory)
    {
        return false;
    }

    public void Craft(CraftingInput inventory)
    {

    }
}
