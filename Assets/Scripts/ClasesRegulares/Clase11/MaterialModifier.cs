using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialModifier : MonoBehaviour
{
    [SerializeField] private Renderer m_renderer;

    [SerializeField] private Material m_material;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            m_renderer.material = m_material;
            var l_material = m_renderer.material;

            l_material.SetFloat("_AlphaClip", 0);

            m_renderer.material = l_material;
        }
    }
}