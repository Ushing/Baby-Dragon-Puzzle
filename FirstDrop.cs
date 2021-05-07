using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDrop : MonoBehaviour
{
    [SerializeField]
    private Transform firstPlace;

    private Vector2 initialPosition;
    private float delraX, deltaY;

    public static bool locked;

    public GameObject FirstAnim;

    RaycastHit hit;
    void Start()
    {
        initialPosition = transform.position;
    }

   private void Update()
    {
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && hit.collider.gameObject.tag == "first")
                        {
                            delraX = touchPos.x - transform.position.x;
                            deltaY = touchPos.y - transform.position.y;
                         
                        }
                        break;

                    case TouchPhase.Moved:
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos) && hit.collider.gameObject.tag == "first")

                            transform.position = new Vector2(touchPos.x - delraX, touchPos.y - deltaY);

                        break;
                    case TouchPhase.Ended:
                        if (Mathf.Abs(transform.position.x - firstPlace.position.x) <= 0.5f &&
                            Mathf.Abs(transform.position.y - firstPlace.position.y) <= 0.5f)
                        {
                            transform.position = new Vector2(firstPlace.position.x, firstPlace.position.y);
                            locked = true;
                            if (transform.position == firstPlace.position)
                            {
                                FirstAnim.SetActive(true);
                            }
                        }
                        else
                        {
                            transform.position = new Vector2(initialPosition.x, initialPosition.y);
                        }
                        break;
                }
            }
        }
    }
}
