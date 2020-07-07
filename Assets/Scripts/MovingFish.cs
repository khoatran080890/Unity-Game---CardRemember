using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFish : MonoBehaviour
{
    Rigidbody2D rigid; 
    void Start()
    {
        rigid = gameObject.transform.GetComponent<Rigidbody2D>();

        AddRandomForce(3000f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    public void AddRandomForce(float minforce)
    {
        float MinForce = -minforce;
        float MaxForce = MinForce * -1;
        Vector2 FirstForce = new Vector2(Random.Range(MinForce, MaxForce), Random.Range(MinForce, MaxForce));
        rigid.AddForce(FirstForce, ForceMode2D.Force);
    }
   
    public void Button_Click_This()
    {
        Debug.Log("die");
        InfoContainer.numberoffish -= 1;
        InfoContainer.point += 1;
        Destroy(this.gameObject);
    }
}
