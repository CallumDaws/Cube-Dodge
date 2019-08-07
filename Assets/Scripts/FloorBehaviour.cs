using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{
    public int score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            score++;
            Destroy(other.gameObject);
        }
    }
}
