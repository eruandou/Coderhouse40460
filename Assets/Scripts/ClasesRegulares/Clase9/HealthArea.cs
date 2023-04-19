using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthArea : MonoBehaviour
{
    [SerializeField] private float m_healPerSecond;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Es un jugador");
            var l_player = other.GetComponent<PlayerController>();
            if (l_player != null)
            {
                l_player.GetHeal(m_healPerSecond * Time.fixedDeltaTime);
            }
        }
    }
}