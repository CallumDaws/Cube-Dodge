using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float screenWidth;
    float playerWidth;
    public float speed = 7;
    public event System.Action Death;
    public GameObject player;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        score.SetActive(true);
        player.transform.position = new Vector3(Camera.main.orthographicSize / 2f,1);
        playerWidth = transform.localScale.x / 2f;
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize + playerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        /* float inputX = Input.GetAxisRaw("Horizontal");
         float velocity = inputX * speed;
         transform.Translate(Vector2.right * velocity * Time.deltaTime);*/

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;

            //Check if it is left or right?
            if (touchPosition.x < halfScreen)
            {
                player.transform.Translate(Vector3.left * 5 * Time.deltaTime);
            }
            else if (touchPosition.x > halfScreen)
            {
                player.transform.Translate(Vector3.right * 5 * Time.deltaTime);
            }

            if (transform.position.x < -screenWidth)
            {
                transform.position = new Vector2(-screenWidth, transform.position.y);
            }
            if (transform.position.x > screenWidth)
            {
                transform.position = new Vector2(screenWidth, transform.position.y);
            }
        }
    }
private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Falling Block")
        {
            Death?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
