using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using PathCreation.Examples;
using Random=UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    WebPhp web;
    public GameObject SelectMenu;

    public GameObject Ch1_1;
    public GameObject Ch1_2;
    public GameObject Ch2_1;
    public GameObject Ch2_2;
    public GameObject Ch2_3;
    public GameObject Ch2_4;
    public GameObject Terrain;
    public GameObject IceTerrain;
    public GameObject Terrain2_1;
    public GameObject Terrain2_2;
    public GameObject Terrain2_3;
    public GameObject Terrain2_4;

    public GameObject TemRain;
    public Text TargetText;
    public Text AnswerText;
    public Text TipText;
    public Text InfoText;
    public GameObject AnsButton1;
    public GameObject AnsButton2;
    public GameObject AnsButton3;
    public GameObject AnsButton4;
    public int ChNum = 0;
    public int QuestionCount = 0;

    public GameObject Note;
    bool ButtonAState = false;
    bool NoteOpen = false;

    bool LionHair = false;
    bool LionTeeth = false;
    bool ZebraLines = false;
    bool ZebraFoot = false;
    public GameObject Lion;
    public GameObject Zebra;
    public GameObject LionHairGameObject;
    public GameObject LionTeethGameObject;
    public GameObject ZebraLinesGameObject;
    public GameObject ZebraFootGameObject;
    public Animator LionAn;
    public Animator ZebraAn;

    public GameObject Bear;
    public GameObject Penguin;
    public GameObject PenguinFa;
    public GameObject Sealdog;
    public GameObject SealdogSkinGameObject;
    public GameObject BearHairGameObject;
    public GameObject PenguinFeatherGameObject;
    public Animator BearAn;
    public Animator SealdogAn;
    public Animation PenguinAn;

    public GameObject Oncorhynchus;
    public GameObject OncorhynchusLinesGameObject;
    public Animator OncorhynchusAn;

    bool CatFace = false;
    bool CatLines = false;
    public GameObject Cat;
    public GameObject CatFaceGameObject;
    public GameObject CatLinesGameObject;
    public Animator CatAn;

    bool BirdMouth = false;
    bool BirdFeather = false;
    public GameObject Bird;
    public GameObject BirdMouthGameObject;
    public GameObject BirdFeatherGameObject;
    public Animator BirdAn;
    public GameObject Crab;
    public GameObject CrabTombGameObject;
    public Animator CrabAn;
    public GameObject Mudskipper;
    public GameObject MudskipperSkinGameObject;
    public Animator MudskipperAn;

    public GameObject Fish;
    public GameObject FishColorGameObject;
    public Animator FishAn;

    public static int finalgame = 1;
    public bool Ch1_1Complete = false;
    public bool Ch1_2Complete = false;
    public int Ch2Complete = 0;
    public GameObject EnterButton;

    public GameObject Thermometer;
    public Text ThermometerText;
    public Text RainText;

    public GameObject RightHandController;
    public GameObject LeftHandController;

    public bool Wait = false;

    public string[][] TemAndRainArr = {new string [] {"24℃", "300mm"}
    , new string[] {"-20℃", "150mm"}
    , new string[] {"", ""}
    , new string[] {"", ""}
    , new string[] {"", ""}
    , new string[] {"", ""}};

    public string[][] QuestionArr = {
    new string[] {"現在的環境感覺如何？" //0 草原
    , "觀察看看附近的植物有甚麼特徵？"
    , "你覺得斑馬有哪些特徵呢？"
    , "你覺得獅子有哪些特徵呢？"
    }, new string[] {"現在的環境感覺如何？" //1 極地
    , "四周環境有什麼特別的地方嗎？"
    , "北極熊有甚麼特徵呢？"
    , "海豹有甚麼特徵呢？"
    , "企鵝有甚麼特徵呢？"
    }, new string[] {"現在的環境感覺如何？" //2 高山
    , "移動你的視線，觀察看看環境有什麼特徵？"
    , "仔細看一下櫻花鉤吻鮭的外型有什麼特徵？"
    }, new string[] {"現在的環境感覺如何？" //3 淺山
    , "移動你的視線，觀察看看環境有什麼特徵？"
    , "你覺得石虎有哪些特徵呢？"
    }, new string[] {"現在的環境感覺如何？" //4 濕地
    , "移動你的視線，觀察看看環境有什麼特徵？"
    , "你覺得黑面琵鷺有哪些特徵呢？"
    , "你覺得招潮蟹有哪些特徵呢？"
    , "你覺得彈塗魚有哪些特徵呢？"
    }, new string[] {"現在的環境感覺如何？" //5 珊瑚礁
    , "移動你的視線，觀察看看環境有什麼特徵？"
    , "你覺得熱帶魚有哪些特徵呢？"
    }};

    public string[][] AnswerArr = {new string[] 
    {"乾燥", "樹很少", "", ""}
    , new string[] {"寒冷","冰雪覆蓋","","",""}
    , new string[] {"", "", ""}
    , new string[] {"", "", ""}
    , new string[] {"", "", "", "", ""}
    , new string[] {"", "", ""}};

    public string[][][] OptionArr = {new string[][] {new string[] {"乾燥", "潮濕", "熱"}
    , new string[] {"樹很多", "樹很少", "地形崎嶇"}
    , new string[] {""}
    , new string[] {""}
    }, new string[][] {new string[] {"炎熱", "舒爽", "寒冷"}
    , new string[] {"冰雪覆蓋", "綠意盎然", "沙漠地形"}
    , new string[] {""}
    , new string[] {""}
    , new string[] {""}
    }, new string[][] {new string[] {"","",""}}};

    void Start()
    {
        if (ChNum == 0 || ChNum == 1)
        {
            SelectMenu.SetActive(true);
        }
        else if (ChNum == 2)
        {

        }
        web = GetComponent<WebPhp>();
        PenguinAn = Penguin.GetComponent<Animation>();
        /*PenguinFa.transform.position = new Vector3(242, -0.5f, 100);
        PenguinFa.transform.LookAt(new Vector3(239.53f, -0.5f, 98.3f));*/
    }

    void Update()
    {
        if (ZebraFoot == true && ZebraLines == true)
        {
            ZebraFoot = false;
            ZebraLines = false;
            ZebraFootGameObject.SetActive(false);
            ZebraLinesGameObject.SetActive(false);
            LionHairGameObject.SetActive(true);
            LionTeethGameObject.SetActive(true);
            QuestionCount++;
            TargetText.text = QuestionArr[ChNum][QuestionCount];
        }
        if (LionHair == true && LionTeeth == true)
        {
            LionHair = false;
            LionTeeth = false;
            LionHairGameObject.SetActive(false);
            LionTeethGameObject.SetActive(false);
            Ch1_1Complete = true;
            if (Ch1_2Complete != true)
            {
                TargetText.text = "觀察完草原的生態了";
                TipText.text = "接下來觀察極地的生態吧！";
                Invoke("SelectIce", 2);
            }
        }
        if (CatFace == true && CatLines == true)
        {
            CatFace = false;
            CatLines = false;
            CatFaceGameObject.SetActive(false);
            CatLinesGameObject.SetActive(false);
        }
        if (Ch1_1Complete == true && Ch1_2Complete == true)
        {
            Ch1_1Complete = false;
            Ch1_2Complete = false;
            TargetText.text = "接下來我們來玩個小遊戲吧！";
            TipText.text = "";
            Invoke("ShowEnterButton", 2);
        }
        if (GameController.Score1 == 2)
        {
            TargetText.text = "按下確認進入下一階段";
            TipText.text = "";
            GameController.Score1 = 100;
            Invoke("ShowEnterButton", 2);
        }
        if (GameController.Score2 == 3)
        {
            TargetText.text = "";
            TipText.text = "";
            Invoke("ShowCongraText", 2);
        }
        
        if (GlobalSet.RightHand.ButtonA != ButtonAState && GlobalSet.RightHand.ButtonA == true)
        {
            if (NoteOpen == false)
            {
                Note.SetActive(true);
                NoteOpen = true;
            }
            else
            {
                Note.SetActive(false);
                NoteOpen = false;
            }
        }
        ButtonAState = GlobalSet.RightHand.ButtonA;
    }

    public void ShowCongraText()
    {
        AnswerText.text = "恭喜完成第一章節！";
    }

    public void ShowEnterButton()
    {
        InfoText.text = "";
        EnterButton.SetActive(true);
        EnterButton.GetComponentInChildren<Text>().text = "確認";
    }

    public void ShowFirstQuestion()
    {
        
        TemRain.SetActive(true);
        QuestionCount = 0;
        AnsButton1.SetActive(true);
        AnsButton2.SetActive(true);
        AnsButton3.SetActive(true);
        if (ChNum == 0)
        {
            StartCoroutine(web.php("ch1test", "1", "3", WebPhp.php_method.Action));
            ThermometerText.text = TemAndRainArr[ChNum][0];
            RainText.text = TemAndRainArr[ChNum][1];
        }
        else if (ChNum == 1)
        {
            StartCoroutine(web.php("ch1test", "1", "9", WebPhp.php_method.Action));
            ThermometerText.text = TemAndRainArr[ChNum][0];
            RainText.text = TemAndRainArr[ChNum][1];
        }
        TargetText.text = QuestionArr[ChNum][QuestionCount];
        TipText.text = "觀察看看畫面上的溫度計及降雨量！";
        AnsButton1.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][0];
        AnsButton2.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][1];
        AnsButton3.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][2];
        if (OptionArr[ChNum][QuestionCount].Length == 4)
        {
            AnsButton4.SetActive(true);
            AnsButton4.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][3];
        }
        else
        {
            AnsButton4.SetActive(false);
        }
    }

    public void ShowNextQuestion()
    {
        TemRain.SetActive(false);
        AnsButton1.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][0];
        AnsButton2.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][1];
        AnsButton3.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][2];
        if (OptionArr[ChNum][QuestionCount].Length == 4)
        {
            AnsButton4.SetActive(true);
            AnsButton4.GetComponentInChildren<Text>().text = OptionArr[ChNum][QuestionCount][3];
        }
        else
        {
            AnsButton4.SetActive(false);
        }
        TargetText.text = QuestionArr[ChNum][QuestionCount];
    }

    public void CheckAnswer()
    {
        if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text == AnswerArr[ChNum][QuestionCount])
        {
            AnswerText.text = "";
            if (QuestionCount + 1 < QuestionArr[ChNum].Length)
            {
                QuestionCount++;
                if (QuestionArr[ChNum][QuestionCount] == "你覺得斑馬有哪些特徵呢？")
                {
                    StartCoroutine(web.php("ch1test", "1", "4", WebPhp.php_method.Action));
                    CheckAnimal();
                    ZebraFootGameObject.SetActive(true);
                    ZebraLinesGameObject.SetActive(true);
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "北極熊有甚麼特徵呢？")
                {
                    StartCoroutine(web.php("ch1test", "1", "10", WebPhp.php_method.Action));
                    CheckAnimal();
                    BearHairGameObject.SetActive(true);
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "仔細看一下櫻花鉤吻鮭的外型有什麼特徵？")
                {
                    StartCoroutine(web.php("ch1test", "1", "20", WebPhp.php_method.Action));
                    CheckAnimal();
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "你覺得石虎有哪些特徵呢？")
                {
                    StartCoroutine(web.php("ch1test", "1", "23", WebPhp.php_method.Action));
                    CheckAnimal();
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "你覺得黑面琵鷺有哪些特徵呢？")
                {
                    StartCoroutine(web.php("ch1test", "1", "27", WebPhp.php_method.Action));
                    CheckAnimal();
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else if (QuestionArr[ChNum][QuestionCount] == "你覺得熱帶魚有哪些特徵呢？")
                {
                    StartCoroutine(web.php("ch1test", "1", "33", WebPhp.php_method.Action));
                    CheckAnimal();
                    AnsButton1.SetActive(false);
                    AnsButton2.SetActive(false);
                    AnsButton3.SetActive(false);
                    AnsButton4.SetActive(false);
                }
                else
                {
                    ShowNextQuestion();
                }
            }
            else
            {

            }
        }
        else
        {
            AnswerText.text = "回答錯誤";
            Invoke("EraseFeatureError", 2f);
        }
        Debug.Log(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
    }

    public void CheckAnimal()
    {
        if (ChNum == 0)
        {
            LionAn.Play("run");
            ZebraAn.Play("run");
            Lion.GetComponent<PathFollower>().enabled = true;
            Zebra.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "是斑馬和獅子出現了！";
        }
        else if (ChNum == 1)
        {
            BearAn.Play("run");
            SealdogAn.Play("run");
            Bear.GetComponent<PathFollower>().enabled = true;
            Sealdog.GetComponent<PathFollower>().enabled = true;
            TargetText.text = "是海豹和北極熊出現了！";
        }
        else if (ChNum == 2)
        {
            if (Ch2Complete == 0)
            {
                Oncorhynchus.GetComponent<PathFollower>().enabled = true;
                TargetText.text = "是櫻花鉤吻鮭出現了！";
            }
            else if (Ch2Complete == 1)
            {
                CatAn.Play("run");
                Cat.GetComponent<PathFollower>().enabled = true;
                TargetText.text = "是石虎出現了！";
            }
            else if (Ch2Complete == 2)
            {
                BirdAn.Play("fly");
                Bird.GetComponent<PathFollower>().enabled = true;
                TargetText.text = "是黑面琵鷺出現了！";
            }
            else if (Ch2Complete == 3)
            {
                Fish.GetComponent<PathFollower>().enabled = true;
                TargetText.text = "是熱帶魚出現了！";
            }
        }
        TipText.text = "拿出你的放大鏡觀察看看。";
        Invoke("AnStop", 6.5f);
    }

    public void AnStop()
    {
        if (ChNum == 0)
        {
            LionAn.Play("idle");
            ZebraAn.Play("idle");
            Lion.GetComponent<PathFollower>().enabled = false;
            Zebra.GetComponent<PathFollower>().enabled = false;
            Zebra.transform.LookAt(new Vector3(239.5f, 0.26f, 102f));
            Lion.transform.LookAt(new Vector3(239.6f, 0.26f, 94f));
        }
        else if (ChNum == 1)
        {
            BearAn.Play("idle");
            SealdogAn.Play("idle");
            PenguinAn.Play("idle");
            Bear.GetComponent<PathFollower>().enabled = false;
            Sealdog.GetComponent<PathFollower>().enabled = false;
            PenguinFa.GetComponent<PathFollower>().enabled = false;
            Sealdog.transform.LookAt(new Vector3(239.5f, 0.26f, 102f));
            Bear.transform.LookAt(new Vector3(239.6f, 0.26f, 94f));
            PenguinFa.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        }
        else if (ChNum == 2)
        {
            if (Ch2Complete == 0)
            {
                Oncorhynchus.GetComponent<PathFollower>().enabled = false;
                Oncorhynchus.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            }
            else if (Ch2Complete == 1)
            {
                CatAn.Play("idle");
                Cat.GetComponent<PathFollower>().enabled = false;
                Cat.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            }
            else if (Ch2Complete == 2)
            {
                BirdAn.Play("idle");
                Bird.GetComponent<PathFollower>().enabled = false;
                Bird.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
                CrabAn.Play("idle");
                Crab.GetComponent<PathFollower>().enabled = false;
                Crab.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
                MudskipperAn.Play("idle");
                Mudskipper.GetComponent<PathFollower>().enabled = false;
                Mudskipper.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
            }
            else if (Ch2Complete == 3)
            {

            }
        }
        TargetText.text = QuestionArr[ChNum][QuestionCount];
        TipText.text = "先按下右手的抓握再按下板機。";
    }

    public void EraseFeatureError()
    {
        AnswerText.text = "";
    }

    public void CheckAnimalFeature(string Feature)
    {
        if (ChNum == 0 || ChNum == 1)
        {
            if (Feature == "LionHair")
            {
                StartCoroutine(web.php("ch1test", "1", "7", WebPhp.php_method.Action));
                InfoText.text = "通常只有雄性的獅子脖子上會有鬃毛，是為了可以在打鬥中保護自己的頭部和脖子。";
                LionHair = true;
            }
            if (Feature == "LionTeeth")
            {
                StartCoroutine(web.php("ch1test", "1", "8", WebPhp.php_method.Action));
                InfoText.text = "雄性獅子會有銳利的牙齒以及爪子，方便牠們狩獵使用。";
                LionTeeth = true;
            }
            if (Feature == "ZebraLines")
            {
                StartCoroutine(web.php("ch1test", "1", "5", WebPhp.php_method.Action));
                InfoText.text = "斑馬身上的黑白紋路可以混淆斑馬的天敵的視覺，讓他沒辦法鎖定獵物。同時黑白相間的紋路還可以調節身體的溫度呢！";
                ZebraLines = true;
            }
            if (Feature == "ZebraFoot")
            {
                StartCoroutine(web.php("ch1test", "1", "6", WebPhp.php_method.Action));
                InfoText.text = "斑馬的蹄可以讓牠在草原環境裡更快速的移動，避免被牠的天敵獵捕。";
                ZebraFoot = true;
            }
            if (Feature == "BearHair")
            {
                StartCoroutine(web.php("ch1test", "1", "11", WebPhp.php_method.Action));
                InfoText.text = "北極熊的毛可以防止水分滲入，達到禦寒的效果，同時皮膚底下有一層極厚的皮下脂肪加強保暖。";
                BearHairGameObject.SetActive(false);
                SealdogSkinGameObject.SetActive(true);
                QuestionCount++;
                TargetText.text = QuestionArr[ChNum][QuestionCount];
                TipText.text = "先按下右手的抓握再按下板機。";
            }
            if (Feature == "SealdogSkin")
            {
                StartCoroutine(web.php("ch1test", "1", "12", WebPhp.php_method.Action));
                InfoText.text = "海豹有一層用來保暖的厚厚的皮下脂肪，並提供食物儲備，並產生浮力，讓牠可以漂浮在水面上。";
                SealdogSkinGameObject.SetActive(false);
                Bear.SetActive(false);
                Sealdog.SetActive(false);
                Invoke("PenguinGo", 2);
            }
            if (Feature == "PenguinFeather")
            {
                StartCoroutine(web.php("ch1test", "1", "13", WebPhp.php_method.Action));
                InfoText.text = "企鵝身上的羽毛，具備防水、防風的功能。而且牠也有厚達2到3公分的皮下脂肪，可以讓企鵝保持體溫。";
                PenguinFeatherGameObject.SetActive(false);
                Ch1_2Complete = true;
                if (Ch1_1Complete == false)
                {
                    TargetText.text = "觀察完極地的生態了";
                    TipText.text = "接下來觀察草原的生態吧！";
                    Invoke("SelectGrassland", 2);
                }
            }
        }
        else if (ChNum == 2)
        {
            
        }
        
    }

    public void PenguinGo()
    {
        PenguinAn.Play("run");
        PenguinFa.GetComponent<PathFollower>().enabled = true;
        QuestionCount++;
        TargetText.text = "是企鵝出現了！";
        TipText.text = "拿出你的放大鏡觀察看看。";
        InfoText.text = "";
        Invoke("AnStop", 6.5f);
    }

    public void SelectGrassland()
    {
        StartCoroutine(web.php("ch1test", "1", "1", WebPhp.php_method.Action));
        ChNum = 0;
        InfoText.text = "";
        Ch1_1.SetActive(true);
        Ch1_2.SetActive(false);
        SelectMenu.SetActive(false);
        ShowFirstQuestion();
    }

    public void SelectIce()
    {
        StartCoroutine(web.php("ch1test", "1", "2", WebPhp.php_method.Action));
        ChNum = 1;
        InfoText.text = "";
        Ch1_1.SetActive(false);
        Ch1_2.SetActive(true);
        SelectMenu.SetActive(false);
        ShowFirstQuestion();
    }

    public void Game()
    {
        StartCoroutine(web.php("ch1test", "1", "14", WebPhp.php_method.Action));
        GameController.Reset();
        EnterButton.SetActive(false);
        TargetText.text = "請選出適合在此環境中生存的動物";
        TipText.text = "用右手將動物抓起吧！";
        if (GameController.Score1 == 0)
        {
            Ch1_1.SetActive(true);
            Ch1_2.SetActive(true);
            Terrain.SetActive(true);
            IceTerrain.SetActive(false);
        }
        else if (GameController.Score1 == 100)
        {
            GameController.Score1 = 0;
            finalgame = 2;
            Ch1_1.SetActive(true);
            Ch1_2.SetActive(true);
            Terrain.SetActive(false);
            IceTerrain.SetActive(true);
            Lion.SetActive(false);
            Zebra.SetActive(false);
            Bear.SetActive(false);
            Penguin.SetActive(false);
            Sealdog.SetActive(false);
        }
        Lion.SetActive(true);
        Zebra.SetActive(true);
        Bear.SetActive(true);
        Penguin.SetActive(true);
        Sealdog.SetActive(true);
        Lion.GetComponent<PathFollower>().enabled = false;
        Zebra.GetComponent<PathFollower>().enabled = false;
        Bear.GetComponent<PathFollower>().enabled = false;
        Sealdog.GetComponent<PathFollower>().enabled = false;
        PenguinFa.GetComponent<PathFollower>().enabled = false;
        Zebra.transform.position = new Vector3(242, -0.2f, 102);
        Lion.transform.position = new Vector3(240, -0.2f, 102);
        Sealdog.transform.position = new Vector3(241, 2f, 95);
        Bear.transform.position = new Vector3(245, -0.2f, 95);
        PenguinFa.transform.position = new Vector3(242, -0.2f, 100);
        Penguin.transform.localPosition = new Vector3(0, 0, 0);
        Lion.GetComponent<XRGrabInteractable>().enabled = true;
        Zebra.GetComponent<XRGrabInteractable>().enabled = true;
        Bear.GetComponent<XRGrabInteractable>().enabled = true;
        Sealdog.GetComponent<XRGrabInteractable>().enabled = true;
        Penguin.GetComponent<XRGrabInteractable>().enabled = true;
        Lion.GetComponent<BoxCollider>().enabled = true;
        Zebra.GetComponent<BoxCollider>().enabled = true;
        Bear.GetComponent<BoxCollider>().enabled = true;
        Sealdog.GetComponent<BoxCollider>().enabled = true;
        Penguin.GetComponent<BoxCollider>().enabled = true;
        LionAn.Play("idle", 0, 0f);
        ZebraAn.Play("idle", 0, 0f);
        BearAn.Play("idle", 0, 0f);
        SealdogAn.Play("idle", 0, 0f);
        PenguinAn.Play("idle");
        LookAtCamera();
    }
    
    public void LookAtCamera()
    {
        Zebra.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        Lion.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        Sealdog.transform.LookAt(new Vector3(239.53f, 2, 98.3f));
        Bear.transform.LookAt(new Vector3(239.53f, 0, 98.3f));
        PenguinFa.transform.LookAt(new Vector3(239.53f, -0.5f, 98.3f));
    }
}
