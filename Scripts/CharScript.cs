using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{
    bool moving;
    public bool alive = true;
    List<AimScript> targets = new List<AimScript>();
    float speed = 0.1f;
    public int type;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (targets.Count > 0)
            {
                var target = targets[0];
                if (transform.position != target.transform.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
                }
                else
                {
                    targets.RemoveAt(0);
                    Destroy(target.gameObject);
                    if (targets.Count == 0)
                    {
                        stopMoving();
                    }
                }
            } else
            {
                stopMoving();
            }
        }
    }

    private void OnMouseDown()
    {
        FindObjectOfType<FieldScript>().current = this;
        removePath();
    }

    void startMoving()
    {
        moving = true;
        //GetComponent<SpriteRenderer>().color = Color.blue;
    }

    void stopMoving()
    {
        moving = false;
        //GetComponent<SpriteRenderer>().color = originalColor;
    }

    public void addTarget(AimScript aim)
    {
        targets.Add(aim);
        if (!moving)
        {
            startMoving();
        }
    }

    public void finished(Vector3 pos)
    {/*
        stopMoving();
        transform.position = pos;
        removePath();
        Destroy(gameObject);*/
    }

    void removePath()
    {
        targets.ForEach(t => Destroy(t.gameObject));
        targets.Clear();
    }

    public void setType(int type)
    {
        this.type = type;
        GetComponent<SpriteRenderer>().color = Types.getColor(type);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alive)
        {
            if (collision.gameObject.GetComponent<CharScript>())
            {
                moving = false;
                removePath();
                GetComponent<SpriteRenderer>().color = Color.black;
                alive = false;
                if (Camera.main.WorldToViewportPoint(transform.position).x <= 0.1)
                {
                    Destroy(gameObject);
                }
                FindObjectOfType<Game>().died(type);
            }
        }
    }
}
