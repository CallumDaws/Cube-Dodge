using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject fallingBlock;
    public Vector2 waitTimeMinMax;
    float nextSpawnTime;
    public float spawnAngleMax;
    public Vector2 spawnSizeMaxMin;

    Vector2 screenSize;
    // Start is called before the first frame update
    void Start()
    {
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize*2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime && Time.timeSinceLevelLoad > 1f)
        {
            float waitTime = Mathf.Lerp(waitTimeMinMax.y, waitTimeMinMax.x, Difficulty.getTime());
            nextSpawnTime = Time.time + waitTime;
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMaxMin.x, spawnSizeMaxMin.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenSize.x, screenSize.x), screenSize.y + .5f);
            GameObject newBlock = (GameObject) Instantiate(fallingBlock, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector3.one * spawnSize;
        }
    }
}
