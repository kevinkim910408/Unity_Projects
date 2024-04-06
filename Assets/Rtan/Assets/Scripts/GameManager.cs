using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;

    public Text totalScoreTxt;
    public Text timeTxt;

    int totalScore;

    float totalTime = 3.0f;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (totalTime > 0)
        {
	    totalTime -= Time.deltaTime;
            
        }
	else
 	{
	    totalTime = 0.0f;
            endPanel.SetActive(true);
            Time.timeScale = 0.0f;
	}
        
        timeTxt.text = Mathf.Max(totalTime, 0).ToString("N2");
    }

    void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
    }
}
