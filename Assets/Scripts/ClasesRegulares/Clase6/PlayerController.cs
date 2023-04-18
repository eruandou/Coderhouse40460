using System;
using ClasesRegulares.Clase5;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_playerHealth;
    [SerializeField] private string m_playerName;
    [SerializeField] private bool m_canShout;
    [SerializeField] private Bullet m_bullet;
    [SerializeField] private float m_timeToShoot = 1f;
    private float m_currentTimeToShoot;

    private void Awake()
    {
        if (!IsValidName(m_playerName))
        {
            Debug.LogWarning("The player doesn't have a valid name");
        }
    }

    private bool IsValidName(string p_name)
    {
        var l_isNullOrWhiteSpace = string.IsNullOrWhiteSpace(p_name);
        return !l_isNullOrWhiteSpace;
    }


    private void Move(Vector3 p_direction)
    {
        transform.position += p_direction * (m_speed * Time.deltaTime);
    }

    private void TakeDamage(float p_damage)
    {
        m_playerHealth -= p_damage;
    }

    private void Shoot()
    {
        var l_bullet = Instantiate(m_bullet, transform.position, Quaternion.identity);
        m_currentTimeToShoot = m_timeToShoot;
    }

    private void Update()
    {
        //Cuando el jugador presiona la tecla K, recibe 1 de daño

        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");

        var l_direction = new Vector3(l_horizontal, 0, l_vertical);

        Move(l_direction);

        m_currentTimeToShoot -= Time.deltaTime;

        if (Input.GetButton("Disparo") && m_currentTimeToShoot <= 0)
        {
            Shoot();
        }


        bool l_isAlive = m_playerHealth > 0;

        if ((l_isAlive || m_canShout) && IsValidName(m_playerName))
        {
            // Debug.Log("There's living activity");
            // Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }

        else
        {
            // Debug.Log("The character has died");
        }

        // Debug.Log("This is the player controller");
    }
}