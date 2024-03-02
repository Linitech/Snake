using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // variables

    // direction variables
    private Vector2 direction;
    bool goingUp;
    bool goingLeft;
    bool goingDown;
    bool goingRight;

    // body

    List<Transform> segments; // list of the body parts

    public Transform bodyPrefab; // place to store tiny body

    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform> (); // create a new list

        segments.Add(transform); // add the head of the snake to the list
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }

    }

    void FixedUpdate()
    {
        for (int i = segments.Count -1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }


        transform.position = new Vector2
        (Mathf.Round(transform.position.x) + direction.x,
        Mathf.Round(transform.position.y) + direction.y);
    }

    void Grow()
    {
        Transform segment = Instantiate(bodyPrefab);
       
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);

    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Debug.Log("hit");
            Grow();
        }


        else if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene("EndScene");
        }


    }

}
    










