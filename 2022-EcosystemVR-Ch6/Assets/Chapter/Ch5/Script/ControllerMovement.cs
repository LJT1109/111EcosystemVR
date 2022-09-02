using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{
    public int SampleCount = 20;
    public Vector3[] LeftPastPosition = new Vector3[30];
    public Vector3[] RightPastPosition = new Vector3[30];
    public float Offset = 0.001f;
    public Vector2 LeftHandVelocity, RightHandVelocity;
    private void Update()
    {
        for (int i = 0; i < SampleCount - 1; i++) LeftPastPosition[i + 1] = LeftPastPosition[i];
        LeftPastPosition[0] = GlobalSet.LeftHand.Position;
        LeftHandVelocity = GetVelocity();
        for (int i = 0; i < SampleCount - 1; i++) RightPastPosition[i + 1] = RightPastPosition[i];
        RightPastPosition[0] = GlobalSet.RightHand.Position;
        RightHandVelocity = GetVelocity2();
    }
        public Vector2 GetVelocity2()
    {
        float count_y = 0, count_z = 0;

        for (int i = 0; i < SampleCount - 1; i++)
        {
            count_y += RightPastPosition[i + 1].y - RightPastPosition[i].y;
            count_z += RightPastPosition[i + 1].z - RightPastPosition[i].z;
        }
        count_y /= SampleCount;
        count_z /= SampleCount;
        count_y = Mathf.Abs(count_y) < Offset ? 0 : count_y;
        count_z = Mathf.Abs(count_z) < Offset ? 0 : count_z;
        if (Mathf.Abs(count_y) - Mathf.Abs(count_z) > 0) //x 變量大於 z變量
        {
            if (count_y > 0) count_y = 1;
            else if (count_y == 0) count_y = 0;
            else count_y = -1;

            if (count_z > 0) count_z = 0.5f;
            else if (count_z == 0) count_z = 0;
            else count_z = -0.5f;
        }
        else
        {
            if (count_y > 0) count_y = 0.5f;
            else if (count_y == 0) count_y = 0;
            else count_y = -0.5f;

            if (count_z > 0) count_z = 1f;
            else if (count_z == 0) count_z = 0;
            else count_z = -1f;
        }




        return new Vector2(count_y, count_z);
    }    public Vector2 GetVelocity()
    {
        float count_y = 0, count_z = 0;

        for (int i = 0; i < SampleCount - 1; i++)
        {
            count_y += LeftPastPosition[i + 1].y - LeftPastPosition[i].y;
            count_z += LeftPastPosition[i + 1].z - LeftPastPosition[i].z;
        }
        count_y /= SampleCount;
        count_z /= SampleCount;
        count_y = Mathf.Abs(count_y) < Offset ? 0 : count_y;
        count_z = Mathf.Abs(count_z) < Offset ? 0 : count_z;
        if (Mathf.Abs(count_y) - Mathf.Abs(count_z) > 0) //x 變量大於 z變量
        {
            if (count_y > 0) count_y = 1;
            else if (count_y == 0) count_y = 0;
            else count_y = -1;

            if (count_z > 0) count_z = 0.5f;
            else if (count_z == 0) count_z = 0;
            else count_z = -0.5f;
        }
        else
        {
            if (count_y > 0) count_y = 0.5f;
            else if (count_y == 0) count_y = 0;
            else count_y = -0.5f;

            if (count_z > 0) count_z = 1f;
            else if (count_z == 0) count_z = 0;
            else count_z = -1f;
        }




        return new Vector2(count_y, count_z);
    }
}
