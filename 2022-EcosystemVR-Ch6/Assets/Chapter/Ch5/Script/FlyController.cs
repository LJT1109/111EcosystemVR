using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    public Vector3 RotateVector;
    public float RotateAngle;
    public float Speed;
    public float BalanceOffset;
    public float MaxRotateAngle = 0.3f;
    public GameObject XR;

    private void Start()
    {
        animator.SetTrigger("StartFly");
        animator.SetBool("Fly", true);
    }

    private void Update()
    {
       
        
        
        Vector3 Vec()
        {
            Vector2 a = new Vector2(GlobalSet.LeftHand.Position.x - GlobalSet.RightHand.Position.x, GlobalSet.LeftHand.Position.y - GlobalSet.RightHand.Position.y);
            a = a.normalized;
            return new Vector3(0,0,-a.y); 
        }
        Vector3 now = Vec();
        if (Player.transform.rotation.z >= -MaxRotateAngle && now.z <0)
        Player.transform.Rotate(now);
        
        if(Player.transform.rotation.z <= MaxRotateAngle && now.z > 0)
        Player.transform.Rotate(now);

        Player.transform.Translate((Player.transform.forward + new Vector3(Player.transform.up.x, 0f, 0f)).normalized * Speed);
        if (Player.transform.position.y < 0) Player.transform.Translate(new Vector3(0,-Player.transform.position.y,0) * 1f);
        if (Player.transform.position.y > 0) Player.transform.Translate(new Vector3(0, -Player.transform.position.y, 0) * 1f);
        //XR.transform.Translate((Player.transform.forward + new Vector3(Player.transform.up.x, 0f, 0f)).normalized * Speed   );
        //Debug.Log(Player.transform.up);
        //Debug.Log(Player.transform.rotation);
        //Debug.Log((Player.transform.forward + new Vector3(Player.transform.up.x, 0f, 0f)).normalized);

    }

    Vector3 RM_Z(Vector3 vector)
    {
        return new Vector3(vector.x, vector.y, 0f);
    }
}
