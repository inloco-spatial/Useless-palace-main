
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MountAnimal : UdonSharpBehaviour
{
    private bool vrMode;
    public bool localHorsment;
    public Rigidbody mainMount;
    public Vector3 moveDirection;
    public float maxRotate;
    public float maxVelocity;
    public float speed;
    public float rotation;
    public GameObject seatTarget;
    public float dempfValue;

    public Animator animator;
    public VRCStation seat;
    public VRCPlayerApi horsment;

    [UdonSynced] public bool mountWalk;
    [UdonSynced] public int mountWalkSide;
    void Start()
    {
        mainMount.maxAngularVelocity = maxRotate;
        mainMount.maxLinearVelocity = maxVelocity;
        if (Networking.LocalPlayer.IsUserInVR())
        {
            vrMode=true;
        }
    }
    public void LateUpdate()
    {
        ControllerDesktop();
        if (vrMode)
        {
            //ControllerVR();
        }
        else
        {
            
        }

        Vector3 seatPoint=  Vector3.Lerp(seat.transform.position,seatTarget.transform.position, dempfValue);
        seat.transform.position = seatPoint;
    }

    private void ControllerDesktop()
    {

        if (!localHorsment) return;

        Vector3 movmentVector= mainMount.transform.TransformDirection(Vector3.forward);
        

        mountWalk = false;
        animator.SetBool("Walk", mountWalk);
        mountWalkSide = 0;
        animator.SetInteger("WalkSide", mountWalkSide);
        //if (Input.GetKey(KeyCode.W))
        if (Input.GetAxis("Vertical") > 0)
        {
            if (Networking.GetOwner(this.gameObject) != Networking.LocalPlayer)
            {
                Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
            }

            mainMount.MovePosition(mainMount.position + movmentVector * speed * Time.deltaTime);

            mountWalkSide = 0;
            mountWalk = true;
            animator.SetBool("Walk", mountWalk);            
            
            
        }
        //if (Input.GetKey(KeyCode.A))
        if (Input.GetAxis("Horizontal") < 0)
        {
            mainMount.rotation = Quaternion.Euler(0, mainMount.rotation.eulerAngles.y + (-rotation) * Time.deltaTime * speed, 0);

            mountWalkSide = 1;
            animator.SetInteger("WalkSide", mountWalkSide);
        }
        //if (Input.GetKey(KeyCode.D))
        if(Input.GetAxis("Horizontal")>0)
        {
            mainMount.rotation = Quaternion.Euler(0, mainMount.rotation.eulerAngles.y + rotation * Time.deltaTime * speed, 0);
            mountWalkSide = 2;
            animator.SetInteger("WalkSide", mountWalkSide);
        }
        RequestSerialization();
    }
    private void ControllerVR()
    {
        //Input.GetAxis("Horizontal")

        
    }
    public override void OnDeserialization()
    {
        animator.SetBool("Walk", mountWalk);
        animator.SetInteger("WalkSide", mountWalkSide);

    }
}
