using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildAI : MonoBehaviour
{
    public Vector2 nextPoint;
    public float speed = 1.5f;
    bool move = false;
    bool first = true;
    public Animator childAiAni;
    // Start is called before the first frame update
    void Start()
    {
        nextPoint = new Vector2(Random.Range((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2), (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2))
            , Random.Range((-Camera.main.orthographicSize) + (transform.localScale.y / 2), Camera.main.orthographicSize - (transform.localScale.y / 2)));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && first)
        { move = true;
            first = false;
        }

        if (move)
        {
            if (transform.position.x < nextPoint.x)
            {
                transform.rotation = new Quaternion(0,180,0,0);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            transform.position = Vector2.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
            childAiAni.SetBool("Run",true);
            if (transform.position.x == nextPoint.x && transform.position.y == nextPoint.y)
            {
                childAiAni.SetBool("Run", false);
                StartCoroutine(NextPosition(Random.Range(.8f, 3.2f)));
            }
        }
    }
    public void Hunt()
    {
        childAiAni.SetTrigger("Hunt");
        move = false;
        transform.gameObject.tag = "Untagged";
        transform.gameObject.layer = 0;
    }

    IEnumerator NextPosition(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        nextPoint = new Vector2(Random.Range((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2), (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2))
        , Random.Range((-Camera.main.orthographicSize) + (transform.localScale.y / 2), Camera.main.orthographicSize - (transform.localScale.y / 2)));
    }

}
