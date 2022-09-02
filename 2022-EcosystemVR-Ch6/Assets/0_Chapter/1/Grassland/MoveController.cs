using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject Lion;
    public GameObject Zebra;
    public GameObject LionTarget1;
    public GameObject LionTarget2;
    public GameObject ZebraTarget1;
    public GameObject ZebraTarget2;
    public GameObject LookTarget;
    public static int i = 0;
    private void Start()
    {
        if (i == 1)
        {
            StartCoroutine(Go());
            Debug.Log(i);
        }
    }

    void Update()
    {
        if (i == 1)
        {
            StartCoroutine(Go());
            Invoke("Go2()", 0.3f * Time.deltaTime);
            //StartCoroutine(Gogo());
            Zebra.transform.LookAt(LookTarget.transform.position);
            Lion.transform.LookAt(LookTarget.transform.position);
        }
    }

    IEnumerator Gogo()
    {
        while (Lion.transform.position != LionTarget2.transform.position)
        {
            while (Lion.transform.position != LionTarget1.transform.position)
            {
                Lion.transform.position = Vector3.Lerp(Lion.transform.position, LionTarget1.transform.position, 0.3f * Time.deltaTime);
                Zebra.transform.position = Vector3.Lerp(Zebra.transform.position, ZebraTarget1.transform.position, 0.3f * Time.deltaTime);
                yield return null;
            }
            Lion.transform.position = Vector3.Lerp(Lion.transform.position, LionTarget2.transform.position, 0.05f * Time.deltaTime);
            Zebra.transform.position = Vector3.Lerp(Zebra.transform.position, ZebraTarget2.transform.position, 0.05f * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Go()
    {
        while (Lion.transform.position != LionTarget1.transform.position)
        {
            Lion.transform.position = Vector3.Lerp(Lion.transform.position, LionTarget1.transform.position, 0.3f * Time.deltaTime);
            Zebra.transform.position = Vector3.Lerp(Zebra.transform.position, ZebraTarget1.transform.position, 0.3f * Time.deltaTime);
            yield return null;
        }
        //StartCoroutine(Go2());
    }

    IEnumerator Go2()
    {
        while (Lion.transform.position != LionTarget2.transform.position)
        {
            Lion.transform.position = Vector3.Lerp(Lion.transform.position, LionTarget2.transform.position, 0.05f * Time.deltaTime);
            Zebra.transform.position = Vector3.Lerp(Zebra.transform.position, ZebraTarget2.transform.position, 0.05f * Time.deltaTime);
            yield return null;
        }
    }
}
