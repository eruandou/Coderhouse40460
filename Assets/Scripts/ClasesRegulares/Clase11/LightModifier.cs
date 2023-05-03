using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightModifier : MonoBehaviour
{
    [SerializeField] private Light myLight;

    [SerializeField] private float m_intensity;
    [SerializeField] private Color m_lightColor;

    private void Update()
    {
        myLight.intensity = m_intensity;

        myLight.color = m_lightColor;
    }
}