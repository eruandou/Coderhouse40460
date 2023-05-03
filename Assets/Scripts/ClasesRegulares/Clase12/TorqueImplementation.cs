using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ClasesRegulares.Clase12
{
    public class TorqueImplementation : MonoBehaviour
    {
        [SerializeField] private Rigidbody m_rigidbody;
        [SerializeField] private float m_torqueIntensity;
        [SerializeField] private Vector3 m_torqueDir;

        [SerializeField] private Vector3 m_gravity;
        private void Update()
        {
            if (Input.GetKey(KeyCode.J))
            {
                m_rigidbody.AddTorque(m_torqueDir * (m_torqueIntensity * Time.deltaTime));
                m_rigidbody.AddForce(m_gravity, ForceMode.Acceleration);
            }
        }
    }
}