
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class HorsmentControl : UdonSharpBehaviour
{
    public VRCStation seat;
    public MountAnimal mainScript;
    //public VRCPlayerApi horsment;
    public override void OnStationEntered(VRCPlayerApi player)
    {
        
        if (player == Networking.LocalPlayer) { 
            Debug.Log("Im Seat!");
            mainScript.localHorsment = true;
        }
        mainScript.horsment = player;
        //Networking.SetOwner(Networking.LocalPlayer, mainScript.gameObject);
    }
    public override void OnStationExited(VRCPlayerApi player)
    {
        if (player == Networking.LocalPlayer)
        {
            Debug.Log("Im Seat!");
            mainScript.localHorsment = false;
        }
    }
    public void LateUpdate()
    {
        //if (Input.GetKey(KeyCode.F))
       
        {
           // seat.ExitStation(Networking.LocalPlayer);
        }
    }
    public void InputJump()
    {
        seat.ExitStation(Networking.LocalPlayer);
        mainScript.mountWalk = false;
        mainScript.animator.SetBool("Walk", mainScript.mountWalk);
        mainScript.mountWalkSide = 0;
        mainScript.animator.SetInteger("WalkSide", mainScript.mountWalkSide);
        mainScript.RequestSerialization();
    }
}
