using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Player")
        {
            //Debug.Log(collision.transform.name);
            Player.GetComponent<Interaction>().ReSpawn();
        }
        
    }
}
