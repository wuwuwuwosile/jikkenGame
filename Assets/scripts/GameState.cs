using UnityEngine;

public class GameState : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Time.timeScale = 1;
        }
    }
}
