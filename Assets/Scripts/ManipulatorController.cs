using GoogleARCore.Examples.ObjectManipulation;
using UnityEngine;

public class ManipulatorController : MonoBehaviour
{
    public bool selection;
    public bool scale;
    public bool rotation;

    private void Start()
    {
        var parent = transform.parent;
        parent.GetComponent<SelectionManipulator>().enabled = selection;
        parent.GetComponent<ScaleManipulator>().enabled = scale;
        parent.GetComponent<RotationManipulator>().enabled = rotation;
    }
}
