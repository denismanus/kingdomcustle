using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MineManager : MonoBehaviour
{
    public Transform minersParent;
    private List<MineController> mineControllers;
    private List<LocationUiController> locationUiControllers;

    public void NextItem(string location)
    {
        foreach (MineController miner in mineControllers)
        {
            if (miner.GetLocation().locationName == location)
            {
                miner.NextItem();
                locationUiControllers.FirstOrDefault(x => x.locationName == location)
                    .ScrollItem(true, miner.GetItem());
                //locationUi.ScrollItem(location, true, miner.GetItem());
                break;
            }
        }
    }

    public void PreviousItem(string location)
    {
        foreach (MineController miner in mineControllers)
        {
            if (miner.GetLocation().locationName == location)
            {
                miner.PreviousItem();
                locationUiControllers.FirstOrDefault(x => x.locationName == location)
                    .ScrollItem(false, miner.GetItem());
                break;
            }
        }
    }

    public void Click(string location)
    {
        foreach (MineController miner in mineControllers)
        {
            if (miner.GetLocation().locationName == location)
            {
                miner.StartMining();
            }
        }
    }

    public void StartMining(Location location, Item instrument)
    {

    }

    public float GetMiningProgress(string location)
    {
        foreach (MineController loc in mineControllers)
        {
            if (loc.GetLocation().locationName == location)
                return loc.GetProgress();
        }
        return 0f;
    }

    private void Awake()
    {
        mineControllers = new List<MineController>();
        locationUiControllers = new List<LocationUiController>();
    }


    public void AddNewMineController(Location location)
    {
        GameObject gb = Instantiate(new GameObject(), minersParent);
        gb.AddComponent<MineController>().SetLocation(location);
        mineControllers.Add(gb.GetComponent<MineController>());
    }

    void Start()
    {
        AddNewMineController(DataKeeper.locations[0]);
    }
}
