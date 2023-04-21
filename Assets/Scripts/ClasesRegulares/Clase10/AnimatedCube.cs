using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCube : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private float m_speed = 30;
    private bool m_isActivated;

    private bool m_trigger;

    public bool GetTrigger()
    {
        var l_valueToReturn = m_trigger;
        if (m_trigger)
        {
            m_trigger = false;
        }

        return l_valueToReturn;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            m_isActivated = !m_isActivated;
            m_animator.SetBool("CubeActivated", m_isActivated);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            m_animator.SetTrigger("Resize");
        }

        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");

        var l_movementDir = new Vector3(l_horizontal, 0, l_vertical);

        l_movementDir.Normalize();
        var l_movementFullSpeed = (int)(l_movementDir.magnitude * m_speed);
        m_animator.SetInteger("FullSpeed", l_movementFullSpeed);
    }
}