using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "Location")]
public class Location : ScriptableObject
{
    public string locationName;
    public Resource[] resources;
}
