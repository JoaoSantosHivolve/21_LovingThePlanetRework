using GoogleARCore;
using GoogleARCore.Examples.ObjectManipulation;
using UnityEngine;

public class AugmentedAnimal : MonoBehaviour
{
    public AugmentedImage Image;
    [HideInInspector] public Anchor anchor;
    [HideInInspector] public GameObject ManipulatorPrefab;

    public void Init()
    {
        //TEST IF IT WORKS, SET ROTATION STRAIGHT AND THEN CRETE ANCHORS FOR THE MANIPULATOR
        transform.rotation = Quaternion.Euler(0, 180, 0);
        // Instantiate manipulator.
        var manipulator =
            Instantiate(ManipulatorPrefab, transform.position, transform.rotation);
        //Make window model a child of the manipulator
        transform.parent = manipulator.transform;

        //Make manipulator a child of the anchor
        manipulator.transform.parent = anchor.transform;

        //Select the placed object
        manipulator.GetComponent<Manipulator>().Select();
    }

    public void Update()
    {
        if (Image == null 
            || Image.TrackingState != TrackingState.Tracking)
        {
            //this.gameObject.SetActive(false);
            return;
        }

        //float halfWidth = Image.ExtentX / 2;
        //float halfHeight = Image.ExtentZ / 2;
        //
        //this.transform.localPosition = (halfWidth * Vector3.left) + (halfHeight * Vector3.back)
        //        + (halfWidth * Vector3.right) + (halfHeight * Vector3.back)
        //        + (halfWidth * Vector3.left) + (halfHeight * Vector3.forward)
        //        + (halfWidth * Vector3.right) + (halfHeight * Vector3.forward);
    }
}
