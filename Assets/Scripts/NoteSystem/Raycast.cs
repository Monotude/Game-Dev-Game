using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{

    [SerializeField] private float rayLength = 5;
    private Camera camera;

    private NoteController noteController;
    [SerializeField] private Image crosshair;
    [SerializeField] private KeyCode interactkey;




    void Start()
    {
        camera = GetComponent<Camera>();
    }

  
    void Update()
    {
        if (Physics.Raycast(camera.ViewportToWorldPoint(new Vector3(.5f, 0.5f )), transform.forward, out RaycastHit hit, rayLength))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            if (readableItem != null)
            {
                noteController = readableItem;

                HighlightCrosshair(true);
            }
            else
            {
                ClearNote();
            }
        }
        else
        {
            ClearNote();
        }

        if(noteController != null)
        {
            if(Input.GetKeyDown(interactkey))
            {
                noteController.ShowNote();
            }
        }
    }

    void ClearNote()
    {
        if (noteController != null)
        {
            HighlightCrosshair(false);
            noteController = null;
            noteController = null;
        }
    }

    void HighlightCrosshair (bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }
}
