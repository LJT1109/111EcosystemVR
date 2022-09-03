using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MouseControl : MonoBehaviour
{
    public Camera uc;
    public Image Target;
    InputSet myInput;
    float presstime,cooldown = 2.0f; //���n�Q�s�I�s��A���j2000ms
    float MouseX, MouseY;
    int loadscene=-1;
    public Text mes; //��ܤ�r�T��
    public Text sid; //��ܾǥ͸�T

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android) gameObject.SetActive(false);
        mes.text = "";
        sid.text = GlobalSet.SID;
        presstime = Time.realtimeSinceStartup;
        myInput = new InputSet();
        myInput.PCVR.Enable();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup - presstime > cooldown && loadscene!=-1)
        {
            SceneManager.LoadScene(loadscene);
        }
        float HorizontalSensitivity = 100.0f;
        float VerticalSensitivity = 100.0f;

        Vector2 mp = myInput.PCVR.MouseSys.ReadValue<Vector2>();
        MouseX = mp.x;
        MouseY = mp.y;
        
        float RotationX = HorizontalSensitivity * MouseX * Time.deltaTime;
        float RotationY = VerticalSensitivity * MouseY * Time.deltaTime;

        Vector3 CameraRotation = uc.transform.rotation.eulerAngles;

        CameraRotation.x -= RotationY;
        CameraRotation.y += RotationX;

        uc.transform.rotation = Quaternion.Euler(CameraRotation);

        Ray ray = new Ray(transform.position, uc.transform.forward * 100);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            Target.rectTransform.sizeDelta = new Vector2(130, 130);
            string Feature = hit.collider.gameObject.name;
            if (Feature.Substring(0, 2) == "CH")
            {
                if (Feature == "CH1") mes.text = "�椸1.�ͪ��h�˩�";
                else if (Feature == "CH2") mes.text = "�椸2.�x�W���h�ˤ�����";
                else if (Feature == "CH3") mes.text = "�椸3.�ͪ��ͦs�A��";
                else if (Feature == "CH4") mes.text = "�椸4.�~�ӤJ�I�ع�x�W���v�T";
                else if (Feature == "CH5") mes.text = "�椸5.�Գ��E�p";
                else if (Feature == "CH6") mes.text = "�椸6.�L�s�ͺA�P�۪�";
                if (Mouse.current.leftButton.isPressed && Time.realtimeSinceStartup - presstime > cooldown) //��ܥؼЪ�
                {
                    presstime = Time.realtimeSinceStartup;                    
                    GameObject.Find("SelectEffect").GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
                    loadscene = int.Parse(Feature.Substring(2, 1))+1;                    
                }
            }
            else //�����쪫��A�����O�ﶵ
            {
                Target.rectTransform.sizeDelta = new Vector2(80, 80);
                mes.text = "";
            }
            
        }
        else //�S���쪫��
        {
            Target.rectTransform.sizeDelta = new Vector2(80, 80);
            mes.text = "";
        }
    }  
}
