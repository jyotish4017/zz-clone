using UnityEngine;
using System.Collections;
using 
UnityEngine.UI;
public class player_scripts : MonoBehaviour {
	
public float speed;
	
private Vector3 dir;
	
public GameObject ps;

private bool isDead;

public GameObject resetBtn;

private int score=0;
	
public Text scoreText;

	
// Use this for initialization
	
void Start () {
		
dir = Vector3.zero;
	
isDead = false;
	
}
 
	
// Update is called once per frame
	
void Update () {
	
if(Input.GetMouseButtonDown(0)&&!isDead)

 {
			
score++;
			
scoreText.text=score.ToString();
			
if(dir==Vector3.forward)
			
{
				
dir=Vector3.left;
			
}
			
else
			
{
				
dir=Vector3.forward;
			
}
		
}

		
float amountToMove=speed*Time.deltaTime;
		
transform.Translate(dir*amountToMove);
		
fixedUpdate();
   
 }
	
void fixedUpdate(){
		
GetComponent<Rigidbody>().AddForce (3 * Physics.gravity);
	
}
	
void OnTriggerEnter(Collider other){
		
if (other.tag == "pickup") {
			
other.gameObject.SetActive(false);
	
Instantiate(ps,transform.position,Quaternion.identity);
	
score+=3;
			
scoreText.text=score.ToString();
		
}
	}
	
void OnTriggerExit(Collider other){
	
if (other.tag == "Tile") {
			
RaycastHit hit;
			
Ray downRay=new Ray(transform.position,-Vector3.up);

if(!Physics.Raycast(downRay,out hit)){
	
resetBtn.SetActive(true);
				
isDead=true;
				
if(transform.childCount>0){
				
transform.GetChild(1).transform.parent=null;

}

}

}
	
}
}