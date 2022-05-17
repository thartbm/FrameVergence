using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticDotController : MonoBehaviour
{

    public float perceptualOffset = 0.0f;

    private GameObject blue_ref;
    private GameObject red_ref;

    // Start is called before the first frame update
    void Start()
    {
        blue_ref = GameObject.Find("static_blue");
        red_ref = GameObject.Find("static_red");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        perceptualOffset = perceptualOffset + (horizontalInput/100);

        if (Mathf.Abs(perceptualOffset) > 6)
        {
            perceptualOffset = Mathf.Sign(perceptualOffset) * 6;
        }

        // X = 8
        // Z = 0
        // blue Y: 0.35
        // red  Y: -1.5

        // fronto-parallel offset:
        blue_ref.transform.position = new Vector3(8f + (perceptualOffset / 2), 0.0f, 0);
        red_ref.transform.position = new Vector3(8f - (perceptualOffset / 2), -1.4f, 0);

        // vergence offset:
        //blue_ref.transform.position = new Vector3(8.0f, 0.0f, 0f + (perceptualOffset / 2));
        //red_ref.transform.position = new Vector3(8.0f, -1.4f, 0f - (perceptualOffset / 2));
    }
}
