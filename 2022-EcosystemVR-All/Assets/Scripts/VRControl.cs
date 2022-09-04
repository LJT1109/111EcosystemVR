using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControl : MonoBehaviour
{
    // Start is called before the first frame update
    float presstime, cooldown = 2.0f; //���n�Q�s�I�s��A���j2000ms
    int loadscene = -1;
    public Text mes; //��ܤ�r�T��
    public Text sid; //��ܾǥ͸�T
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android) gameObject.SetActive(false);
        mes.text = "";
        sid.text = GlobalSet.SID;
        presstime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - presstime > cooldown && loadscene != -1)
        {
            print(loadscene);
            SceneManager.LoadScene(loadscene);
        }
    }

    public void HoverIn(string Feature)
    {
        if(Feature == "CH1") mes.text = "�椸1.�ͪ��h�˩�";
        else if (Feature == "CH2") mes.text = "�椸2.�x�W���h�ˤ�����";
        else if (Feature == "CH3") mes.text = "�椸3.�ͪ��ͦs�A��";
        else if (Feature == "CH4") mes.text = "�椸4.�~�ӤJ�I�ع�x�W���v�T";
        else if (Feature == "CH5") mes.text = "�椸5.�Գ��E�p";
        else if (Feature == "CH6") mes.text = "�椸6.�L�s�ͺA�P�۪�";
    }
    public void HoverOut(string Feature)
    {
        mes.text = "";
    }
    public void CheckSelect(string Feature)
    {
        //RightHand.Trigger.OnPressing = inputActions.XRIRightHandInteraction.Activate.ReadValue<float>() == 1 ? true : false;
        mes.text = Feature;
        if (Feature.Substring(0, 2) == "CH")
        {
            mes.text=Feature;
            GameObject.Find("SelectEffect").GetComponent<AudioSource>().Play();
            GameObject.Find(Feature).transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            loadscene = int.Parse(Feature.Substring(2, 1))+1;
        }
    }

    /*public void OnSelectEntered(SelectEnterEventArgs args)
    {
        mes.text = "YAAAA";
    }*/
}
