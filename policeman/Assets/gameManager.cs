using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [SerializeField] Text score;
    float point = 5;
    float lastScore = 0;
    void Start()
    {
        score.text = lastScore.ToString();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scoreIncrease()
    {

        lastScore  += point;
        score.text = lastScore.ToString();
    }
}
