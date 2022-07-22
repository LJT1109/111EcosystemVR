using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

namespace ChickenTool
{
    public class Random_Speed : MonoBehaviour
    {
        // Start is called before the first frame update
        public PathFollower PathFollower;
        void Start()
        {
            try
            {
                PathFollower = this.GetComponent<PathFollower>();
            }
            finally
            {
                PathFollower.speed =  Random.Range(2.5f, 3.5f);
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            
            
        }
    }
}

