using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public ControllerMovement controller; 
    public int Last_Right_V = 0;
    public int[] Flippings;
    public bool Flipping;
    public int Flap_Speed = 5;
    private void Update()
    {
        State_Detect();

    }

    void State_Detect()
    {
        for (int i = 1; i < Flippings.Length; i++) Flippings[i] = Flippings[i - 1];

        if (controller.RightHandVelocity.x != 0 && controller.RightHandVelocity.x == controller.LeftHandVelocity.x)
            Flippings[0] = 1;
        else
            Flippings[0] = 0;

        Flipping = false;
        if (SumArray(Flippings) > Flap_Speed) Flipping = true;
    }

    private void Start()
    {
        Flippings = new int[10];

    }

    public int SumArray(int[] toBeSummed)
    {
        int sum = 0;
        foreach (int item in toBeSummed)
        {
            sum += item;
        }
        return sum;
    }
}
