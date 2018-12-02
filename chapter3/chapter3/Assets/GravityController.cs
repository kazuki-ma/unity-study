using UnityEngine;

public class GravityController : MonoBehaviour
{

    /// Gravity accelaration. m/s^2
    const float Gravity = 9.81f;

    // gravity scale
    public float gravityScale = 1.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var v = new Vector3();

        if (true)
        {
            v.x = Input.GetAxis("Horizontal");
            v.z = Input.GetAxis("Vertical");

            if (Input.GetKey("z"))
            {
                v.y = 1.0f;
            }
            else
            {
                v.y = -1.0f;
            }
        }
        else
        {
            v.x = Input.acceleration.x;
            v.z = Input.acceleration.y;
            v.y = Input.acceleration.z;
        }

        Physics.gravity = Gravity * v.normalized * gravityScale;
    }
}
