using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GetInput : MonoBehaviour
{
    public enum ControllerType
    {
        None,
        Vive,
        Index
    }

    //public Text content = null;
    public ControllerType controllerType = ControllerType.None;

    private XRController controller = null;

    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    private void Update()
    {
        if (controllerType == ControllerType.Vive)
            ViveInput();

        if (controllerType == ControllerType.Index)
            IndexInput();
    }

    private void ViveInput()
    {
        string output = string.Empty;

        // Menu Button
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool menuButton))
            output += "Menu Button: " + menuButton + "\n";

        // Touchpad touch
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool touch))
            output += "Touchpad Touch: " + touch + "\n";

        // Touchpad press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool press))
            output += "Touchpad Pressed: " + press + "\n";

        // Touchpad position
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            output += "Touchpad Position: " + position + "\n";

        // Grip press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool grip))
            output += "Grip Pressed: " + grip + "\n";

        // Trigger press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool trigger))
            output += "Trigger Pressed: " + trigger + "\n";

        // Trigger amount
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerAmount))
            output += "Trigger: " + triggerAmount;
        Debug.Log(output);
       // content.text = output;
    }

    private void IndexInput()
    {
        string output = string.Empty;

        // A Button - Should be primary?
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool primary))
            output += "A Pressed: " + primary + "\n";

        // B Button - Should be secondary?
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool secondary))
            output += "B Pressed: " + secondary + "\n";

        // Touchpad/Joystick touch
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool touch))
            output += "Touchpad/Joystick Touch: " + touch + "\n";

        // Touchpad/Joystick press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool press))
            output += "Touchpad/Joystick Pressed: " + press + "\n";

        // Touchpad/Joystick position
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            output += "Touchpad/Joystick Position: " + position + "\n";

        // Grip press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool grip))
            output += "Grip Pressed: " + grip + "\n";

        // Grip amount
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripAmount))
            output += "Grip Amount: " + gripAmount + "\n";

        // Trigger press
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool trigger))
            output += "Trigger Pressed: " + trigger + "\n";

        // Index/Trigger amount
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerAmount))
            output += "Trigger: " + triggerAmount;
        Debug.Log(output);
       // content.text = output;
    }

    /*public UnityEngine.XR.InputDevice leftHand_device;

    private void OnEnable()
    {
        get_left_hand();
    }

    public void get_left_hand()
    {
        var leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);
        foreach (var device in leftHandedControllers)
        {
            leftHand_device = device;
        }
    }

    public void Allinput_device_record()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
    }

    public void update_inputDynamic_record()
    {
        bool triggerValue;
        if (leftHand_device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out triggerValue) && triggerValue)
        {
            Debug.Log("234");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        update_inputDynamic_record();
    }*/
}
