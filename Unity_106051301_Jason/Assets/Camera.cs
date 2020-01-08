using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Cam, Target;

    public float speed = 3;
    public float t_speed = 100;

    private void Update()
    {

        Vector3 pos = Vector3.Lerp(Cam.position, Target.position, 0.5f * Time.deltaTime * speed);

        print(pos);

        Cam.position = pos;
        float h = Input.GetAxis("Horizontal");
        Cam.Rotate(0, t_speed * h * Time.deltaTime, 0);


    }
}
