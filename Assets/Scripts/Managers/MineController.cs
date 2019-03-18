using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MineController : MonoBehaviour
{

    public delegate void MethodContainer(string message);
    public static event MethodContainer OnAction;


    private float progress;
    private bool isMining = false;

    private Location location;
    private Item item;
    private Item.Specializations specialization;
    private Coroutine currentCoroutine;
    private WareHouse wareHouse;
    private LocationUiController uiController;
    private List<Resource> availableToMineResources;

    public void NextItem()
    {
        var items = wareHouse.GetItems(specialization).Where(x => x.type.Equals(Item.Types.Human) || x.type.Equals(Item.Types.Instrument)).ToList();
        if (items.Count == 0)
            return;
        var currentItemPosition = items.IndexOf(item);
        if (currentItemPosition == items.Count - 1)
        {
            item = items.ElementAt(0);
        }
        else
        {
            item = items.ElementAt(currentItemPosition + 1);
        }
        SetAvailableResources();
    }

    public void PreviousItem()
    {
        var items = wareHouse.GetItems(specialization).Where(x => x.type.Equals(Item.Types.Human) || x.type.Equals(Item.Types.Instrument)).ToList();
        if (items.Count == 0)
            return;
        var currentItemPosition = items.IndexOf(item);
        if (currentItemPosition == 0)
        {
            item = items.ElementAt(items.Count - 1);
        }
        else
        {
            item = items.ElementAt(currentItemPosition - 1);
        }
        SetAvailableResources();
    }

    public void SetLocation(Location location)
    {
        this.location = location;
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }

    public Item GetItem()
    {
        return item;
    }

    public bool IsMining()
    {
        return isMining;
    }

    public void StartMining()
    {
        if (isMining)
            return;
        currentCoroutine = StartCoroutine(Mine());
    }

    public float GetProgress()
    {
        return progress;
    }



    public Location GetLocation()
    {
        return location;
    }

    private void GetResource()
    {
        if (availableToMineResources.Count == 0)
            return;
        int i = Random.Range(0, availableToMineResources.Count);
        wareHouse.AddResource(availableToMineResources[i], 1);
        OnAction("ResourceAdded");
    }

    public void SetAvailableResources()
    {
        availableToMineResources.Clear();
        if (item != null)
        {
            availableToMineResources = location.resources.Intersect(item.resourcesToMine).ToList();
        }
        else
        {
            availableToMineResources = location.resources.Intersect(DataKeeper.hand.resourcesToMine).ToList();
        }
    }

    private IEnumerator Mine()
    {
        isMining = true;
        while (progress < 1f)
        {
            progress += Time.deltaTime;
            uiController.SetProgress(progress);
            yield return new WaitForEndOfFrame();
        }

        progress = 0f;
        GetResource();
        isMining = false;
    }

    private void Awake()
    {
        wareHouse = FindObjectOfType<WareHouse>();
        availableToMineResources = new List<Resource>();
    }

    private void Start()
    {
        Debug.Log(1);
        SetAvailableResources();
        foreach (LocationUiController uiController in FindObjectsOfType<LocationUiController>())
        {
            Debug.Log(uiController.locationName);
            if (location.locationName == uiController.locationName)
            {
                uiController.mineController = this;
                this.uiController = uiController;
                break;
            }
        }
    }
}
