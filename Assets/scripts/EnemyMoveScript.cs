using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    //public Transform[] wayPoints;
    public GameObject[] wayPointsGos;
    public float speed = 0.2f;
    private List<Vector3> wayPoints = new List<Vector3>();
    private int index = 0;

    private void Start()
    {
        LoadAPath(wayPointsGos[Random.Range(0, wayPointsGos.Length)]);
    }

    private void FixedUpdate()
    {
        if (transform.position != wayPoints[index])
        {
            Vector2 temp = Vector2.MoveTowards(transform.position, wayPoints[index], speed);
            GetComponent<Rigidbody2D>().MovePosition(temp);
        }
        else
        {
            index++;
            if (index >= wayPoints.Count)
            {
                index = 0;
                LoadAPath(wayPointsGos[Random.Range(0, wayPointsGos.Length)]);
            }
            
        }
    }

    private void LoadAPath(GameObject go)
    {
        wayPoints.Clear();
        foreach (Transform t in go.transform)
        {
            wayPoints.Add(t.position);
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
