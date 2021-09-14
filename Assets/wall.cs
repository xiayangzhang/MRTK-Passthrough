using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
public class wall : MonoBehaviour
{

    public wall LeftWall;
    public wall RightWall;

    public bool Editing = false;
    
    private void Update()
    {
        if (Editing == true)
        {
            updateWallPos();
        }
    }

    private void updateWallPos()
    {
        Vector3 leftPos, rightPos;
        leftPos = handTransform(Handedness.Left);
        rightPos = handTransform(Handedness.Right);


        if (leftPos != Vector3.zero && rightPos != Vector3.zero)
        {
            transform.position = Vector3.Lerp(leftPos, rightPos,0.5f);
            transform.LookAt(leftPos);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }

    Vector3 handTransform(Handedness hand)
    {
        List<MixedRealityPose> Pose = new List<MixedRealityPose>();
        MixedRealityPose thumbTip,IndexTip,MiddleTip,RingTip,PinkTip;

        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, hand, out thumbTip))        
            Pose.Add(thumbTip);

        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, hand, out IndexTip))        
            Pose.Add(IndexTip);

        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, hand, out MiddleTip))       
            Pose.Add(MiddleTip);

        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip,hand, out RingTip))        
            Pose.Add(RingTip);

        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, hand, out PinkTip))       
            Pose.Add(PinkTip);
            
        Debug.Log(Pose.Count);
        if (Pose.Count <= 0)
        {
            return Vector3.zero;
        } else
        {
            Transform WallTransform = this.transform;
            Debug.Log(hand);

            Vector3 handAVG =new Vector3(
                Pose.Average(x=>x.Position.x),
                Pose.Average(y=>y.Position.y),
                Pose.Average(z=>z.Position.z)
            ) ;
            return handAVG;
        }
    }


    /*// Start is called before the first frame update
    private int layer_mask = 1 << 6;

    private Vector3 wallPos;
    public bool Editing = false;
    private float  wallTiming = 0;
   // private bool walltimingOn = false;

    public float timeRemaining  = 0;

    public GameObject pos1;
    public GameObject pos2;

    public GameObject LGameObject;
    public GameObject RGameObject;

    public float wallWidth = 10;
    public BoxCollider _BoxCollider;
    void Start()
    {
        _BoxCollider = GetComponent<BoxCollider>();
        _BoxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

       
        if (Editing)
        {
            updateWallPos();

            timeRemaining += Time.deltaTime;
            if(timeRemaining < 1)                GetComponent<BoxCollider>().enabled = false;

            if (timeRemaining > 1)
            {
                GetComponent<BoxCollider>().enabled = true;
                NewRayCheck();
                if (LGameObject) LGameObject.GetComponent<wall>().NewRayCheck();
                if (RGameObject) RGameObject.GetComponent<wall>().NewRayCheck();

                if (timeRemaining > 3)
                {
                    
                    Editing = false;

                }

                
            }
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
           // NewRayCheck();
        }
    }

    void updateWallPos()
    {
        List<MixedRealityPose> LPose = new List<MixedRealityPose>();
        List<MixedRealityPose> RPose = new List<MixedRealityPose>();

       MixedRealityPose LthumbTip,LIndexTip,LMiddleTip,LRingTip,LPinkTip;
       MixedRealityPose RthumbTip,RIndexTip,RMiddleTip,RRingTip,RPinkTip;
       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out LthumbTip))         
           LPose.Add(LthumbTip);
       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out LIndexTip))        
           LPose.Add(LthumbTip);

       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out LMiddleTip))       
           LPose.Add(LMiddleTip);

       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out LRingTip))        
           LPose.Add(LMiddleTip);

       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out LPinkTip))        
           LPose.Add(LRingTip);

       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out RthumbTip))        
           RPose.Add(RthumbTip);

       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out RIndexTip))        
           RPose.Add(RIndexTip);

       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out RMiddleTip))       
           RPose.Add(RMiddleTip);

       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out RRingTip))        
           RPose.Add(RRingTip);

       if(HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out RPinkTip))       
           RPose.Add(RPinkTip);

       Vector3 LhandAVG =new Vector3(
            LPose.Average(x=>x.Position.x),
            LPose.Average(y=>y.Position.y),
            LPose.Average(z=>z.Position.z)
        ) ;
        Vector3 RhandAVG =new Vector3(
            RPose.Average(x=>x.Position.x),
            RPose.Average(y=>y.Position.y),
            RPose.Average(z=>z.Position.z)
        ) ;


    

        Vector3 newWallPos = Vector3.Lerp(LhandAVG, RhandAVG, 0.5f);

        
        if (Vector3.Distance(newWallPos, transform.position) > 0.01)
        {
            transform.position = Vector3.Lerp(LhandAVG, RhandAVG, 0.5f);
            timeRemaining = 0;
        }
        
        
        
        Quaternion wallRotation = Quaternion.LookRotation(LhandAVG - RhandAVG, Vector3.up);
        wallRotation.x = 0;
        wallRotation.z = 0;
        
        if (Math.Abs(transform.rotation.y - wallRotation.y)>0.01)
        {
            transform.rotation = wallRotation;
            timeRemaining = 0;
            
        }
        
    }

    void NewRayCheck()
    {

        RaycastHit leftOut;
        RaycastHit RightOut;

        Vector3 start = pos1.transform.TransformDirection(Vector3.forward);
        Ray Left = new Ray(pos2.transform.position, start * 1000);

        Vector3 end = pos2.transform.TransformDirection(Vector3.back);
        Ray Right = new Ray(pos1.transform.position, end * 1000);

        Vector3 newScale = transform.localScale;
        Vector3 newPos = transform.position;

        float offetSet = 0;

        float dir = 0;
        if (Physics.Raycast(Left, out leftOut,layer_mask))
        {
            if (leftOut.transform != this.transform)
            {
                Debug.DrawRay(pos2.transform.position, start * leftOut.distance, Color.red);
                RGameObject = leftOut.transform.gameObject;
                RGameObject.GetComponent<wall>().LGameObject = this.gameObject;
                offetSet = Mathf.Abs(newScale.z/2-leftOut.distance);
                dir = leftOut.distance> newScale.z?1:-1;

            }
            
           
           
        }
   
        if (Physics.Raycast(Right, out RightOut))
        {
            if (RightOut.transform != this.transform)
            {
                Debug.DrawRay(pos1.transform.position, end * RightOut.distance, Color.red, layer_mask);
                LGameObject = RightOut.transform.gameObject;
                LGameObject.GetComponent<wall>().RGameObject = this.gameObject;
                offetSet = Mathf.Abs(newScale.z / 2 - RightOut.distance);
                dir = RightOut.distance > newScale.z ? 1 : -1;
            }
        }
        
        if (RGameObject&& LGameObject)
        {
            Vector3 scale = transform.localScale;
            scale.z = Vector3.Distance(leftOut.point,RightOut.point);
            transform.localScale = scale;
            Vector3 centerPos = transform.position;
            centerPos.z = Vector3.Lerp(leftOut.point, RightOut.point, 0.5f).z;
            transform.position =centerPos;
        }
        else
        {
            Vector3 currentScale = transform.localScale;
            currentScale.z += offetSet*dir;
            transform.localScale = currentScale;
        }

    }

    /*public void setScale(float Scale)
    {
        if (Scale < 0.01)
        {
            return;
            
        }
        if (LGameObject.GetComponent<wall>() && RGameObject.GetComponent<wall>())
        {
            Vector3 scale = transform.localScale;
            scale.z = Vector3.Distance(LGameObject.transform.position,RGameObject.transform.position);
            transform.localScale = scale;
            transform.localPosition = Vector3.Lerp(LGameObject.transform.position,RGameObject.transform.position,0.5f);
        }
    
       
            Vector3 currentScale = transform.localScale;
            currentScale.z += Scale;
            transform.localScale = currentScale;

           
    }#1#
    
    void RayCheck()
    {
        RaycastHit leftOut;
        RaycastHit RightOut;

        Vector3 start = pos1.transform.TransformDirection(Vector3.forward);
       // Debug.DrawRay(pos2.transform.position, start * 1000, Color.red);
        Ray Left = new Ray(pos2.transform.position, start * 1000);

        Vector3 end = pos2.transform.TransformDirection(Vector3.back);
       // Debug.DrawRay(pos1.transform.position, end * 1000, Color.blue);
        Ray Right = new Ray(pos1.transform.position, end * 1000);

        Vector3 newScale = transform.localScale;
        Vector3 newPos = transform.position;

        float distance = 0;
        float offetSet = 0;

        
        if (Physics.Raycast(Left, out leftOut))
        {
            distance += leftOut.distance;
            Debug.DrawRay(pos2.transform.position, start * leftOut.distance, Color.red);
           LGameObject = leftOut.transform.gameObject;
           LGameObject.GetComponent<wall>().RGameObject = this.gameObject;

           offetSet -=(newScale.z / 2-leftOut.distance)/2;

        }
        else
        {
            distance += newScale.z/2;
        }
        
        if (Physics.Raycast(Right, out RightOut))
        {
            distance += RightOut.distance;
            RGameObject = RightOut.transform.gameObject;
            Debug.DrawRay(pos1.transform.position, end * RightOut.distance, Color.red);
            RGameObject.GetComponent<wall>().LGameObject = this.gameObject;
           
      
            offetSet +=(newScale.z / 2-RightOut.distance)/2;

        }
        else
        {
            distance += newScale.z/2;
        }



        newPos.z+= offetSet;
        transform.position = newPos;
    }*/
}




  

