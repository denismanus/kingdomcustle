using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WareHouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<Resource, int> resourcesStorage;
    private Dictionary<Item, int> itemsStorage;
    private UIController uIController;

    public void AddResource(Resource res, int count)
    {
        if (resourcesStorage.ContainsKey(res))
        {
            resourcesStorage[res] += count;
            UpdateResourceWareHouseUI();
        }
        else
        {
            resourcesStorage.Add(res, count);
            UpdateResourceWareHouseUI();
            CheckNewRecipes();
        }
    }

    public List<Item> GetItems(Item.Specializations specialization)
    {
        return itemsStorage.Keys.Where(x => x.specialization.Equals(specialization)&& itemsStorage[x]!=0).ToList();
    }

    public void OpenWareHouse()
    {
        UpdateItemsWareHouseUI();
        UpdateResourceWareHouseUI();
        uIController.SortSlots();
    }

    public bool TryToCraft(Item item)
    {
        for(int i = 0; i < item.recipeToCraft.Length; i++)
        {
            if (!resourcesStorage.ContainsKey(item.recipeToCraft[i].resource))
                return false;
            if (resourcesStorage[item.recipeToCraft[i].resource] < item.recipeToCraft[i].count)
                return false;
        }
        for (int i = 0; i < item.itemsToCraft.Length; i++)
        {
            if (!itemsStorage.ContainsKey(item.itemsToCraft[i]))
                return false;
            if (itemsStorage[item.itemsToCraft[i]] < 1)
                return false;

        }

        foreach (Recipe res in item.recipeToCraft)
            resourcesStorage[res.resource] -= res.count;

        switch (item.type)
        {
            case Item.Types.Instrument:
                foreach (Item it in item.itemsToCraft)
                    UseItemToCraft(it);
                break;
        }
        itemsStorage[item]++;
        UpdateResourceWareHouseUI();
        UpdateItemsWareHouseUI();
        return true;
    }



    private void UseItemToCraft(Item item)
    {
        itemsStorage[item]--;
    }

    private void CheckNewRecipes()
    {
        foreach(Item item in DataKeeper.items.Except(itemsStorage.Keys))
        {
            //for (int i = 0; i < item.recipeToCraft.Length; i++)
            //{
            //    if (!resourcesStorage.Keys.Contains(item.recipeToCraft[i].resource))
            //        return; ;
            //}
            //for (int i = 0; i < item.itemsToCraft.Length; i++)
            //{
            //    if (!itemsStorage.Keys.Contains(item.itemsToCraft[i]))
            //        return;
            //}
            //itemsStorage.Add(item, 0);
            //UpdateItemsWareHouseUI();
            switch (item.type)
            {
                case Item.Types.Element:
                    for (int i = 0; i < item.recipeToCraft.Length; i++)
                    {
                        if (!resourcesStorage.Keys.Contains(item.recipeToCraft[i].resource))
                            return; ;
                    }
                    for (int i = 0; i < item.itemsToCraft.Length; i++)
                    {
                        if (!itemsStorage.Keys.Contains(item.itemsToCraft[i]))
                            return;
                    }
                    itemsStorage.Add(item, 0);
                    UpdateItemsWareHouseUI();
                    break;

                case Item.Types.Instrument:
                    for (int i = 0; i < item.recipeToCraft.Length; i++)
                    {
                        if (!resourcesStorage.Keys.Contains(item.recipeToCraft[i].resource))
                            return; ;
                    }
                    for (int i = 0; i < item.itemsToCraft.Length; i++)
                    {
                        if (!itemsStorage.Keys.Contains(item.itemsToCraft[i]))
                            return;
                    }
                    itemsStorage.Add(item, 0);
                    UpdateItemsWareHouseUI();
                    break;
            }
        }
        uIController.SortSlots();
    }

    

    public void UpdateResourceWareHouseUI()
    {
        uIController.UpdateWarehouseUI(resourcesStorage);
    }

    public void UpdateItemsWareHouseUI()
    {
        uIController.UpdateWarehouseUI(itemsStorage);
    }

    private void Awake()
    {
        resourcesStorage = new Dictionary<Resource, int>();
        itemsStorage = new Dictionary<Item, int>();
        uIController = GetComponent<UIController>();
    }

    void Start()
    {
        
    }

}
