using System;
using UnityEngine;

[Serializable]
public class Progress
{
    [SerializeField] private int fuseCollectedCount;
    [SerializeField] private bool[] isFuseCollected;
    [SerializeField] private bool[] isFuseBoxPowered;
    [SerializeField] private bool[] isElectricalBoxOn;

    public Progress(int fuseCount)
    {
        isFuseCollected = new bool[fuseCount];
        isFuseBoxPowered = new bool[fuseCount];
        isElectricalBoxOn = new bool[fuseCount];
    }

    public bool IsFuseCollected(int fuseNumber)
    {
        return isFuseCollected[fuseNumber - 1];
    }

    public void CollectFuse(int fuseNumber)
    {
        ++fuseCollectedCount;
        isFuseCollected[fuseNumber - 1] = true;
    }

    public bool IsFuseBoxPowered(int fuseBoxNumber)
    {
        return isFuseBoxPowered[fuseBoxNumber - 1];
    }

    public bool PowerFuseBox(int fuseBoxNumber)
    {
        if (!isFuseBoxPowered[fuseBoxNumber - 1] && fuseCollectedCount > 0)
        {
            --fuseCollectedCount;
            isFuseBoxPowered[fuseBoxNumber - 1] = true;
            return true;
        }

        return false;
    }

    public bool IsElectricalBoxOn(int electricalBoxNumber)
    {
        return isElectricalBoxOn[electricalBoxNumber - 1];
    }

    public bool TurnElectricalBoxOn(int electricalBoxNumber)
    {
        if (!isElectricalBoxOn[electricalBoxNumber - 1] && isFuseBoxPowered[electricalBoxNumber - 1])
        {
            isElectricalBoxOn[electricalBoxNumber - 1] = true;
            return true;
        }

        return false;
    }
}
