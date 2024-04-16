using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Progress
{
    private Queue<int> fuseCollected;
    [SerializeField] private bool[] isFuseCollected;
    [SerializeField] private bool[] isFuseBoxPowered;
    [SerializeField] private bool[] isElectricalBoxOn;
    [SerializeField] private bool isSection2Started;
    [SerializeField] private bool isSection2Cleared;
    [SerializeField] private bool isLoreRoomOpen;

    public Progress(int fuseCount)
    {
        fuseCollected = new Queue<int>();
        isFuseCollected = new bool[fuseCount];
        isFuseBoxPowered = new bool[fuseCount];
        isElectricalBoxOn = new bool[fuseCount];
        isSection2Started = false;
        isSection2Cleared = false;
        isLoreRoomOpen = false;
    }

    public int GetFuseCount()
    {
        if (fuseCollected == null)
        {
            fuseCollected = new Queue<int>();
            return 0;
        }

        return fuseCollected.Count;
    }

    public bool IsFuseCollected(int fuseNumber)
    {
        return isFuseCollected[fuseNumber - 1];
    }

    public void CollectFuse(int fuseNumber)
    {
        if (fuseCollected == null)
        {
            fuseCollected = new Queue<int>();
        }

        fuseCollected.Enqueue(fuseNumber);
    }

    public bool IsFuseBoxPowered(int fuseBoxNumber)
    {
        return isFuseBoxPowered[fuseBoxNumber - 1];
    }

    public bool PowerFuseBox(int fuseBoxNumber)
    {
        if (!isFuseBoxPowered[fuseBoxNumber - 1] && GetFuseCount() > 0)
        {
            isFuseCollected[fuseCollected.Dequeue() - 1] = true;
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

    public bool GetIsSection2Started()
    {
        return isSection2Started;
    }

    public void StartSection2()
    {
        isSection2Started = true;
    }

    public bool GetIsSection2Cleared()
    {
        return isSection2Cleared;
    }

    public void ClearSection2()
    {
        isSection2Cleared = true;
    }

    public bool GetIsLoreRoomOpen()
    {
        return isLoreRoomOpen;
    }

    public void OpenLoreRoom()
    {
        isLoreRoomOpen = true;
    }
}
