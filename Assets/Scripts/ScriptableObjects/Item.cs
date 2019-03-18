using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Item")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public Recipe[] recipeToCraft;
    public Item[] itemsToCraft;
    public Types type;
    public Specializations specialization;
    public int sortId;
    public float timeToCraft;

    public float speedModifier = 1f;
    public Resource[] resourcesToMine;

    public enum Types
    {
        Element,
        Instrument,
        Human,
        Building,

    }

    public enum Specializations
    {
        Simple,
        Blue, 
        Yellow
    }
}
