using System;
using UnityEngine;

namespace ClasesRegulares.Clase5
{
    public class BulletShooterComponent : MonoBehaviour
    {
        [SerializeField] private Bullet m_bulletToShoot;
        [SerializeField] private Transform m_shootingPoint;
        [SerializeField] private Transform m_bulletParent;


        private void Start()
        {
            Shoot();
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            //Paso 1: Instanciar una nueva bala
            Instantiate(m_bulletToShoot, m_shootingPoint.position, Quaternion.identity, m_bulletParent);
        }
    }
}