using UnityEngine;

public class ScrollingLoop : MonoBehaviour
{
    public GameObject object1; 
    public GameObject object2;
    public float speed = 1f; 
    public float screenWidth = 25f; 

    
    public PlayerController playerController;

    void Update()
    {
       
        if (playerController != null && playerController.isGameOver)
        {
            return; 
        }

        
        object1.transform.Translate(Vector3.left * speed * Time.deltaTime);
        object2.transform.Translate(Vector3.left * speed * Time.deltaTime);

       
        if (object1.transform.position.x < -screenWidth)
        {
            
            object1.transform.position = new Vector3(object2.transform.position.x + screenWidth, object1.transform.position.y, object1.transform.position.z);
        }

        
        if (object2.transform.position.x < -screenWidth)
        {
            
            object2.transform.position = new Vector3(object1.transform.position.x + screenWidth, object2.transform.position.y, object2.transform.position.z);
        }
    }
}
