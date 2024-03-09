using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{ 
    // variable
    public BoxCollider2D grid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomPos()
    {
        Bounds bounds = grid.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        RandomPos();
    }


}
