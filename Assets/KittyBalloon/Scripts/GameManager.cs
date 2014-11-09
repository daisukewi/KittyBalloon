using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public bool Win = false;
    public bool Lose = false;
    public GameObject Player;
    public List<GameObject> Enemies;

	// Use this for initialization
	void Start () {
        
        Enemies = new List<GameObject>();

        GameObject[] AEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in AEnemies)
        {
            Enemies.Add(enemy);
            StateDead deadState = enemy.GetComponent<StateDead>();
            deadState.OnDie += EnemyDied;
        }

        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player)
        {
            HPScript PlayerHPScript = Player.GetComponent<HPScript>();
            if (PlayerHPScript)
            {
                PlayerHPScript.OnHPChanged += PlayerHPChanged;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(Win)
        {
            Debug.Log("Win");
            Invoke("OnWin", 1.5f);
        }

        if (Lose)
        {
            Debug.Log("Lose");
            Invoke("OnLose", 1.5f);
        }
	}

    void PlayerHPChanged(float newHP)
    {
        if(newHP <= 0 && !Win)
        {
            Lose = !Win;
        }
    }

    void EnemyDied(GameObject Enemy)
    {
        Enemies.Remove(Enemy);

        if(Enemies.Count <= 0)
        {
            Win = !Lose;
        }
    }

    void OnLose()
    {
        Debug.Log("OnLose");
        Application.LoadLevel("SplashScreen");
    }

    void OnWin()
    {
        Debug.Log("OnWin");
        Application.LoadLevel("SplashScreen");
    }
}

