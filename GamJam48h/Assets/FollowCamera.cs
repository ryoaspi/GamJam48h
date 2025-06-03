using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Transform t_camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      t_camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(player.transform.position.x, y, z);
    }
}
