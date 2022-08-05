using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mode_Switch))]
public class GlobalSet : MonoBehaviour
{
    

    public string SID;//�Ǹ�
    public long EntryTime, ExitTime; // �i�J�M���}�ǲ߳椸���ɶ�
    public string ServerIP = ""; //SQL ServerIP
    public bool NetworkMode; //true: �O���b����  false: �O���b���a
    public int[] Score;//�U���d����

    public enum PlayMode
    {
        Auto,
        VR,
        PC
    }

    void Portfolio(string TargetName/*�ؼй�H*/)
    {
        //�椸 
        //���s���A
        //�ɶ�~
    }



    //VR����//

    public static XRIDefaultInputActions inputActions;
    


    public struct VRTrigger
    {
        public float Value; //���s��
        public bool OnPress;//����U���s
        public bool OnPressing;//���s����
        public bool OnLeave;//���s���}
    }

    public struct Hand
    {
        public Vector3 Position;//��m
        public Quaternion Rotation;//���ਤ��
        public bool ButtonA;//�U���s
        public bool ButtonB;//�W���s
        public VRTrigger Trigger;//�����O��
        public VRTrigger Grip;//�촤�O��
    }
    public struct Head
    {
        public Vector3 Position;//��m
        public Quaternion Rotation;//���ਤ��

    }
    public static Hand LeftHand;//���ⱱ�
    public static Hand RightHand;//�k�ⱱ�
    public static Head HeadSet;//�Y��

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
