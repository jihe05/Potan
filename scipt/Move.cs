using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float rptspeed = 150.0f;


    public TextMeshProUGUI textcount;
    int count = 0; 



    void Update()
    {
        float amrmov = moveSpeed *Time.deltaTime;
        float amtRot = rptspeed * Time.deltaTime;

        float ver = Input.GetAxis("Vertical");
        float angle = Input.GetAxis("Horizontal");
    

        transform.Translate(Vector3.forward * ver * amrmov);
        transform.Rotate(Vector3.up * angle * amtRot);


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Potan"))
        {

            Invoke("Player1", 1f);
        }

    }


    private void Player1()
    {

        gameObject.SetActive(false);

        textcount.text = "death : " + ++count;

        Invoke("Player", 0.5f);

    }


    private void Player()
    {
        gameObject.SetActive(true);

        transform.position = new Vector3(0f, 3f, 8f);

        Rigidbody rb = GetComponent<Rigidbody>();
      
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.Euler(0f, 180f, 0f);
        //rb.rotation = Quaternion.identity;


    }   

    



}
