using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationUiController : MonoBehaviour
{
    [SerializeField]
    public string locationName;
    public Image filledImage;
    public Image itemImage;
    public MineController mineController;

    // Start is called before the first frame update
    void Awake()
    {
       
    }

    void Start()
    {
        
    }

    public void SetProgress(float progress)
    {
        filledImage.fillAmount = progress;
    }

    private void OnEnable()
    {
        if (mineController == null)
            return;
        if (!mineController.IsMining())
            return;

    }

    public void ScrollItem(bool scrollForward, Item item)
    {
        itemImage.sprite = item.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
