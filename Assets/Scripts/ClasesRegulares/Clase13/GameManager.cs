using System;
using ClasesRegulares.Clase13;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager m_scoreManager;
    [SerializeField] private LevelSceneManager m_levelSceneManager;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int p_score)
    {
        m_scoreManager.Add(p_score);
        var l_currentScore = m_scoreManager.GetCurrentScore();
        if (l_currentScore > 100)
        {
            TryLoadLevel("Clase12_Fisicas");
        }
    }

    public void TryLoadLevel(string p_levelToLoad)
    {
        m_levelSceneManager.LoadLevel(p_levelToLoad);
    }
}