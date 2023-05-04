using ClasesRegulares.Clase8;
using UnityEngine;

namespace AfterClass.After3_5
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy m_enemy1;
        [SerializeField] private Enemy m_enemy2;
        [SerializeField] private Enemy m_enemy3;
        [SerializeField] private Transform m_playerTransform;

        private void InstantiateEnemy()
        {
            Enemy l_enemy = Instantiate(m_enemy1, transform.position, Quaternion.identity);
            l_enemy.SetTarget(m_playerTransform);
        }
    }
}