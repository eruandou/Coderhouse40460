using System;
using System.Collections;
using UnityEngine;

namespace AfterClass.Afterclass12_4
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float m_maxHealth = 10f;
        [SerializeField] private float m_invincibilityTime = 3f;
        [SerializeField] private float m_ability1Cooldown = 5f;
        [SerializeField] private float m_ability2Cooldown = 5f;
        [SerializeField] private float m_ability3Cooldown = 3f;
        [SerializeField] private float m_ability4Cooldown = 3f;
        private float m_currentAbility1Cooldown;
        private float m_currentInvinbilityTime;
        private float m_currentHealth;
        private bool m_isInvincible;
        private bool m_isAbilityAvailable = true;
        private Coroutine m_currentAbility;

        private void Awake()
        {
            m_currentHealth = m_maxHealth;
        }

        public void GetDamage(float p_damage)
        {
            if (m_currentInvinbilityTime < Time.time)
            {
                m_currentHealth -= p_damage;

                if (m_currentHealth < 0)
                {
                    m_currentHealth = 0;
                }

                m_currentInvinbilityTime = Time.time + m_invincibilityTime;
            }
        }

        //Opcion 2
        public void UseSkill1()
        {
            if (m_currentAbility1Cooldown < Time.time)
            {
                //Uso la habilidad

                m_currentAbility1Cooldown = Time.time + m_ability1Cooldown;
            }
        }

        // private void UseSkill2()
        // {
        //     if (m_isAbilityAvailable)
        //     {
        //         m_isAbilityAvailable = false;
        //
        //         //Uso la habilidad
        //         //Espero m_ability2Cooldown segundos
        //         m_isAbilityAvailable = true;
        //     }
        // }

        private IEnumerator UseSkill2()
        {
            if (m_isAbilityAvailable)
            {
                var l_currentCooldown = m_ability2Cooldown;
                Debug.Log("Se ejecuta la corrutina");
                m_isAbilityAvailable = false;

                //Uso la habilidad
                Skill2();
                //Espero m_ability2Cooldown segundos

                while (l_currentCooldown > 0)
                {
                    l_currentCooldown -= Time.deltaTime;
                    //Correr la logica de actualizar mi barrita en la UI 
                    yield return new WaitForEndOfFrame();
                }

                // yield return new WaitForSeconds(m_ability2Cooldown);
                m_isAbilityAvailable = true;
                Debug.Log("Finaliza la corrutina");
            }
        }

        private IEnumerator GenericAbilityCoroutine(float p_waitTime, Action p_onStart /*, Action p_onFinish*/)
        {
            p_onStart();
            yield return new WaitForSeconds(p_waitTime);
            m_currentAbility = null;
            // p_onFinish();
        }

        private void Skill2()
        {
            Debug.Log("Ejecuto el skill 2");
        }

        private void EnableSkill2()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetDamage(1);
            }

            if (Input.GetKeyDown(KeyCode.P) && m_currentAbility == null)
            {
                m_currentAbility = StartCoroutine(GenericAbilityCoroutine(m_ability2Cooldown, Skill2));
            }

            if (Input.GetKeyDown(KeyCode.N) && m_currentAbility == null)
            {
                m_currentAbility = StartCoroutine(GenericAbilityCoroutine(m_ability3Cooldown, Skill3));
            }

            if (Input.GetKeyDown(KeyCode.L) && m_currentAbility == null)
            {
                m_currentAbility = StartCoroutine(GenericAbilityCoroutine(m_ability4Cooldown, Skill4));
            }

            //Opcion 1
            /*
            if (m_currentInvinbilityTime > 0)
            {
                m_currentInvinbilityTime -= Time.deltaTime;
            }*/
        }


        private void Skill4()
        {
            Debug.Log("Skill 4");
        }

        private void OnSkill3Finish()
        {
            Debug.Log("Finish skill 3");
        }

        private void Skill3()
        {
            Debug.Log("Skill 3");
        }
    }
}