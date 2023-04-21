using UnityEngine;

namespace AfterClass.After19_4
{
    public class DestroyableObject : MonoBehaviour, IDamageable
    {
        [SerializeField] private float m_maxHealth;
        public float MaxHealth => m_maxHealth;
        public void TakeDamage(float p_damage)
        {
            m_maxHealth -= p_damage;

            if (m_maxHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}