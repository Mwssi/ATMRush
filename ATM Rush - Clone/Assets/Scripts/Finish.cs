using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    [SerializeField] private GameObject materialHolder;

    private float speed = 0.5f;
    private new Renderer renderer;
    private float offset;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {

        renderer = materialHolder.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.Instance.isGameOver)
        {

            MaterialOffset();

        }

        score = ATM.counter;

    }

    public void MaterialOffset()
    {

        offset = speed * Time.time;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(-offset, 0));

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Parent")
        {



            for (int i = 0; i < Stack.Instance.collectedObjects.Count; i++)
            {

                Stack.Instance.collectedObjects[i].GetComponent<BoxCollider>().enabled = true;

            }

            Stack.Instance.ParentCollider.enabled = false;



        }
        else if (other.tag == "Collectable")
        {

            int index = Stack.Instance.collectedObjects.IndexOf(other.transform);

            other.gameObject.SetActive(false);

            Stack.Instance.collectedObjects.Remove(other.transform);

            ATM.counter += ((int)other.GetComponent<Collectable>().type);

            


        }
        else if (other.tag == "Collector")
        {

            GameManager.Instance.isGameOver = true;


        }

    }

    

}
