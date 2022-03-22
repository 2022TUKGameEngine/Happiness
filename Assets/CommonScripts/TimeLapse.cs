using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLapse : MonoBehaviour
{
    public GameObject dirLight;
    public float TimeForOneDayByMinutes;
    Vector3 angleFactor;

    // Start is called before the first frame update
    void Start()
    {
        angleFactor = new Vector3(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //360.f / (angleFactor.x % 360) = 현재시각(-25%)
        angleFactor.x += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        angleFactor.y += Time.deltaTime * 360f / 60f / TimeForOneDayByMinutes;
        dirLight.transform.eulerAngles = angleFactor;
    }
}
