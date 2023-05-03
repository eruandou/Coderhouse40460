using System;
using UnityEngine;

namespace ClasesRegulares.Clase13
{
    public class ScoreAdder : MonoBehaviour
    {
        [SerializeField] private int m_scoreToAdd;

        private void Awake()
        {
        }

        private void Start()
        {
            GameManager.Instance.AddScore(m_scoreToAdd);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                GameManager.Instance.AddScore(m_scoreToAdd);
            }
        }
    }
}