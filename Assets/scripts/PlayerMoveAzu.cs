using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMoveAzu : MonoBehaviour
{
    public float speed = 0.125f;

    private Vector2 dest = Vector2.zero;

    private void Start()
    {
        dest = transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);

        GetComponent<Rigidbody2D>().MovePosition(temp);

        if ((Vector2)transform.position == dest)
        {
            System.Console.WriteLine((Vector2)transform.position);
            System.Console.WriteLine(dest);
            if (Input.GetKey(KeyCode.UpArrow) && Valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow) && Valid(Vector2.down))
            {
                dest = (Vector2)transform.position + Vector2.down;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Valid(Vector2.left))
            {
                dest = (Vector2)transform.position + Vector2.left;
            }
            if (Input.GetKey(KeyCode.RightArrow) && Valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }
        }
    }

    private bool Valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name == "brr")
    //    {
    //        SoundEffect.Instance.MakeCrashSound();
    //    }
    //}
}