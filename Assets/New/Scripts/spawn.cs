using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawn : MonoBehaviour {

    public GameObject[] Fruit;
    public float speed = 7f;

    private int TotalScore;
    public static spawn Instance;

    public Text ScoreText;
    public Text TimeText;

    private float StartTime;
    public float CoutTime = 60f;
    private float TimeResmain;

    public GameObject ResetUI;
    public Transform ResetUIPos;

    private bool IsGameOver;

    void Awake()
    {
        Instance = this;
    }

	void Start () {
        GameOver();
	}
	
	void FixedUpdate () 
    {
        if(IsGameOver == true)
        {
            return;
        }

        TimeResmain = CoutTime - (Time.time - StartTime);
        TimeText.text = ((int)TimeResmain).ToString();

        if(TimeResmain <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        IsGameOver = true;
        GameObject Restart = Instantiate(ResetUI);
        Restart.transform.position = ResetUIPos.position;
        StopAllCoroutines();
    }

    private void FruitSpwan()
    {
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        while(true)
        {
            GameObject F1 = Instantiate(Fruit[Random.Range(0, Fruit.Length-1)]);
            Rigidbody r1 = F1.GetComponent<Rigidbody>();
            
            r1.velocity = new Vector3(0, speed, 0);
            r1.angularVelocity = new Vector3(Random.Range(-3f, 3f),0,Random.Range(-3f, 3f));
            r1.useGravity = true;

            Vector3 pos = transform.position + transform.right * Random.Range(-1.0f, 1.0f);
            F1.transform.position = pos;

            yield return new WaitForSeconds(1.0f);
        }
    }

    private void Init()
    {
        TotalScore = 0;
        StartTime = Time.time;
        FruitSpwan();
        ScoreText.text = "0";
        TimeText.text = "0";
        IsGameOver = false;
    }
    
    public void addscore(int Score)
    {
        TotalScore += Score;
        ScoreText.text = TotalScore.ToString();
    }

    public void ResetGame()
    {
        Invoke("Init", 2f);
    }
}
