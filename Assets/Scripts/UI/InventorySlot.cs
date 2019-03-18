using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image image;
    private Resource resource;
    private Item item;
    private Text count;
    private WareHouse wareHouse;

    public int GetSortId()
    {
        if (resource != null)
            return resource.sortId;
        return (((int)item.type + 1) * 50) + item.sortId;
    }
    public void Clear()
    {
        resource = null;
        item = null;
    }
    public Resource GetResource()
    {
        return resource;
    }

    public Sprite GetSprite()
    {
        return image.sprite;
    }
    public Item GetItem()
    {
        return item;
    }

    public bool isUsed()
    {
        if (resource != null)
            return true;
        if (item != null)
            return true;
        return false;
    }

    public void LoadComponents()
    {
        image = GetComponentInChildren<Image>();
        count = GetComponentInChildren<Text>();
    }

    public void SetCount(int count)
    {
        this.count.text = count.ToString();
    }

    public void SetItem(Item item)
    {
        if (item == null)
            return;
        this.item = item;
        image.sprite = item.sprite;
        image.color = new Color(1f, 1f, 1f, 1f);
    }

    public void SetWarehouse(WareHouse wareHouse)
    {
        this.wareHouse = wareHouse;
    }


    public void SetResource(Resource resource)
    {
        if (resource == null)
            return;
        this.resource = resource;
        image.sprite = resource.sprite;
        image.color = new Color(1f, 1f, 1f, 1f);
    }

    public int GetCount()
    {
        return int.Parse(count.text);
    }


    public void Click()
    {
        if (item != null)
            wareHouse.TryToCraft(item);
    }

    private void Awake()
    {
        LoadComponents();
    }
}
