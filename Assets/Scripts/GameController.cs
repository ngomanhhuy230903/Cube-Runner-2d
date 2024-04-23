using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject Obstacle;
    public GameObject IncrementPoint;
    public float spawnTime;
    float m_spawnTime;
    bool m_isGameOver;
    int m_score;
    UIManager m_ui;
    public int Score { get; set; }
    public void incrementScore()
    {
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public bool gameOver
    {
        get { return m_isGameOver; }
        set { m_isGameOver = value; }
    }     
    // Start is called before the first frame update
    public void spawnObstacle()
    {
        float randomPos = Random.Range(-2.2f, -3.9f);
        Vector2 spawnPos = new Vector2(9.6f, randomPos);
        if (Obstacle)
        {
            Instantiate(Obstacle, spawnPos,Quaternion.identity);
        }
        Vector2 spawnPosPoint = new Vector2(9.6f, randomPos + 4.41f);
        if (IncrementPoint)
        {
            Instantiate(IncrementPoint, spawnPosPoint, Quaternion.identity);
        }
    }

    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0)
        {
            spawnObstacle();
            m_spawnTime = spawnTime;
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
