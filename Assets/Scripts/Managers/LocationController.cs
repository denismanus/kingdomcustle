using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LocationController : MonoBehaviour
{
    //public Location currentLocation;
    //public Item currentItem;

    //private bool isPaused;
    //private bool isMining = false;
    //private float progress = 0f;
    //private Item.Specializations specialization;

    //public void NextItem()
    //{
    //    var items  = wareHouse.GetItems(specialization).Where(x=>x.type.Equals(Item.Types.Human)|| x.type.Equals(Item.Types.Instrument)).ToList();
    //    var currentItemPosition = items.IndexOf(currentItem);
    //    if (currentItemPosition == items.Count - 1)
    //    {
    //        currentItem = items.ElementAt(0);
    //    }
    //    else
    //    {
    //        currentItem = items.ElementAt(currentItemPosition + 1);
    //    }
    //    SetAvailableResources();
    //}

    //public void PreviousInstrument()
    //{
    //    SetAvailableResources();
    //}


    //public void Click()
    //{
    //    if (isMining)
    //        return;
    //    StartCoroutine(Mine());
    //    //if (currentItem.type.Equals(Item.Types.Human))
    //    //{
    //    //    isPaused = !isPaused;
    //    //    return;
    //    //}
    //    //if (currentItem.type.Equals(Item.Types.Instrument))
    //    //{

    //    //}
    //}

    //IEnumerator Mine()
    //{
    //    isMining = true;
    //    while (progress < timeToMine)
    //    {
    //        progress += Time.deltaTime;
    //        yield return new WaitForEndOfFrame();
    //    }
    //    progress = 0f;
    //    GetResource();
    //    isMining = false;
    //}

    //void GetResource()
    //{
    //    int i = Random.Range(0, availableToMineResources.Count);
    //    wareHouse.AddResource(availableToMineResources[i], 1);
    //}

    //public void SetAvailableResources()
    //{
    //    availableToMineResources.Clear();
    //    if (currentItem != null)
    //    {
    //        availableToMineResources = currentLocation.resources.Intersect(currentItem.resourcesToMine).ToList();
    //    }
    //    else
    //    {
    //        //availableToMineResources = currentLocation.resources[];
    //    }
    //}

    private void Start()
    {

    }



    //private void Awake()
    ////{
    ////    availableToMineResources = new List<Resource>();
    ////    SetAvailableResources();
    //}
}
