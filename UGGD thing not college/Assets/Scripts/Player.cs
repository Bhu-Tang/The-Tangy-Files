using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // speed variable
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.3f;
    private float _canFire = 0;
    [SerializeField]
    private int _lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 4.5f;
        //Changes current position to 0,0,0
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        { 
            FireLaser();
        }
    }
    void CalculateMovement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Provides speed in real time instead of per frame.
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        //Provides player bounds on the y-axis
        if (transform.position.y >= 5.9f)
        {
            transform.position = new Vector3(transform.position.x, 5.9f, transform.position.z);
        }
        else if (transform.position.y <= -3.95f)
        {
            transform.position = new Vector3(transform.position.x, -3.95f, transform.position.z);
        }
        //Allows the player to wrap around on the x-axis, if you were to go too far to one side, you would pop out the other.
        if (transform.position.x > 11f)
        {
            transform.position = new Vector3(-11f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11f, transform.position.y, transform.position.z);
        }
    }

    void FireLaser()
    {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }    

    public void Damage()
    {
        _lives--;

        if(_lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
