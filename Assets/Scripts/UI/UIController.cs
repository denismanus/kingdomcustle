using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    private List<InventorySlot> slots;
    private InventorySlot slotHandler;
    private WareHouse wareHouse;

    public void UpdateWarehouseUI(Dictionary<Resource, int> storage)
    {
        if (!CheckData())
            return;
        foreach (Resource res in storage.Keys)
        {
            FillBlock(res, storage[res]);
        }
    }

    public void SortSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            for (int j = i + 1; j < slots.Count; j++)
            {
                if (!slots[i].isUsed() || !slots[j].isUsed())
                    continue;
                if (slots[i].GetSortId() > slots[j].GetSortId())
                {
                    //Debug.Log(slots[i].GetSortId() + " " + slots[j].GetSortId());
                    Swap(slots[i], slots[j]);
                }
            }
        }
    }

    public void Swap(InventorySlot first, InventorySlot second)
    {
        Resource res = first.GetResource();
        Item item = first.GetItem();
        int count = (first.GetCount());
        first.Clear();
        first.SetResource(second.GetResource());
        first.SetItem(second.GetItem());
        first.SetCount(second.GetCount());
        second.Clear();
        second.SetResource(res);
        second.SetItem(item);
        second.SetCount(count);
    }


    public void UpdateWarehouseUI(Dictionary<Item, int> storage)
    {
        if (!CheckData())
            return;
        foreach (Item item in storage.Keys)
        {
            FillBlock(item, storage[item]);
        }
    }

    private void FillBlock(Resource res, int count)
    {
        slotHandler = slots.FirstOrDefault(t => t.GetResource() == res);
        if (slotHandler == null)
        {
            slotHandler = slots.FirstOrDefault(t => !t.isUsed());
            slotHandler.SetResource(res);
        }
        slotHandler.SetCount(count);
    }

    private void FillBlock(Item item, int count)
    {
        slotHandler = slots.FirstOrDefault(t => t.GetItem() == item);
        if (slotHandler == null)
        {
            slotHandler = slots.FirstOrDefault(t => !t.isUsed());
            slotHandler.SetItem(item);
        }
        slotHandler.SetCount(count);
    }


    void Start()
    {

    }

    private bool CheckData()
    {
        if (slots == null || slots.Count == 0)
        {
            slots = FindObjectsOfType<InventorySlot>().OrderBy(t => t.name).ToList();
            foreach (InventorySlot slot in slots)
                slot.SetWarehouse(wareHouse);
        }
        if (slots.Count == 0)
            return false;
        return true;
    }

    private void Awake()
    {
        wareHouse = GetComponent<WareHouse>();
        CheckData();
    }
}
