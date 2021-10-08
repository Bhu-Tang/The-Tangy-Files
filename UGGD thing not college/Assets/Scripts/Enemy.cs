using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-10, 10), 8, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * 4 * Time.deltaTime);
        if(transform.position.y < -6)
        {
            transform.position = new Vector3(Random.Range(-10, 10), 8, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();    
            }
            Destroy(this.gameObject);
        }
    }
}
