using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    public GameObject hungryCat;
    public GameObject fullCat;

    public RectTransform front;

    public int type;

    float full = 0.0f;
    float energy = 0.0f;
    float speed = 0.05f;

    bool isFull = false;


    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, 30f);

        if(type == 1)
        {
            speed = 0.05f;
            full = 5f;
        }
        else if(type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }

    }


    void Update()
    {
        if(energy < full)
        {
            transform.position += Vector3.down * speed;
            if(transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position += Vector3.left * 0.05f;
            }
        }
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if(energy < full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                Destroy(collision.gameObject);


                if(type == 1 & energy == 5 | type == 2 & energy == 10)
                {
                    if (!isFull)
                    {
                        isFull = true;                                      // ��� ����
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 3.0f);
                        GameManager.Instance.AddScore();
                    }

                }
            }

        }
    }
}
