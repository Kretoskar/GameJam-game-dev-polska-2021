using System.Collections;
using System.Collections.Generic;
using Game.Rendering;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    [SerializeField] private float throwForce = 10;
    [SerializeField] private float minDistance = 5;
    
    //TA KLASA TO GOWNO STRASZNE ALE NA SZYBKO PISANE SORRY
    
    private Outline selection;
    private Camera mainCam;
    private bool dragging;

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

        if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Draggable") && Vector3.Distance(hit.transform.position, transform.position) < minDistance)
        {
            hitPosition = hit.transform.position;
            if (selection == null)
            {
                selection = hit.transform.GetComponent<Outline>();
                selection.DrawOutline();
                //selection.GetComponent<Rigidbody>().isKinematic = true;
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
                selection.GetComponent<Rigidbody>().isKinematic = true;
                selection.transform.parent = mainCam.transform;
                offset = selection.transform.position - hitPosition;
                dragging = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                selection.GetComponent<Rigidbody>().isKinematic = false;
                selection.GetComponent<Rigidbody>().AddForce(selection.transform.parent.transform.forward * throwForce);
                selection.transform.parent = null;
                dragging = false;
            }

            if (dragging)
                selection.transform.position = hitPosition - offset;

        }
    }
}
