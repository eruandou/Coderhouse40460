using System;
using UnityEngine;

namespace ClasesRegulares.Clase5
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float m_speed;
        [SerializeField] private float m_initialTime = 3f;
        private float m_currentTime;

        private void Awake()
        {
            m_currentTime = m_initialTime;
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
    }
}