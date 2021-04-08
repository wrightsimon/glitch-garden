using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    //Config parameters
    [SerializeField] int cost = 100;


    public int GetCost()
    {
        return cost;
    }

    public void AddResource(int amount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(amount);
    }
}
