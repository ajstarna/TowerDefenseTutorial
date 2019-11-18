using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemy_prefab;
    public Transform spawn_point;

    public const float time_between_waves = 4.99f;

    private float countdown = 2f;

    public Text wave_countdown_text;

    private int wave_number = 1;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = time_between_waves;
        }

        countdown -= Time.deltaTime;

        wave_countdown_text.text = Mathf.Ceil(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        Debug.Log("wave inc");
        for (int i = 0; i < wave_number; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        wave_number++;
    }

    void SpawnEnemy ()
    {
        Instantiate(enemy_prefab, spawn_point.position, spawn_point.rotation);
    }
}
