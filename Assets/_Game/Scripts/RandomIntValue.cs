using UnityEngine;
using System;

[Serializable]
public class RandomIntValue
{
    public int Min;
    public int Max;
    public int RandomInt
    {
        get
        {
            return (UnityEngine.Random.Range(Min, Max));
        }
    }
}
