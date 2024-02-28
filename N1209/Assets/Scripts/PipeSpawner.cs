using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform PipePrefab;
    [SerializeField] private float timer = 0;
    [SerializeField] private float delayTime = 3f;
    private void Update()
    {
        if (!GameManager.Instance.IsStartGame()) return;
        if (timer < delayTime)
        {
            timer+= Time.deltaTime;
        }
        else
        {
            Spawn();
            timer = 0;
        }
    }
    private void Spawn()
    {
        float SpawnRandom = Random.Range(-3, 3.5f);
        Instantiate(PipePrefab, new Vector3(transform.rotation.x, SpawnRandom, 0), transform.rotation);
    }
}
