using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMaxMin;
    float speed;
    // Start is called before the first frame update
    private void Start()
    {
        speed = Mathf.Lerp(speedMaxMin.x, speedMaxMin.y, Difficulty.getTime());
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }
}
