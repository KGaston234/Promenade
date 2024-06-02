using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myHero;
    public float timeOffset;
    public Vector3 posOffset;
    private Vector3 velocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, myHero.transform.position + posOffset, ref velocity, timeOffset);
    }
}
