using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VR_StartFlying : MonoBehaviour
{
    bool past,now;
    public int pass;
    public float keeptime = 0.2f;
    
    private void Update()
    {
        now = GetComponent<VR_Gesture>().Is_Flapping;
        if (now) StartCoroutine(keep(keeptime));
        //else StopCoroutine(keep());
        //if(pass)
        past = now;
        if(pass == 1)
        {

        }
    }

    


    IEnumerator keep(float second)
    {
        yield return new WaitForSeconds(second);

        pass += 1;
        StopAllCoroutines();
    }
}
