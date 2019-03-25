using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_highScoreText = null;
    [SerializeField] TextMeshProUGUI m_scoreText = null;

    int m_score = 0;
    int m_highscore = 0;
    int count = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            m_highscore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", m_highscore);
        }

        m_highScoreText.text = m_highscore.ToString("D6");
        
    }

    private void Update()
    {
        count++;
        if (count > 20)
        {
            count = 0;
            m_score++;
            if (m_score > m_highscore)
            {
                m_highscore = m_score;
                PlayerPrefs.SetInt("HighScore", m_highscore);
                m_highScoreText.text = m_highscore.ToString("D6");
            }
            m_scoreText.text = m_score.ToString("D6");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
