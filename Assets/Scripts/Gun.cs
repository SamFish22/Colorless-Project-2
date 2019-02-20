using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public float range = 100f;
  
    public Camera fpsCam;

    public Material red, green, blue, orange, yellow, indigo, white, black, puppy,karaman;

    List<Material> materials = new List<Material>();

    public GameObject effect;

    private int matIndex = 0;
    public GameObject broom;

    private void Start()
    {
        red = Resources.Load("Materials/red", typeof(Material)) as Material;
        green = Resources.Load("Materials/green", typeof(Material)) as Material;
        blue = Resources.Load("Materials/blue", typeof(Material)) as Material;
        orange = Resources.Load("Materials/orange", typeof(Material)) as Material;
        yellow = Resources.Load("Materials/yellow", typeof(Material)) as Material;
        indigo = Resources.Load("Materials/indigo", typeof(Material)) as Material;
        white = Resources.Load("Materials/white", typeof(Material)) as Material;
        black = Resources.Load("Materials/black", typeof(Material)) as Material;
        puppy = Resources.Load("Materials/puppy", typeof(Material)) as Material;
        karaman = Resources.Load("Materials/karaman", typeof(Material)) as Material;

        effect = Resources.Load("DustStorm", typeof(GameObject)) as GameObject;

        materials.Add(red);
        materials.Add(orange);
        materials.Add(yellow);
        materials.Add(green);
        materials.Add(blue);
        materials.Add(indigo);
        materials.Add(white);
        materials.Add(black);
        materials.Add(puppy);

        materials.Add(karaman);
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            matIndex = (matIndex + 1) % materials.Count;
            Debug.Log("matIndex = " + matIndex + "   , Material: ");//+ materials[matIndex].ToString);
            broom.GetComponent<MeshRenderer>().material = materials[matIndex];
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            matIndex = (matIndex < 1) ? (materials.Count - 1) : (matIndex - 1);
            Debug.Log("matIndex = " + matIndex + "   , Material: ");//+ materials[matIndex].ToString);
            broom.GetComponent<MeshRenderer>().material = materials[matIndex];
        }
    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            GameObject tar = hit.transform.gameObject;

            if (tar != null)
            {
                tar.GetComponent<MeshRenderer>().material = materials[matIndex];
               
            }
            
        }
        Vector3 v = new Vector3(Random.Range(870.7f, 943.1f), -7.11f, Random.Range(322.5f, 482.22f));
        Instantiate(effect, v, Quaternion.Inverse(Quaternion.identity));
    }
}
