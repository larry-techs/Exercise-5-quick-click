using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Rigidbody Rb;
    private GameManager gameManager;
    public int pointValue;

    public ParticleSystem explosionParticle;
  
    private float maxSpeed = 16;
    private float minSpeed = 12;
    private float maxTorque = 10;
    private float ySpawnPos = -2;
    private float xSpawnPos = 4;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // get gamemanager component from game manager
        //force to go up
        Rb.AddForce(RandomForce(), ForceMode.Impulse);
        //rotate the object
        Rb.AddTorque(RandomTorque() , RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = SpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    Vector3 RandomForce ()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return  Random.Range(maxTorque, -maxTorque);
    }
    Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(xSpawnPos, -xSpawnPos), ySpawnPos);
    }
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
       
    }


}
