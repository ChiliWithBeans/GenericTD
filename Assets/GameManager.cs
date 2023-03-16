using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float money;
    public float moneyPerTick;
    float timer;
    float enemyTimer;
    public float moneyGainTime;
    public bool buildMode;
    public GameObject selectedTurret;
    public GameObject enemy;
    public float enemySpawnTime;
    public float difficultyScaling;
    public Text dollarinos;
    public Text points;
    public Text life;
    public Text gameOverText;
    public float baseHealth;
    public float score;

    public GameObject Spawnpoint1;
    public GameObject Spawnpoint2;
    public GameObject Spawnpoint3;
    public GameObject Spawnpoint4;
    public GameObject Spawnpoint5;
    public GameObject Spawnpoint6;

    public void buildModeOn(GameObject turret)
    {
        if (buildMode == true)
        {
            buildMode = false;
        }
        else { buildMode = true; }
        selectedTurret = turret;
    }

    public void buildModeOff()
    {
        buildMode = false;
    }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameOverText.text = "";
        moneyPerTick = 10;
        timer = moneyGainTime;
        enemyTimer = enemySpawnTime;
        buildMode = false;
        score = 0;
    }

    void spawnEnemy()
    {
        int location = Random.Range(0, 5);
        switch (location)
        {
            case 0:
                Instantiate(enemy, Spawnpoint1.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemy, Spawnpoint2.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemy, Spawnpoint3.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(enemy, Spawnpoint4.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(enemy, Spawnpoint5.transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(enemy, Spawnpoint6.transform.position, Quaternion.identity);
                break;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOver()
    {
        gameOverText.text = "Game Over\nFinal Score:" + score.ToString();
    }

    void Update()
    {
        points.text = "Score:" + score.ToString();
        dollarinos.text = "Money:" + money.ToString();
        life.text = "Health:" + baseHealth.ToString();
        timer -= Time.deltaTime;
        enemyTimer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = moneyGainTime;
            money += moneyPerTick;
            if (enemyTimer > difficultyScaling)
            {
                enemySpawnTime -= difficultyScaling;
            }
            Debug.Log(money);
        }
        if (enemyTimer <= 0)
        {
            enemyTimer = enemySpawnTime;
            spawnEnemy();
        }
    }

    private void FixedUpdate()
    {

    }
}

