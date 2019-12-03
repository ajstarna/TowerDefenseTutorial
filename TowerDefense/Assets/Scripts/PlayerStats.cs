using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int start_money = 400;

    private void Start()
    {
        money = start_money;
    }
}
