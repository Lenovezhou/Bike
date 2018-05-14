using RenderHeads.Media.AVProVideo;
using RenderHeads.Media.AVProVideo.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private bool isinit = false;
    private GameObject reaplayplayer;
    private VCR vcr;
    private MediaPlayer mediaPlayer1;
    private GameManager gamemanager;
    private Rigidbody rb;
    private string localmoviepath;
    public float acceleration = 1.2f;

    public void Init (GameManager gm)
    {
        gamemanager = gm;
        rb = GetComponent<Rigidbody>();
        reaplayplayer = transform.Find("UICanvas").gameObject;
        vcr = reaplayplayer.transform.Find("VCR").GetComponent<VCR>();
        mediaPlayer1 = reaplayplayer.transform.Find("MediaPlayerA").GetComponent<MediaPlayer>();
        isinit = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isinit)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (h != 0 || v > 0)
            {
                rb.AddForce(new Vector3(h, 0, v) * acceleration);
            }
            else
            {
                rb.AddForce(Vector3.zero);
            }

            CheckForward();
        }
    }

    void CheckForward()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetReaplayRaw(false);
            gamemanager.StartCapture();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            localmoviepath = gamemanager.StopCapture();
        }

        if (Input.GetKey(KeyCode.R))
        {
            SetReaplayRaw(true);
            ReplayMovie(localmoviepath);
        }
    }
    void SetReaplayRaw(bool active)
    {
        reaplayplayer.gameObject.SetActive(active);
    }

    void ReplayMovie(string filepath)
    {
        string[] files = vcr._videoFiles;
        files[0] = filepath;
        vcr._videoFiles = files;
    }

}
