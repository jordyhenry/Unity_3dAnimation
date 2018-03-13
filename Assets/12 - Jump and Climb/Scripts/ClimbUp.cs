using UnityEngine;
using System.Collections;

public class ClimbUp : MonoBehaviour 
{
    float speed = 5.0F;
    float rotationSpeed = 100.0F;
    float lerpSpeed = 5.0F;
    Animator anim;
    bool isHanging = false;
    bool isShimmy=false;
    Transform animRootTarget;

    void Start()
    {
    	anim = this.GetComponent<Animator>();
        animRootTarget = null;
    }

    void Update() 
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        
        if(!isHanging)
            transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
        	anim.SetBool("isWalking",true);
            anim.SetFloat("speed",translation * 0.5f);
        }
        else
        {
        	anim.SetBool("isWalking",false);
            anim.SetFloat("speed",0);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            if(isHanging){
               anim.SetTrigger("dropEdge");
               GetComponent<Rigidbody>().isKinematic = false;
               animRootTarget = null; 
            }else{
                anim.SetTrigger("isJumping");
            }
        }

        if(isHanging){
            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                anim.SetTrigger("shimmyLeft");
                isShimmy = true;
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                anim.SetTrigger("shimmyRight");
                isShimmy = true;
            }
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                anim.SetTrigger("isClimbing");
                animRootTarget = null;
            }
        }

    }
    void FixedUpdate()
    {
        AnimLerp();
    }

    void AnimLerp()
    {
        if(!animRootTarget || isShimmy) return;
   
        if (Vector3.Distance(this.transform.position,animRootTarget.position) > 0.1f)
        {
            this.transform.rotation = Quaternion.Lerp(transform.rotation, 
                                                 animRootTarget.rotation, 
                                                 Time.deltaTime * lerpSpeed);
            this.transform.position = Vector3.Lerp(transform.position, 
                                              animRootTarget.position, 
                                              Time.deltaTime * lerpSpeed);
         }
         else
         {
            this.transform.position = animRootTarget.position;
            this.transform.rotation = animRootTarget.rotation;
         }
        
    }

    public void GrabEdge(Transform rootTarget)
    {
        if(isHanging) return;

        anim.SetTrigger("grabEdge");
        GetComponent<Rigidbody>().isKinematic = true;
        isHanging = true;
        animRootTarget = rootTarget;

        AlignAnchor();
    }

    public void StandindUp()
    {
        isHanging = false;
        GetComponent<Rigidbody>().isKinematic = false;
        animRootTarget = null;
    }

    public void EndShimmy()
    {
        isShimmy = false;
        AlignAnchor();
    }

    void AlignAnchor()
    {
        Plane rootPlane = new Plane(
            animRootTarget.position, 
            animRootTarget.position + animRootTarget.right,
            animRootTarget.position + animRootTarget.up
        );

        Vector3 adjustedPos = transform.position;
        adjustedPos.y = animRootTarget.position.y;

        Ray ray = new Ray(adjustedPos - animRootTarget.forward, animRootTarget.forward);
        float rayDistance;
        if(rootPlane.Raycast(ray, out rayDistance))
            animRootTarget.position = ray.GetPoint(rayDistance);
    }
}
