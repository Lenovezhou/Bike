using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    private Vector3 offset;
    private bool isinit = false;

    [HideInInspector]
    public AVProMovieCaptureFromScene moviecapture;

    public void Init(Transform _target)
    {
        this.target = _target;
        offset = transform.position - target.position;
        moviecapture = GetComponent<AVProMovieCaptureFromScene>();
        isinit = true;
    }

    void Update ()
    {
        if(isinit)
            transform.position = Vector3.Lerp(transform.position, target.position + offset, 0.25f);
	}


    public void StartCapture()
    {
        moviecapture.StartCapture();
    }


    public string StopCapture()
    {
        moviecapture.StopCapture();
        return moviecapture.LastFilePath;
    }

}
