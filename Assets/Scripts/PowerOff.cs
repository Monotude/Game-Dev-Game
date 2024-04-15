using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOff : MonoBehaviour
{
    void turnOffLights(int doorStatus)
    {
        if(doorStatus == 1) {
            RenderSettings.ambientLight = new Color32(0, 0, 0, 0);
        }
    }
}
