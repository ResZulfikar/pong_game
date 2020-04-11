using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{

    public int counter = 30;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = counter.ToString();
        StartCoroutine(hitungmundur());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator hitungmundur()
    {
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter -= 1;
            timerText.text = counter.ToString();
        }

        timerText.text = "Game Over";
    }
}
