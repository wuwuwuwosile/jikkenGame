using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int i = 0;
    public static int j = 0;
    public static int k = 0;
    // if mode == true 時間差
    // if mode == false　強度差
    public static bool mode = true;


    public static void countEat()
    {
        // Eat 1 item
        i ++;
        // Have eaten 3 item
        if (i == 3) {

            
            SoundEffect.Instance.MakeWinSound();
            // Pause app
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        return;
    }

    public static void countCrash()
    {
        j++;
    }

    public static void countRange()
    {
        k++;
    }
}
