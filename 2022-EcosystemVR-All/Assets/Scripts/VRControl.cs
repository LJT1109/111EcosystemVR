using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class VRControl : MonoBehaviour
{
    // Start is called before the first frame update
    float presstime, cooldown = 2.0f; //¤£­n³Q³sÂI³s¿ï¡A¶¡¹j2000ms
    int loadscene = -1;
    public Text mes; //Åã¥Ü¤å¦r°T®§
    public Text sid; //Åã¥Ü¾Ç¥Í¸ê°T
    void Start()
    {
        
        if (Application.platform != RuntimePlatform.Android) gameObject.SetActive(false);
        else
        {
            print(GlobalSet.LID);
            if (GlobalSet.LID != null) GlobalSet.LID = "";
            if (GlobalSet.LID != "")
            {
                WebPhp webPhp = FindObjectOfType<WebPhp>();
                StartCoroutine(webPhp.php(GlobalSet.SID, GlobalSet.LID, "", WebPhp.php_method.LevelInf));
            }
            GlobalSet.LID = "";
            if (GlobalSet.SID == null) GlobalSet.SID = "dct" + UnityEngine.Random.Range(1, 10);
            mes.text = "";
            sid.text = GlobalSet.SID;
            presstime = Time.realtimeSinceStartup;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - presstime > cooldown && loadscene != -1 && GlobalSet.LID!= "")
        {
            print(loadscene);
            
            SceneManager.LoadScene(loadscene);
        }
    }

    public void HoverIn(string Feature)
    {
        
        
            if (Feature == "CH1") mes.text = "單元1.生物多樣性";
            else if (Feature == "CH2") mes.text = "單元2.台灣的多樣化環境";
            else if (Feature == "CH3") mes.text = "單元3.生物生存適應";
            else if (Feature == "CH4") mes.text = "單元4.外來入侵種對台灣的影響";
            else if (Feature == "CH5") mes.text = "單元5.候鳥遷徙";
            else if (Feature == "CH6") mes.text = "單元6.淺山生態與石虎";
        
        
    }
    public void HoverOut(string Feature)
    {
        mes.text = "";
    }
    public void CheckSelect(string Feature)
    {
        //RightHand.Trigger.OnPressing = inputActions.XRIRightHandInteraction.Activate.ReadValue<float>() == 1 ? true : false;
        mes.text = Feature;
        if (Feature == "List")
        {
            SceneManager.LoadScene("List");
        }
        else if (Feature.Substring(0, 2) == "CH")
        {
            mes.text=Feature;
            GameObject.Find("SelectEffect").GetComponent<AudioSource>().Play();
            GameObject.Find(Feature).transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            loadscene = int.Parse(Feature.Substring(2, 1))+1;
            SceneManager.LoadScene(loadscene);
            WebPhp webPhp = FindObjectOfType<WebPhp>();
            if (GlobalSet.LID == "")
                StartCoroutine(webPhp.php(GlobalSet.SID, "-1", (loadscene - 1).ToString(), WebPhp.php_method.LevelInf));
            
        }
    }

    /*public void OnSelectEntered(SelectEnterEventArgs args)
    {
        mes.text = "YAAAA";
    }*/
}
