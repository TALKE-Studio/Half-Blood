using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RotacaoPersonagem : MonoBehaviour {

	Transform t;
	public static float x;
	public static float z;
	float ang;
	Quaternion qtan;
	public static Animator animator;
	public static bool segurando = false;
	public static bool onTrigger = false;
	Vector3 posBox;
	float posX;
	float posY;
	public static bool vertical = false;
	public static bool Horizontal = false;
	Collider colisor;
	public static bool naoMexer = false;

    // Use this for initialization
    void Start () {
		t = GetComponent<Transform> ();
		animator = GetComponent<Animator> ();
    }

	// Update is called once per frame
	void Update () {
        if (naoMexer == false) {
            x = CrossPlatformInputManager.GetAxis("Horizontal");
            z = CrossPlatformInputManager.GetAxis("Vertical");

        }
        //x= Input.GetAxis ("Horizontal");
        //z= Input.GetAxis ("Vertical");
        if (onTrigger == true) {
            StartCoroutine(EstatuaC());
        }
        Rotacao ();
		Animacao ();
	}

    IEnumerator EstatuaC() {
        if (CrossPlatformInputManager.GetButtonDown("Jump") == true || Input.GetKeyDown(KeyCode.Space) == true) {
            gameObject.transform.position = posBox;
        }
        if (CrossPlatformInputManager.GetButton("Jump") == true || Input.GetKey(KeyCode.Space) == true) {
            segurando = true;
            //gameObject.transform.position = posBox;//está travando o pers e se esta segurando o botao o pers nao gruda na estatua
            transform.LookAt(new Vector3(colisor.gameObject.GetComponent<Transform>().transform.position.x, gameObject.transform.position.y, colisor.gameObject.GetComponent<Transform>().transform.position.z));
            if (colisor.gameObject.tag != "Lobinho") {
                yield return new WaitForSecondsRealtime(0.1f);
                colisor.gameObject.transform.SetParent(gameObject.transform, true);
                BoxCollider[] col = colisor.gameObject.GetComponents<BoxCollider>();
                foreach (BoxCollider c in col) {
                    if (c.isTrigger == true) {
                        c.enabled = false;
                        c.enabled = true;
                    } else {
                        c.enabled = false;
                        c.enabled = true;
                    }
                }
            } else {
                naoMexer = true;
            }
            if (posX < 1 && posX > -1) {
                vertical = true;
                Horizontal = false;
                //GameObject.FindGameObjectWithTag ("JoyStick").GetComponent<Joystick> ().axesToUse = Joystick.AxisOption.OnlyVertical;
            }
            if (posY < 1 && posY > -1) {
                Horizontal = true;
                vertical = false;
                //GameObject.FindGameObjectWithTag ("JoyStick").GetComponent<Joystick> ().axesToUse = Joystick.AxisOption.OnlyHorizontal;
            }

        } else {
            segurando = false;
            colisor.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Chao").gameObject.transform, true);
            naoMexer = false;
            vertical = false;
            Horizontal = false;
            BoxCollider[] col = colisor.gameObject.GetComponents<BoxCollider>();
            foreach (BoxCollider c in col) {
                if (segurando == true) {
                    if (c.isTrigger == true) {
                        c.enabled = false;
                        c.enabled = true;
                    } else {
                        c.enabled = false;
                        c.enabled = true;
                    }
                }
            }
            GameObject.FindGameObjectWithTag("JoyStick").GetComponent<Joystick>().axesToUse = Joystick.AxisOption.Both;
        }
    }

	void Rotacao(){
		if (segurando == false) {
			ang = Mathf.Atan2 (-x, z);
			ang = ang * Mathf.Rad2Deg;
			qtan = Quaternion.AngleAxis (ang, new Vector3 (0, -1, 0));
			if (x != 0 || z != 0) {
				t.rotation = Quaternion.RotateTowards (t.rotation, qtan, 700 * Time.deltaTime);
			}
		}
	}

	void Animacao(){
		animator.SetBool ("PegouEstatua", segurando);
		if (x != 0 || z != 0) {
            if(x>0 && z > 0) {
                if (x > z) {
                    animator.SetFloat("Blend", x);
                    if (animator.GetFloat("Blend") <= 0.5) {
                        animator.speed = x * 2;
                    }
                } else {
                    animator.SetFloat("Blend", z);
                    if (animator.GetFloat("Blend") <= 0.5) {
                        animator.speed = z * 2;
                    }
                }
            }
            if (x < 0 && z > 0) {
                float horz = x * -1;
                if (horz > z) {
                    animator.SetFloat("Blend", horz);
                    if (animator.GetFloat("Blend") <= 0.5) {
                        animator.speed = horz * 2;
                    }
                } else {
                    animator.SetFloat("Blend", z);
                    if (animator.GetFloat("Blend") <= 0.5) {
                        animator.speed = z * 2;
                    }
                }
            }
            if (z < 0 && x > 0) {
                    float vert = z * -1;
                    if (vert > x) {
                        animator.SetFloat("Blend", vert);
                    if (animator.GetFloat("Blend") <= 0.5) {
                        animator.speed = vert * 2;
                    }
                } else {
                        animator.SetFloat("Blend", x);
                    if (animator.GetFloat("Blend") <= 0.5) {
                        animator.speed = x * 2;
                    }
                }
            }
            if (x<0 && z<0) {
                float horz = x * -1;
                float vert = z * -1;
                if (horz > vert) {
                   animator.SetFloat("Blend", horz);
                    if (animator.GetFloat("Blend") <= 0.5) {
                        animator.speed = horz * 2;
                    }
                }
                if (vert > horz) {
                    animator.SetFloat("Blend", vert);
                    if (animator.GetFloat("Blend") <= 0.5) {
                        animator.speed = vert * 2;
                    }
                }
            }
		} else {
            animator.speed = 1;
			animator.SetFloat ("Blend", 0);
			animator.SetBool ("EmpurrandoTras", false);
			animator.SetBool ("EmpurrandoFrente", false);
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", 0);
        }
		if (vertical == true && z>0 && posY < 0) {
            print("frente");
            animator.SetFloat("X", z);
            animator.SetFloat("Y", x);
		}else if(z>0 && vertical == true && posY >0){
            print("TRAS2");
            animator.SetFloat("X", z*-1);
            animator.SetFloat("Y", x*-1);
        } else if(z<0 && vertical == true && posY <0){
            print("TRAS");
            animator.SetFloat("X", z);
            animator.SetFloat("Y", x);
        } else if(z<0 && vertical == true && posY >0){
            print("frente2");
            animator.SetFloat("X", z*-1);
            animator.SetFloat("Y", x*-1);
        } else if(Horizontal == true && x>0 && posX<0){
            animator.SetFloat("X", x);
            animator.SetFloat("Y", z*-1);
        } else if(Horizontal == true && x>0 && posX>0){
            animator.SetFloat("X", x*-1);
            animator.SetFloat("Y", z);
        } else if(x<0 && Horizontal == true && posX<0){
            animator.SetFloat("X", x);
            animator.SetFloat("Y", z * -1);
        } else if(x<0 && Horizontal == true && posX>0){
            animator.SetFloat("X", x * -1);
            animator.SetFloat("Y", z);
        }
	}

	/*void OnTriggerEnter(Collider other){
		if (other.tag == "Lobinho" || other.tag == "LoboAzul" || other.tag == "LoboVermelho" || other.tag == "LoboVerde" || other.tag == "LoboRoxo") {
		}
	}*/

	void OnTriggerStay(Collider other){
		if (other.tag == "Lobinho" || other.tag == "LoboAzul" || other.tag == "LoboVermelho" || other.tag == "LoboVerde" || other.tag == "LoboRoxo"|| other.tag == "Lobinho2") {
				onTrigger = true;
			if (segurando == false) {
				posBox = new Vector3 (other.bounds.center.x, gameObject.transform.position.y, other.bounds.center.z);
				posX = (other.bounds.center.x - other.transform.position.x);
				posY = (other.bounds.center.z - other.transform.position.z);
				colisor = other;
			}
		} 
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Lobinho" || other.tag == "LoboAzul" || other.tag == "LoboVermelho" || other.tag == "LoboVerde" || other.tag == "LoboRoxo"|| other.tag == "Lobinho2") {
			if (segurando == false) {
				onTrigger = false;
			}
		}
	}


}

