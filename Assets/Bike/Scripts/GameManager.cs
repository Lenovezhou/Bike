using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject player;
    public GameObject way;
    public GameObject camera;

    [HideInInspector]
    public PlayerController playerController;
    [HideInInspector]
    public WayController waycontroller;
    [HideInInspector]
    public CameraController cameraController;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        playerController = Instantiate(player).GetComponent<PlayerController>();
        waycontroller = Instantiate(way).GetComponent<WayController>();
        cameraController = Instantiate(camera).GetComponent<CameraController>();

        playerController.Init(this);
        cameraController.Init(playerController.transform);
    }

    public void StartCapture()
    {
        cameraController.StartCapture();
    }
    public string StopCapture()
    {
        return cameraController.StopCapture();
    }

}
