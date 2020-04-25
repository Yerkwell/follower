using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ch = collision.gameObject.GetComponent<CharScript>();
        if (ch && ch.type == type)
        {
            ch.finished(transform.position);
            FindObjectOfType<Game>().taken();
            Destroy(gameObject);
        }
    }

    public void setType(int type)
    {
        this.type = type;
        var color = Types.getColor(type);
        GetComponent<SpriteRenderer>().color = color;
    }
}
