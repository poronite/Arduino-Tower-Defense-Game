using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject NextTarget;

    void OnDrawGizmos()
    {
        if(NextTarget != null)
        Gizmos.DrawLine(transform.position, NextTarget.transform.position);
    }

    //void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Enemy") || Vector2.Distance(transform.position, collision.transform.position) == 0)
    //    if(NextTarget == null)
    //    {
    //        collision.gameObject.GetComponent<Enemy>().Attack();
    //    }
    //    else
    //    collision.gameObject.GetComponent<Enemy>().target = NextTarget.transform.position;
    //}
}
