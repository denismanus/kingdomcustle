using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class DataKeeper : MonoBehaviour
{
    public Item[] _items;
    public Item _hand;
    public Location[] _locations; 
    [SerializeField]
    public static Item[] items;
    public static Location[] locations;
    public static DataKeeper instance;
    public static Item hand;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        if (items == null)
        {
            items = _items;
            locations = _locations;
            hand = _hand;
        }
    }
}
