using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollDetection : MonoBehaviour
{

    public class DetectionClass
    {
        public bool Detected;
    }
    public DetectionClass Detect = new DetectionClass();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Detect.Detected = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Detect.Detected = true;
    }
}
