using System;
using AfterClass.After19_4;
using UnityEngine;

namespace ClasesRegulares.Clase9
{
    public class DamageArea : MonoBehaviour
    {
        [SerializeField] private float m_damagePerSecond;

        private void OnTriggerStay(Collider other)
        {
            // if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController l_player))
            // {
            //     l_player.TakeDamage(m_damagePerSecond * Time.fixedDeltaTime);
            // }

            if (other.TryGetComponent(out IDamageable l_damageable))
            {
                l_damageable.TakeDamage(m_damagePerSecond * Time.fixedDeltaTime);
            }
        }
    }
}