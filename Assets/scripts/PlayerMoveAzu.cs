using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMoveAzu : MonoBehaviour
{
    public float speed = 0.125f;

    private Vector2 dest = Vector2.zero;

    private Vector2 dest2 = Vector2.zero;

    private void Start()
    {
        dest = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)
            || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            dest2 = Vector2.zero;
        }
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
                GameManager.countRange();
            }
            if (Input.GetKey(KeyCode.DownArrow) && Valid(Vector2.down))
            {
                dest = (Vector2)transform.position + Vector2.down;
                GameManager.countRange();
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Valid(Vector2.left))
            {
                dest = (Vector2)transform.position + Vector2.left;
                GameManager.countRange();
            }
            if (Input.GetKey(KeyCode.RightArrow) && Valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                GameManager.countRange();
            }
        }
    }

    private bool Valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        // Debug.Log(hit.collider == GetComponent<Collider2D>());

        
        // If hit.collider is a collider of an item, return true 
        bool itemTri = hit.collider.gameObject.name == "item" || hit.collider.gameObject.name == "item (1)" || hit.collider.gameObject.name == "item (2)";
        bool brrCol = hit.collider == GetComponent<Collider2D>();
        bool tempRet = itemTri || brrCol;
        if (tempRet) return true;
        else
        {
            if (!(pos + dir == dest2))
            {
                dest2 = pos + dir;
                SoundEffect.Instance.MakeCrashSound();
                GameManager.countCrash();
            }

            return false;
        }
    }

}