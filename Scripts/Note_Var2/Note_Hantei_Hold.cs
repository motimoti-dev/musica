using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Hantei_Hold : MonoBehaviour {

    private bool Note_Hit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "Damage_Note" || collision.gameObject.name == "notes" || collision.gameObject.name == "Hold_Note" || collision.gameObject.name == "Long_Note") && collision.gameObject != transform.parent.gameObject)
        {
            Note_Hit = true;
            transform.parent.GetComponent<Hold_Note>().Collider_Mode_Set(Note_Hit);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "Damage_Note" || collision.gameObject.name == "notes" || collision.gameObject.name == "Hold_Note" || collision.gameObject.name == "Long_Note") && collision.gameObject != transform.parent.gameObject)
        {
            if (Note_Hit == false)
            {
                Note_Hit = true;
                transform.parent.GetComponent<Hold_Note>().Collider_Mode_Set(Note_Hit);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "Damage_Note" || collision.gameObject.name == "notes" || collision.gameObject.name == "Hold_Note" || collision.gameObject.name == "Long_Note") && collision.gameObject != transform.parent.gameObject)
        {
            Note_Hit = false;
            transform.parent.GetComponent<Hold_Note>().Collider_Mode_Set(Note_Hit);
        }
    }
}
