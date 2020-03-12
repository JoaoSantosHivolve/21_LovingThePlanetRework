using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class AnimalsManager : Singleton<AnimalsManager>
{
    public List<Animal> animals;


    public Animal GetAnimalByName(string name)
    {
        foreach (var animal in animals)
        {
            if (animal.name == name)
                return animal;
        }

        return null;
    }
}


