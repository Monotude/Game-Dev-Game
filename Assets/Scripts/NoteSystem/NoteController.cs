using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
//using UnityStandardAssets.Chracters.FirstPerson;

public class NoteController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private KeyCode closeKey;

    //[Space(10)]
    [SerializeField] private GameObject player;

    [Header("UI TEXT")]
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private TMP_Text noteTextAreaUI;

    [Space(10)]
    [SerializeField] [TextArea] private string noteText;

    [Space(10)]
    [SerializeField] private UnityEvent openEvent;
    private bool isOpen = false;


  
    
    
    void Update()
    {
        if (isOpen)
        {
            
            if (Input.GetKeyDown(closeKey))
            {
                DisableNote();
            }
        }
    }

    public void ShowNote()
    {
        noteTextAreaUI.text = noteText;
        noteCanvas.SetActive(true);
        //openEvent.Invoke();
        DisablePlayer(true);
        isOpen = true;
    }

    void DisableNote()
    {
        noteCanvas.SetActive(false);
        
        DisablePlayer(false); //enables player
        isOpen = false;
    }

    void DisablePlayer (bool disable)
    {
        player.SetActive(!disable);
        //player.enabled = !disable;
    }
}
