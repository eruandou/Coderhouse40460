using System;
using System.Collections;
using System.Collections.Generic;
using AfterClass.After19_4;
using UnityEngine;

public class HealthArea : MonoBehaviour
{
    [SerializeField] private float m_healPerSecond;


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out IHealable l_healable))
        {
            l_healable.GetHeal(m_healPerSecond * Time.fixedDeltaTime);
        }
    }
}