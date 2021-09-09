using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Rendering
{
    public class Outline : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private Vector3 meshScale = Vector3.one;
        [SerializeField] private Material outlineMaterial = null;
        [SerializeField] private float outlineScale = 1;
        [SerializeField] private Color outlineColor = Color.red;

        private Renderer outlineRenderer = null;
        private bool instanced = false;
        
        private void Start()
        {
        }

        public void DrawOutline()
        {
            if (!instanced)
            {
                outlineRenderer = CreateOutline(outlineMaterial, outlineScale, outlineColor);
            }

            outlineRenderer.enabled = true;
        }

        public void HideOutline()
        {
            if(outlineRenderer == null) return;
            
            outlineRenderer.enabled = false;
        }

        private Renderer CreateOutline(Material outlineMaterial, float scaleFactor, Color color)
        {
            GameObject outlineObject = Instantiate(gameObject, transform.position + offset, transform.rotation, transform);
            outlineObject.transform.localScale = meshScale;
            Renderer renderer = outlineObject.GetComponent<Renderer>();

            renderer.material = outlineMaterial;
            renderer.material.SetColor("_Color", outlineColor);
            renderer.material.SetFloat("_Scale", outlineScale);
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            outlineObject.GetComponent<Outline>().enabled = false;
            outlineObject.GetComponent<Collider>().enabled = false;
            outlineObject.GetComponent<Rigidbody>().isKinematic = true;

            renderer.enabled = false;

            instanced = true;
            
            return renderer;
        }
    }
}