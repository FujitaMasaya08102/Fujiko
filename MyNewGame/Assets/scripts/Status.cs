using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public GameObject[] lifegauge;

    public PlayerC unitychan;
    public Text scoreText;
   
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        int score = TotalScore();


        scoreText.text = "ëñçsãóó£ÅF" + score + "Çç";
 

        Lifecheck(unitychan.Life());
    }

    int TotalScore()
    {
        return (int)unitychan.transform.position.z;
    }



    public void Lifecheck(int life)
    {
        for (int i = 0; i < lifegauge.Length; i++)
        {
            if (i < life)
            {
                lifegauge[i].SetActive(true);
            }
            else
            {
                lifegauge[i].SetActive(false);
            }
        }
    }
}