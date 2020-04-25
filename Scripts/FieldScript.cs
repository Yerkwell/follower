using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    public CharScript current;
    Vector3? last;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (current != null && current.alive)
            {
                Vector3 pos = Input.mousePosition;
                if (last is null || (pos - last.Value).magnitude >= 30)
                {
                    createAt(pos);
                }
            }
        }
    }

    void createAt(Vector3 pos)
    {
        last = pos;
        pos = Camera.main.ScreenToWorldPoint(pos);
        var aim = Instantiate(FindObjectOfType<Keeper>().Get("Aim"));
        pos.z = aim.transform.position.z;
        aim.transform.position = pos;
        aim.GetComponent<SpriteRenderer>().color = Types.getColor(current.type);
        current.addTarget(aim.GetComponent<AimScript>());
    }

    private void OnMouseUp()
    {
        if (current != null && current.alive)
        {
            Vector3 pos = Input.mousePosition;
            createAt(pos);
            last = null;
            current = null;
        }
    }
}
