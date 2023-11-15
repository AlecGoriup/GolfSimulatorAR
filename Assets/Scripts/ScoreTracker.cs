using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreTracker : MonoBehaviour
{
    private TMP_Text textField;
    int count = 0;
    public int typeButton = 0;

    public void ScoreAdd()
    {
        if (typeButton == 1)
        {
            count = count + 1;
            textField.text = "Score: " + count.ToString();
        }

        if (typeButton == 2)
        {
            count = count + 2;
            textField.text = "Score: " + count.ToString();
        }

        if (typeButton == 3)
        {
            count = count + 3;
            textField.text = "Score: " + count.ToString();
        }

        else
        {
            textField.text = "Score: NOT WORKING";
        }


    }

    public void setType(int number)
    {
        typeButton = number;
    }

    // private void ScoreAdd1()
    // {
    //     count = count++;
    //     textField.text = "Score: " + count.ToString();
    // }

    // private void ScoreAdd2()
    // {
    //     count = count + 2;
    //     textField.text = "Score: " + count.ToString();
    // }

    // private void ScoreAdd3()
    // {
    //     count = count + 3;
    //     textField.text = "Score: " + count.ToString();
    // }

    
}
