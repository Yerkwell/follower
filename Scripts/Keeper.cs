using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Keeper : MonoBehaviour
{
    public List<GameObject> prefabs;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Get(string name)
    {
        return prefabs.FirstOrDefault(x => x.name == name);
    } 
}
