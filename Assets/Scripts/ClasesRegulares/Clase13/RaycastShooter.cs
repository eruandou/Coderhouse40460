using System;
using ClasesRegulares.Clase8;
using UnityEngine;

namespace ClasesRegulares.Clase13
{
    public class RaycastShooter : MonoBehaviour
    {
        [SerializeField] private Transform m_raycastPoint;
        [SerializeField] private float m_maxDistance;
        [SerializeField] private LayerMask m_raycastLayers;
        [SerializeField] private float m_shootingForce;
        [SerializeField] private float m_sphereCastRadius;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DoRaycast();
            }

        }

        private void DoRaycast()
        {
            // bool l_isHitting = Physics.Raycast(m_raycastPoint.position, m_raycastPoint.forward, out RaycastHit l_hit,
            //     m_maxDistance,
            //     m_raycastLayers);
            bool l_isHitting = Physics.SphereCast(m_raycastPoint.position, m_sphereCastRadius, m_raycastPoint.forward,
                out RaycastHit l_hit, m_maxDistance, m_raycastLayers);

            if (l_isHitting && l_hit.rigidbody != null)
            {
                l_hit.rigidbody.AddForceAtPosition(transform.forward * m_shootingForce, l_hit.point, ForceMode.Impulse);
            }
            
            
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(m_raycastPoint.position, m_raycastPoint.position + m_raycastPoint.forward * m_maxDistance);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(m_raycastPoint.position, m_sphereCastRadius);
        }
    }
}