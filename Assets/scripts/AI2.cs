using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.AI;


public class AI2 : MonoBehaviour
{

    public enum EnemyState
    {
        Idle,
        Run
    }
    public EnemyState CurrentState = EnemyState.Idle;
    private Transform player;
    private NavMeshAgent2D agent;
    public float movespeed;
    private Vector2 dest = Vector2.zero;
    private Vector2 []empty = new Vector2[114] {
        new Vector2(-8.5f, 5.5f), new Vector2(-8.5f, 4.5f), new Vector2(-8.5f, 3.5f), new Vector2(-8.5f, 2.5f), new Vector2(-8.5f, 1.5f),
        new Vector2(-8.5f, -0.5f), new Vector2(-8.5f, -1.5f), new Vector2(-8.5f, -2.5f), new Vector2(-8.5f, -3.5f), new Vector2(-8.5f, -4.5f),
        new Vector2(-7.5f, 5.5f), new Vector2(-7.5f, 1.5f), new Vector2(-7.5f, -0.5f), new Vector2(-7.5f, -4.5f), new Vector2(-6.5f, 5.5f),
        new Vector2(-6.5f, 4.5f), new Vector2(-6.5f, 2.5f), new Vector2(-6.5f, 1.5f), new Vector2(-6.5f, 0.5f), new Vector2(-6.5f, -0.5f),
        new Vector2(-6.5f, -1.5f), new Vector2(-6.5f, -3.5f), new Vector2(-6.5f, -4.5f), new Vector2(-5.5f, 4.5f), new Vector2(-5.5f, 2.5f),
        new Vector2(-5.5f, -1.5f), new Vector2(-5.5f, -3.5f), new Vector2(-4.5f, 5.5f), new Vector2(-4.5f, 4.5f), new Vector2(-4.5f, 3.5f),
        new Vector2(-4.5f, 2.5f), new Vector2(-4.5f, -1.5f), new Vector2(-4.5f, -2.5f), new Vector2(-4.5f, -3.5f), new Vector2(-4.5f, -4.5f),
        new Vector2(-3.5f, 5.5f), new Vector2(-3.5f, 2.5f), new Vector2(-3.5f, -1.5f), new Vector2(-3.5f, -4.5f), new Vector2(-2.5f, 5.5f),
        new Vector2(-2.5f, 2.5f), new Vector2(-2.5f, 1.5f), new Vector2(-2.5f, 0.5f), new Vector2(-2.5f, -0.5f), new Vector2(-2.5f, -1.5f),
        new Vector2(-2.5f, -4.5f), new Vector2(-1.5f, 5.5f), new Vector2(-1.5f, 2.5f), new Vector2(-1.5f, -1.5f), new Vector2(-1.5f, -4.5f),
        new Vector2(-0.5f, 5.5f), new Vector2(-0.5f, 4.5f), new Vector2(-0.5f, 3.5f), new Vector2(-0.5f, 2.5f), new Vector2(-0.5f, 1.5f),
        new Vector2(-0.5f, -0.5f), new Vector2(-0.5f, -1.5f), new Vector2(-0.5f, -2.5f), new Vector2(-0.5f, -3.5f), new Vector2(-0.5f, -4.5f),
        new Vector2(0.5f, 5.5f), new Vector2(0.5f, 1.5f), new Vector2(0.5f, -0.5f), new Vector2(0.5f, -4.5f), new Vector2(1.5f, 5.5f),
        new Vector2(1.5f, 4.5f), new Vector2(1.5f, 3.5f), new Vector2(1.5f, 1.5f), new Vector2(1.5f, 0.5f), new Vector2(1.5f, -0.5f),
        new Vector2(1.5f, -2.5f), new Vector2(1.5f, -3.5f), new Vector2(1.5f, -4.5f), new Vector2(2.5f, 3.5f), new Vector2(2.5f, 0.5f),
        new Vector2(2.5f, -2.5f), new Vector2(3.5f, 3.5f), new Vector2(3.5f, 2.5f), new Vector2(3.5f, 1.5f), new Vector2(3.5f, 0.5f),
        new Vector2(3.5f, -0.5f), new Vector2(3.5f, -1.5f), new Vector2(3.5f, -2.5f), new Vector2(4.5f, 3.5f), new Vector2(4.5f, 0.5f),
        new Vector2(4.5f, -2.5f), new Vector2(5.5f, 3.5f), new Vector2(5.5f, 1.5f), new Vector2(5.5f, 0.5f), new Vector2(5.5f, -0.5f),
        new Vector2(5.5f, -2.5f), new Vector2(6.5f, 5.5f), new Vector2(6.5f, 4.5f), new Vector2(6.5f, 3.5f), new Vector2(6.5f, 1.5f),
        new Vector2(6.5f, -0.5f), new Vector2(6.5f, -2.5f), new Vector2(6.5f, -3.5f), new Vector2(6.5f, -4.5f), new Vector2(7.5f, 5.5f),
        new Vector2(7.5f, 1.5f), new Vector2(7.5f, -0.5f), new Vector2(7.5f, -4.5f), new Vector2(8.5f, 5.5f), new Vector2(8.5f, 4.5f),
        new Vector2(8.5f, 3.5f), new Vector2(8.5f, 2.5f), new Vector2(8.5f, 1.5f), new Vector2(8.5f, 0.5f), new Vector2(8.5f, -0.5f),
        new Vector2(8.5f, -1.5f), new Vector2(8.5f, -2.5f), new Vector2(8.5f, -3.5f),new Vector2(8.5f, -4.5f)};
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();
        player = GameObject.Find("player").transform;
        agent.isStopped = false;
        dest = empty[Random.Range(0, empty.Length)];
        agent.SetDestination(dest);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        switch (CurrentState)
        {
            case EnemyState.Idle:
               
                if (distance > 1 && distance <= 4)
                {
                    CurrentState = EnemyState.Run;
                }
                else {
                    if (Vector2.Distance((Vector2)transform.position, dest) < 0.25f)
                    {
                        dest = empty[Random.Range(0, empty.Length)];
                        agent.SetDestination(dest);
                    }
                }

                
                
                break;


            case EnemyState.Run:

                if ( distance > 4)
                {
                    CurrentState = EnemyState.Idle;
                    dest = empty[Random.Range(0, empty.Length)];
                    agent.SetDestination(dest);
                }
                else {
                    agent.SetDestination(player.position);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Destroy(collision.gameObject);
            SoundEffect.Instance.MakeBeEatSound();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

}