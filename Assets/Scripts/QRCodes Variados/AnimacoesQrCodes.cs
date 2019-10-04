using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacoesQrCodes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++) {
            if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetMouseButtonDown(0)) {
                if (Vector3.Distance(gameObject.transform.position , GameObject.FindGameObjectWithTag("VikingAp").gameObject.transform.position) < 100) {
                    GameObject.FindGameObjectWithTag("VikingAp").GetComponent<Animator>().SetBool("TocouTela" , true);
                }
            }
            if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetMouseButtonUp(0)) {
                if (Vector3.Distance(gameObject.transform.position , GameObject.FindGameObjectWithTag("VikingAp").gameObject.transform.position) < 100) {
                    GameObject.FindGameObjectWithTag("VikingAp").GetComponent<Animator>().SetBool("TocouTela" , false);
                }
                if (Vector3.Distance(gameObject.transform.position , GameObject.FindGameObjectWithTag("ValkiriaAp").gameObject.transform.position) < 100) {
                    GameObject.FindGameObjectWithTag("ValkiriaAp").GetComponent<Animator>().SetTrigger("TocouTela");
                }
            }
        }
    }
}
