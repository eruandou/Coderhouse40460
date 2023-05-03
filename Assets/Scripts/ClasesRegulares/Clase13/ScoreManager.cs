using UnityEngine;

namespace ClasesRegulares.Clase13
{
    public class ScoreManager : MonoBehaviour
    {
        private int m_currentScore;

        public int GetCurrentScore() => m_currentScore;

        public void Add(int p_score)
        {
            m_currentScore += p_score;
            Debug.Log($"Current score {m_currentScore}");
        }
    }
}