using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private Vector2 basePosition;
    public Transform enemySpawnPoint;

    private string invaderName;
    private int rows;
    private int collumns;
    

    private void Start()
    {
        rows = 3;
        collumns = 10;
        basePosition = enemySpawnPoint.position;
        Spawn();
    }

    public void Spawn()
    {
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < collumns; j++)
            {
                GameObject invader;
                float randValue = Random.value;
                if(randValue < 0.3f)                     // 30% of the time
                    invader = ObjectPooler.sharedInstance.GetPooledObject("Invader01");
                else if(randValue < 0.5f)                // 20% of the time
                    invader = ObjectPooler.sharedInstance.GetPooledObject("Invader02");
                else if(randValue < 0.6f)                // 10% of the time
                    invader = ObjectPooler.sharedInstance.GetPooledObject("Invader03");
                else                                     // 40% of the time
                    invader = null;
                
                if(invader != null)
                {
                    invader.transform.position = enemySpawnPoint.position;
                    invader.transform.parent = gameObject.transform;
                    invader.SetActive(true);
                }
                enemySpawnPoint.position = new Vector2(enemySpawnPoint.position.x + 1, enemySpawnPoint.position.y);
            }
            enemySpawnPoint.position = new Vector2(basePosition.x, enemySpawnPoint.position.y - 0.5f);
        }
    }
}
