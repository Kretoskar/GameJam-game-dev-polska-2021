using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interact
{
    public class MaterialPropertyInteraction : Interaction
    {
        [SerializeField] private string properyName = "_PropertyName";
        [SerializeField] private PropertyType propertyType;
        [SerializeField] private Texture2D texture = null;
        [SerializeField] private GameObject target;
        
        private Material material = null;

        private void Awake()
        {
            if (target == null)
                material = GetComponent<Material>();
            else
                material = target.GetComponent<Material>();
        }
        
        protected override void Interact()
        {
            switch (propertyType)
            {
                case PropertyType.Texture2D:
                    material.SetTexture(properyName, texture);
                    break;
            }
        }
        
        private enum PropertyType
        {
            Texture2D
        }
    }
}