using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEditor.Experimental.GraphView;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject retryBtn;

    public RectTransform levelFront;
    public Text levelTxt;

    int level = 0;
    int score = 0;
    private void Awake()
    {
        if(Instance == null)
        {
            if(Instance == null)
            {
                Instance = this;
            }
            Application.targetFrameRate = 60;
        }
    }
    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1f);
    }

    void Update()
    {
        
    }
    void MakeCat()
    {
	 Instantiate(fatCat);
         Instantiate(normalCat);

        // lv.1 20% 확률로 고양이를 더 생성해준다.
        if(level == 1)
        {
            int p = Random.Range(0, 10);
            if(p < 2) Instantiate(normalCat);
        }
        // lv.2 50% 확률로 고양이를 더 생성해준다.
        else if(level == 2)
        {
            int p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        // lv.3 뚱뚱한 고양이를 생성해준다.
        else if (level >= 3)
        {
            Instantiate(fatCat);
        }

    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
    }

    public void AddScore()
    {
        score++;
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1f, 1f);
    }
}
