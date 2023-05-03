using System;
using AfterClass.After19_4;
using UnityEngine;

namespace ClasesRegulares.Clase5
{
    public class Bullet : MonoBehaviour, IDamageable
    {
        [SerializeField] private float m_speed;
        [SerializeField] private float m_initialTime = 3f;
        private float m_currentTime;
        private GameManager m_gameManager;
        public float MaxHealth => 0;

        private void Awake()
        {
            m_currentTime = m_initialTime;
        }

        public void Init(GameManager p_gameManager)
        {
            m_gameManager = p_gameManager;
        }

        private void Update()
        {
            m_currentTime -= Time.deltaTime;

            if (m_currentTime <= 0)
            {
                Destroy(gameObject);
            }


            transform.position += m_speed * Time.deltaTime * transform.forward;
        }

        public void TakeDamage(float p_damage)
        {
            Destroy(gameObject);
        }
    }
}