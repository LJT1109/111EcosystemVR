using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Interaction : MonoBehaviour
{
    public CharacterController CharacterController;
    public int Health = 3, Food = 10;
    public GameObject SpawnPoint, Animate, SpawnPoint2, AnimateCanvas;
    public Text UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReSpawn()
    {
        CharacterController.enabled = false;

        this.transform.position = SpawnPoint.transform.position;
        CharacterController.enabled = true;
        Health -= 1;
        pass_checker();
        UI_Update();
    }

    void Get_a_lemon()
    {
        Food -= 1;
        pass_checker();
        UI_Update();
    }
    void child_Switch(bool status)
    {

        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name != "XR Origin")
                this.transform.GetChild(i).gameObject.SetActive(status);
        }


    }
    IEnumerator Get_Chicken()
    {
        Food -= 3;
        CharacterController.enabled = false;



        StartCoroutine(Animate.GetComponent<Steel>().spawn());
        child_Switch(false);

        this.transform.position = SpawnPoint2.transform.position;
        AnimateCanvas.SetActive(true);


        yield return new WaitForSeconds(4);
        child_Switch(true);
        AnimateCanvas.SetActive(false);
        pass_checker();
        UI_Update();
        CharacterController.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {

        if (collision.transform.tag == "Lemon")
        {
            Get_a_lemon();
            collision.gameObject.SetActive(false);
        }
        if (collision.transform.tag == "Chicken")
        {
            StartCoroutine(Get_Chicken());
            collision.gameObject.SetActive(false);
        }



    }

    void UI_Update()
    {

        UI.text = string.Format("¥Í©R¡G{0}		°§¾j¡G{1}", Health, Food);

    }

    void pass_checker()
    {
        if (Health == 0)
        {

            GameObject.Find("Start").GetComponent<Loading>().unload();
            GameObject.Find("XR Origin").GetComponent<Goto>().To_Menu();
        }
    }
}
