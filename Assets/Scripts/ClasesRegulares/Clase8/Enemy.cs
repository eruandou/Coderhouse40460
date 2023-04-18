using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace ClasesRegulares.Clase8
{
    public enum EnemyTypes
    {
        Weak = 56,
        WeakMiddle = 129,
        Middle = 901923,
        MiddleStrong,
        Strong,
        SuperStrong,
        MiniBoss,
        Boss
    }

    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform m_target;
        [SerializeField] private float m_movementSpeed;
        [SerializeField] private float m_distanceToChase = 10f;
        [SerializeField] private int difficulty;
        [SerializeField] private EnemyTypes m_enemyType;
        [SerializeField] private float baseHealth;
        [SerializeField] private float m_baseDamage;
        [SerializeField] private float m_turningSpeed;
        private float m_currentHealth;

        private void Awake()
        {
            // Debug.Log($"El enemigo tiene una dificultad de {difficulty}");
            //
            // SetDamageMultiplier(m_enemyType);
            // Debug.Log($"El daño total de este enemigo es {m_baseDamage}");
        }

        private void Update()
        {
            Chase();
        }

        private void Chase()
        {
            var l_diffVector = m_target.position - transform.position;

            Debug.Log(l_diffVector);
            if (m_distanceToChase > l_diffVector.magnitude)
            {
                //Metodo 1
                // transform.LookAt(m_target);

                //Metodo 2
                // Quaternion l_newRotation = Quaternion.LookRotation(l_diffVector.normalized);
                // transform.rotation = l_newRotation;

                //Con suavizado Lerp
                Quaternion l_newRotation = Quaternion.LookRotation(l_diffVector.normalized);
                // transform.rotation =
                // Quaternion.Lerp(transform.rotation, l_newRotation, Time.deltaTime * m_turningSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, l_newRotation, m_turningSpeed);
                Debug.Log("I'm chasing the player");
                Move(l_diffVector.normalized);
            }
        }

        private void Move(Vector3 p_direction)
        {
            transform.position += p_direction * (m_movementSpeed * Time.deltaTime);
        }

        private void SetDamageMultiplier(EnemyTypes p_enemyType)
        {
            switch (p_enemyType)
            {
                case EnemyTypes.Weak:
                    break;
                case EnemyTypes.WeakMiddle:
                    m_baseDamage *= 1.2f;
                    break;
                case EnemyTypes.Middle:
                    m_baseDamage *= 1.5f;
                    break;
                case EnemyTypes.Strong:
                    m_baseDamage *= 2f;
                    break;
                case EnemyTypes.MiniBoss:
                    m_baseDamage *= 5f;
                    break;
                case EnemyTypes.Boss:
                    m_baseDamage *= 10f;
                    break;
            }
        }


        private float GetDamageMultiplier(EnemyTypes p_enemyType)
        {
            switch (p_enemyType)
            {
                case EnemyTypes.Weak:
                    return 0;
                case EnemyTypes.WeakMiddle:
                    return 0;
                case EnemyTypes.Middle:
                    return 0;
                case EnemyTypes.MiddleStrong:
                    return 0;
                case EnemyTypes.Strong:
                    return 0;
                case EnemyTypes.SuperStrong:
                    return 0;
                case EnemyTypes.MiniBoss:
                    return 0;
                case EnemyTypes.Boss:
                    return 0;
            }

            return 0;
        }
    }
}