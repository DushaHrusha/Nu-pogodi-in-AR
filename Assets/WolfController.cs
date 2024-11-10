using UnityEngine;

public class WolfController : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
