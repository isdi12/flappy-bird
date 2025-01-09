using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variable;

    private TMP_Text score;

    private void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (variable) // el switch es como usar el if else se pueden ambas 
        {
            case GameManager.GameManagerVariables.POINTS:
                score.text = "Score:" + GameManager.instance.GetPoints();
                break;
            default:
                break;
        }
    }
}
