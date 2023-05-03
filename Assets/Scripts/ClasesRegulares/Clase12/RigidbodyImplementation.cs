using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyImplementation : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rigidbody;
    [SerializeField] private Vector3 m_forceToAdd;

    [SerializeField] private float m_kickForce;

    // [SerializeField] private Transform m_forcePoint;
    [SerializeField] private float m_accelerationForce;
    [SerializeField] private float m_maxSpeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Vector3 l_forward = transform.forward;
            // Vector3 l_forceVector = l_forward * m_kickForce;

            Vector3 l_forwards = transform.forward;

            m_rigidbody.AddForce(l_forwards * m_accelerationForce, ForceMode.Force);

            if (m_rigidbody.velocity.magnitude > m_maxSpeed)
            {
                var l_velDir = m_rigidbody.velocity.normalized;
                var l_newMaxVel = l_velDir * m_maxSpeed;
                m_rigidbody.velocity = l_newMaxVel;
            }
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Vector3 l_forwards = transform.forward;

            m_rigidbody.AddForce(-l_forwards * m_accelerationForce, ForceMode.Force);

            if (m_rigidbody.velocity.magnitude > m_maxSpeed)
            {
                var l_velDir = m_rigidbody.velocity.normalized;
                var l_newMaxVel = l_velDir * m_maxSpeed;
                m_rigidbody.velocity = l_newMaxVel;
            }
        }
    }
}