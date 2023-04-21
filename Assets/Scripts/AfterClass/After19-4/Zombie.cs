using System;
using UnityEngine;

namespace AfterClass.After19_4
{
    public class Zombie : MonoBehaviour, IDamageable, IHealable
    {
        [SerializeField] private float m_maxHealth;
        private float m_currentHealth;

        private void Awake()
        {
            m_currentHealth = m_maxHealth;
        }

        public void TakeDamage(float p_damage)
        {
            m_currentHealth -= p_damage;
            if (m_currentHealth < 0)
            {
                m_currentHealth = 0;
            }
        }

        public void GetHeal(float p_healAmount)
        {
            TakeDamage(p_healAmount);
        }
    }
}