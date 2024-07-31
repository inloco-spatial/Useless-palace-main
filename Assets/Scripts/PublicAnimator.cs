
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PublicAnimator : UdonSharpBehaviour
{
    public Animator cubeAnimator;
    public string parEnterName;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        cubeAnimator.SetBool(parEnterName, true);
    }
    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        cubeAnimator.SetBool(parEnterName, false);
    }
}
