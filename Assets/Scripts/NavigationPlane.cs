using UnityEngine;

public class NavigationPlane : MonoBehaviour
{
    private Vector3 m_StartingPosition;
    private float m_SizeX;
    private float m_SizeY;

    // Start is called before the first frame update
    private void Awake()
    {
        m_StartingPosition = transform.position;
        m_SizeX = GetComponent<MeshCollider>().bounds.extents.x;
        m_SizeY = GetComponent<MeshCollider>().bounds.extents.z;
    }

    public Vector3 GetRandomPosition()
    {
        var x = Random.Range(-m_SizeX, m_SizeX);
        var y = Random.Range(-m_SizeY, m_SizeY);

        return m_StartingPosition + (transform.right * x) + (transform.forward * y);
    }
    
}
