using UnityEngine;


[CreateAssetMenu(fileName = "Resource", menuName = "Resource")]

public class Resource : ScriptableObject
{
    public Sprite sprite;
    public string resourceName;
    public int sortId;
    public Item.Specializations specialization;
}
