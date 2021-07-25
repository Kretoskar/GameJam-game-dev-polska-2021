using System.Collections;
using System.Collections.Generic;
using Game.Rendering;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    private Outline selection;
    private Camera mainCam;

    private Vector3 offset;
    private Vector3 hitPosition;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        var ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Draggable"))
        {
            if (selection == null)
            {
                selection = hit.transform.GetComponent<Outline>();
                selection.DrawOutline();
                selection.GetComponent<Rigidbody>().isKinematic = true;
                hitPosition = hit.transform.position;

            }
        }
        else if(selection != null)
        {
            selection.HideOutline();
            selection.GetComponent<Rigidbody>().isKinematic = false;
            selection.transform.parent = null;
            selection = null;
        }

        if (selection != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                selection.transform.parent = mainCam.transform;
                offset = selection.transform.position - hitPosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                selection.transform.parent = null;
                selection.GetComponent<Rigidbody>().isKinematic = false;
                selection.transform.parent = null;
            }

            if (Input.GetMouseButton(0))
            {
               // selection.transform.position = transform.position + mainCam.transform.forward;
            }
        }
    }
}
