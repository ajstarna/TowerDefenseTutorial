using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int start_money = 400;

    public static int lives;
    public int start_lives = 20;

    private void Start()
    {
        money = start_money;
        lives = start_lives;
    }
}
