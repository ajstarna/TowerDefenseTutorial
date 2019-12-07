using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool game_ended = false;

    // Update is called once per frame
    void Update()
    {
        if (game_ended)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        game_ended = true;
        Debug.Log("Game over!");
    }
}
