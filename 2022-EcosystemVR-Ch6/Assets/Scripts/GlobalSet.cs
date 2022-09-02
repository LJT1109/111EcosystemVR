
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayMode))]
public class GlobalSet : MonoBehaviour
{
    

    public string SID;//學號
    public long EntryTime, ExitTime; // 進入和離開學習單元的時間
    public string ServerIP = "www.ylw.idv.tw:81"; //SQL ServerIP
    public bool NetworkMode; //true: 記錄在遠端  false: 記錄在本地
    public int[] Score;//各關卡分數

    public enum PlayMode
    {
        Auto,
        VR,
        PC
    }

    void Portfolio(string TargetName/*目標對象*/)
    {
        //單元 
        //按鈕狀態
        //時間~
    }



    //VR相關//

    public static XRIDefaultInputActions inputActions;
    


    public struct VRTrigger
    {
        public float Value; //按鈕值
        public bool OnPress;//當按下按鈕
        public bool OnPressing;//按鈕按著
        public bool OnLeave;//按鈕離開
    }

    public struct Hand
    {
        public Vector3 Position;//位置
        public Quaternion Rotation;//旋轉角度
        public bool ButtonA;//下按鈕
        public bool ButtonB;//上按鈕
        public VRTrigger Trigger;//食指板機
        public VRTrigger Grip;//抓握板機
    }
    public struct Head
    {
        public Vector3 Position;//位置
        public Quaternion Rotation;//旋轉角度

    }
    public static Hand LeftHand;//左手控制器
    public static Hand RightHand;//右手控制器
    public static Head HeadSet;//頭盔

    public static PlayMode playMode;
    public PlayMode SetMode = PlayMode.VR;

    private void Update()   
    {
        LeftHand.Position = inputActions.XRILeftHand.Position.ReadValue<Vector3>();
        LeftHand.Rotation = inputActions.XRILeftHand.Rotation.ReadValue<Quaternion>();
        LeftHand.Trigger.Value = inputActions.XRILeftHandInteraction.ActivateValue.ReadValue<float>();
        LeftHand.Trigger.OnPressing = inputActions.XRILeftHandInteraction.Activate.ReadValue<float>() == 1 ? true : false;
        LeftHand.Grip.Value = inputActions.XRILeftHandInteraction.SelectValue.ReadValue<float>();
        LeftHand.Grip.OnPressing = inputActions.XRILeftHandInteraction.Select.ReadValue<float>() == 1 ? true : false;
        LeftHand.ButtonA = inputActions.XRILeftHandInteraction.ButtonA.ReadValue<float>() == 1 ? true : false;
        //Debug.Log(LeftHand.ButtonA);
        LeftHand.ButtonB = inputActions.XRILeftHandInteraction.ButtonB.ReadValue<float>() == 1 ? true : false;


        RightHand.Position = inputActions.XRIRightHand.Position.ReadValue<Vector3>();
        RightHand.Rotation = inputActions.XRIRightHand.Rotation.ReadValue<Quaternion>();
        RightHand.Trigger.Value = inputActions.XRIRightHandInteraction.ActivateValue.ReadValue<float>();
        RightHand.Trigger.OnPressing = inputActions.XRIRightHandInteraction.Activate.ReadValue<float>() == 1 ? true : false;
        RightHand.Grip.Value = inputActions.XRIRightHandInteraction.SelectValue.ReadValue<float>();
        RightHand.Grip.OnPressing = inputActions.XRIRightHandInteraction.Select.ReadValue<float>() == 1 ? true : false;
        RightHand.ButtonA = inputActions.XRIRightHandInteraction.ButtonA.ReadValue<float>() == 1 ? true : false;
        RightHand.ButtonB = inputActions.XRIRightHandInteraction.ButtonB.ReadValue<float>() == 1 ? true : false;



        HeadSet.Position = inputActions.XRIHead.Position.ReadValue<Vector3>();
        HeadSet.Rotation = inputActions.XRIHead.Rotation.ReadValue<Quaternion>();
        playMode = SetMode;
    }

    private void Awake()
    {
        if (playMode == PlayMode.Auto && Application.platform == RuntimePlatform.Android)
        {
            SetMode = PlayMode.VR;
        }
        else if (playMode == PlayMode.Auto && Application.platform == RuntimePlatform.WindowsPlayer)
        {
            SetMode = PlayMode.PC;
        }
        playMode = SetMode;
        inputActions = new XRIDefaultInputActions();
        inputActions.Enable();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnDestroy()
    {
        inputActions.Dispose();
    }


}