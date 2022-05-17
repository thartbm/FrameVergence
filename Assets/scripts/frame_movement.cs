using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame_movement : MonoBehaviour {

    public float startTime = 0;
    public float period = 1.1f;
    public float amplitude = 3f;

    public int direction = 1;

    private float elapsedTime = 0.0f;
    public float Xoffset = 0;

    private float Yoffset = 0f;
    private float Zoffset = 0f;

    public bool red_on = true;
    public bool blue_on = false;


    private GameObject blue;
    private GameObject red;
    private GameObject purple;

    // spheres behind / in front off frame:
    private Vector3 red_pos = new Vector3(0f, 0f, 2f);
    private Vector3 blue_pos = new Vector3(0f, 2f, -2f);
    private Vector3 off_pos = new Vector3(0f, 0f, -10f);

    // sphere in the same plane as the frame:
    //private Vector3 red_pos = new Vector3(0f, 0f, 0f);
    //private Vector3 blue_pos = new Vector3(0f, 2f, 0f);

    // Use this for initialization
    void Start () {
        // we need to get a start time
        this.startTime = Time.time;

        blue = GameObject.Find("flashed_blue");
        red = GameObject.Find("flashed_red");
        purple = GameObject.Find("moving_purple");
    }
	
	// Update is called once per frame
	void Update () {
        // position of the frame depends on time relative to start
        this.elapsedTime = Time.time - this.startTime;

        // based on the in-lab experiment Python code:
        //if (0.35 - period) > 0:
        //# make sure there is a 350 ms inter-flash interval
        //    extra_frames = int(np.ceil((0.35 - period) / (1 / 60)) * 2)
        //else:
        //     extra_frame = 9
        float extra_time = 0.150f;
        float extperiod = this.period + extra_time;
        float extamp = (this.amplitude / this.period) * extperiod;

        // offset based on amplitude and period settings:
        Xoffset = ( Mathf.Abs( ( (this.elapsedTime % extperiod) / extperiod ) - 0.5f ) - 0.25f ) * 2.0f * extamp;

        Zoffset = (Mathf.Abs(((this.elapsedTime % extperiod) / extperiod) - 0.5f) - 0.25f) * 2.0f * ((4.0f / this.period) * extperiod);
        Yoffset = (Mathf.Abs(((this.elapsedTime % extperiod) / extperiod) - 0.5f) - 0.25f) * 2.0f * ((2.0f / this.period) * extperiod);

        if (Mathf.Abs(Xoffset) > (this.amplitude/2))
        {
            Xoffset = Mathf.Sign(Xoffset) * (this.amplitude / 2);
            //Xoffset = 200f;

            Zoffset = Mathf.Sign(Zoffset) * 2f;
            Yoffset = Mathf.Sign(Yoffset) * 1f;
        }

        Yoffset = Yoffset + 1f;

        // fronto-parallel frame:
        transform.position = new Vector3(Xoffset * this.direction, 1.0f, 0.0f);

        // depth frame:
        //transform.position = new Vector3(0f, 1.0f, Zoffset);

        // moving purple ball in plane:
        //purple.transform.position = new Vector3(0f, Yoffset, 0f);
        // moving purple ball through plane:
        purple.transform.position = new Vector3(0f, Yoffset, Zoffset);
        // no purple ball:
        //purple.transform.position = off_pos;

        red.transform.position = off_pos;
        blue.transform.position = off_pos;

        //# flash any dots?
        //if (((this.elapsedTime + (1 / 30)) % extperiod) < (1.90 / 30))
        //{
        //    this.red_on = true;
        //    red.transform.position = red_pos;
        //}
        //else
        //{
        //    this.red_on = false;
        //    red.transform.position = off_pos;
        //}
        ////            flash_red = true
        //if (((this.elapsedTime + (1 / 30) + (extperiod / 2)) % extperiod) < (1.90 / 30))
        //{
        //    this.blue_on = true;
        //    blue.transform.position = blue_pos;
        //}
        //else
        //{
        //    this.blue_on = false;
        //    blue.transform.position = off_pos;
        //}

    }
}
