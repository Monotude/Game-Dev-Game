using System;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public Action<float, Vector3> MakeSoundEvent;

    public void MakeSound(float soundLoudness, Vector3 position)
    {
        Debug.Log("" + soundLoudness + " " + position);
    }

    private void Awake()
    {
        MakeSoundEvent += MakeSound;
    }
}
