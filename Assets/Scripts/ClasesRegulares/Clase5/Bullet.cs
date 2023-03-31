using System;
using UnityEngine;

namespace ClasesRegulares.Clase5
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float m_speed;


        private void Update()
        {
            transform.position += m_speed * Time.deltaTime * transform.forward;
        }
    }
}