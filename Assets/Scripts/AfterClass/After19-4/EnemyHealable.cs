using System;
using System.Collections;
using System.Collections.Generic;
using AfterClass.After19_4;
using UnityEngine;

public class EnemyHealable : MonoBehaviour, IDamageable, IHealable
{
    [SerializeField] private float m_maxHealth;
    private float m_currentHealth;
    public float MaxHealth => m_maxHealth;
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
        m_currentHealth += p_healAmount;
        if (m_currentHealth > m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }
    }
}