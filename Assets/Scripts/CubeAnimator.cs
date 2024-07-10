
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CubeAnimator : UdonSharpBehaviour
{
    public Animator cubeAnimator;
    public string parEnterName;
    
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if(player==Networking.LocalPlayer) cubeAnimator.SetBool(parEnterName, true);
    }
    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (player == Networking.LocalPlayer) cubeAnimator.SetBool(parEnterName, false);
    }
}
