using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int score;
    public float lastCreation;
    float freq = 1f;
    int MAXCHARS = 5;
    // Start is called before the first frame update
    void Start()
    {
        lastCreation = Time.realtimeSinceStartup;
        createChars();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - lastCreation >= freq)
        {
            create();
            lastCreation = Time.realtimeSinceStartup;
        }
    }

    void createChars()
    {
        for (int i=0; i<MAXCHARS; i++)
        {
            createChar(i);
        }
    }

    void createChar(int type)
    {
        var ch = Instantiate(FindObjectOfType<Keeper>().Get("Char"));
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, (float)(type + 1) / (MAXCHARS + 1), 0));
        pos.z = -0.1f;
        ch.transform.position = pos;
        ch.GetComponent<CharScript>().setType(type);
    }

    void create()
    {
        var type = Types.random();
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.value * 0.9f + 0.1f, Random.value, 0));
        pos.z = -0.1f;
        var ex = Instantiate(FindObjectOfType<Keeper>().Get("Exit"));
        ex.transform.position = pos;
        ex.GetComponent<ExitScript>().setType(type);
    }

    void increaseScore()
    {
        score++;
        FindObjectOfType<Text>().text = score.ToString();
    }

    public void taken()
    {
        increaseScore();
    }

    public void died(int type)
    {
        createChar(type);
    }
}
