using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObjects/AnimalScriptableObject", order = 1)]
public class Animal : ScriptableObject
{
    public new string name;
    public GameObject prefab;
}