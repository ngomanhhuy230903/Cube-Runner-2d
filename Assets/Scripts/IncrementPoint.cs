using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementPoint : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("SceneLimit"))
        {
            Destroy(gameObject);
        }
    }
}
