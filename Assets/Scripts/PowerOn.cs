using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    private bool isBoxOneOn, isBoxTwoOn, isBoxThreeOn, isBoxFourOn;
    private bool isPowerOn;
    private bool isFuseOneOn, isFuseTwoOn, isFuseThreeOn, isFuseFourOn;
    [SerializeField] private GameObject lightingControl;

    // Start is called before the first frame update
    void Start()
    {
        isBoxOneOn = false;
        isBoxTwoOn = false;
        isBoxThreeOn = false;
        isBoxFourOn = false;
        isPowerOn = false;
        isFuseOneOn = false;
        isFuseTwoOn = false;
        isFuseThreeOn = false;
        isFuseFourOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBoxOneOn && isBoxTwoOn && isBoxThreeOn && isBoxFourOn) {
            isPowerOn = true;
        }
        else {
            isPowerOn = false;
        }

        lightingControl.SetActive(isPowerOn);
    }

    public void UpdateBoxOne()
    {
        isBoxOneOn = true;
    }

    public void UpdateBoxTwo()
    {
        isBoxTwoOn = true;
    }

    public void UpdateBoxThree()
    {
        isBoxThreeOn = true;
    }

    public void UpdateBoxFour()
    {
        isBoxFourOn = true;
    }

    public void UpdateFuses(int boxNumber)
    {
        switch (boxNumber) {
            case 1:
                isFuseOneOn = true;
                break;
            case 2:
                isFuseTwoOn = true;
                break;
            case 3:
                isFuseThreeOn = true;
                break;
            case 4:
                isFuseFourOn = true;
                break;

        }
    }

    public bool getFuseOn(int boxNumber) {
        switch (boxNumber) {
            case 1:
                return isFuseOneOn;
                break;
            case 2:
                return isFuseTwoOn;
                break;
            case 3:
                return isFuseThreeOn;
                break;
            case 4:
                return isFuseFourOn;
                break;

        }
        return false;
    }

    

}
