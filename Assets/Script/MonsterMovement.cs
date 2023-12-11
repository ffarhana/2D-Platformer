using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private CompositeCollider2D compositeCollider;

    private Animator anim;
    private Transform currentPoint;
    public float speed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isFlying", true);

        compositeCollider = GetComponent<CompositeCollider2D>();
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


    private void OnDrawGizmos()
    {
        Bounds bounds = compositeCollider.bounds;

        Gizmos.DrawWireCube(bounds.center, bounds.size);


        //Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        //Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        //Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);

    }
}
