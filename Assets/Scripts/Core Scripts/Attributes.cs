using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes
{
    [SerializeField]
    private float baseValue;
    [SerializeField]
    private float currentValue;
    
    public float CurrentValue { get { return currentValue;} }
    public float Percent { get { return currentValue / baseValue;} }

    public Attributes()
    {
        currentValue = baseValue = 1f;
    }

    public Attributes(float newValue)
    {
        currentValue = baseValue = newValue;
    }

    public void SetNewValue(float newValue)
    {
        currentValue = baseValue = newValue;
    }

    public float AddToAttribute(float valueToAdd)
    {
        currentValue += valueToAdd;
        currentValue = Mathf.Clamp(currentValue, 0, baseValue);
        return currentValue;
    }
    public float SubstractToAttrtibute(float valueToSub)
    {
        currentValue -= valueToSub;
        currentValue = Mathf.Clamp(currentValue, 0, baseValue);
        return currentValue;
    }
}
