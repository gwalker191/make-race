using UnityEngine;

[CreateAssetMenu(menuName = "MakeRace/CarTemplate")]
public class CarTemplate : ScriptableObject
{
    public string carName = "Car";
    public float baseSpeed = 5f;
    public float handling = 5f;
    public float durability = 10f;
    public int cost = 0;
}
