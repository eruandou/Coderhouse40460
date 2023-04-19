using System;
using UnityEngine;

namespace ClasesRegulares.Clase9
{
    public class DamageArea : MonoBehaviour
    {
        [SerializeField] private float m_damagePerSecond;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController l_player))
            {
                l_player.TakeDamage(m_damagePerSecond * Time.fixedDeltaTime);
            }
        }
    }
}