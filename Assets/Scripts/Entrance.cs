using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
	//time between each car
	public float spawnTime = 4f;
    public GameObject car;
    public GameObject wall;
    public GameObject lot;
    public bool condition;
    public float start;
    public float end;
    public int nextNameNumber=0;
    public int objNameNumber;
    public string name;
    public Vector3 lastPos;
    public Vector3 offset;
    private Vector3 entrance;
    private Vector3 boundary;
    public GameObject longCar;
    public bool carCreated;
    //keep track of location of car
    public float carLocation;
    public int count;
    //stores the list of newly created gameobjects
    public List<GameObject> theCars;
    public List<Vector3> positions;
    //public Collider2D entranceCollider;
    //public Collider2D carCollider;
    public bool breakFlag;
    public int currentNumCars;
    public Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        //finds location of the entrance
    	wall = GameObject.Find("Westwall");
    	entrance = new Vector3(wall.transform.position.x, wall.transform.position.y, wall.transform.position.z);
        start = entrance.x;
        carLocation = start;
        //finds location of the boundary of the parking lot 
        lot = GameObject.Find("EntranceLoc");
        boundary = new Vector3(lot.transform.position.x, lot.transform.position.y, lot.transform.position.z);
        end = boundary.x;
        //initialize a name for the newly created car object
        name = "longCar";
        objNameNumber=0;
        theCars = new List<GameObject>();
        //entranceCollider = lot.GetComponent<Collider2D>();
    	StartCoroutine(carWave());

    }

    //create new car objects
    private void createCar(float x){
    	GameObject newCar = Instantiate(car) as GameObject;
        theCars.Add(newCar);
        newCar.AddComponent<CarController>();
        newCar.name = "longCar" + nextNameNumber;
    	newCar.transform.position = new Vector3(x, entrance.y, entrance.z);
        positions.Add(newCar.transform.position);
        Debug.Log("car position " + newCar.transform.position.ToString());
    }

    //continuously spawning new car objects
    IEnumerator carWave(){
        breakFlag = false;
    	while(theCars.Count<10 || breakFlag==false){
            //wait 10 seconds before generating another car
            yield return new WaitForSeconds(spawnTime);
            //create car and attach a collider
            createCar(carLocation);
            //carCollider = theCars[nextNameNumber].AddComponent<Collider2D>();
            nextNameNumber++;
            //if car touches entrance boundary, stop generating cars
            if(carLocation<end){
                breakFlag = true;
                break;
            }
            carLocation-=2.5f;
            carCreated = true;
    	}
    }

    //check every frame if a car has moved, if so shift cars
    void Update(){
        //after the first car object is created, check for its movement
        if(carCreated==true && objNameNumber<10){
            //original position of car
            lastPos = positions[objNameNumber];
            //new position(if moved)
            offset = theCars[objNameNumber].transform.position - lastPos;
            if(offset.x>0.0f){
                //count current cars in list
                currentNumCars = theCars.Count;
                objNameNumber++;
                count = objNameNumber;
                temp = positions[count-1];
                while(count<currentNumCars){
                    theCars[count].transform.position = temp;
                    temp = positions[count];
                    positions[count] = theCars[count].transform.position;
                    count++;
                }
            }
        }
    }
}
