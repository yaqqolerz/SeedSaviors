using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class TrashControl : MonoBehaviour
{
    [SerializeField] Trashbin Gearbin;
    [SerializeField] Trashbin Branchbin;
    [SerializeField] GameObject gearBin;
    [SerializeField] GameObject branchBin;
    [SerializeField] GameObject trashBin;
    [SerializeField] GameObject trashlefttrigger;
    [SerializeField] GameObject trashrighttrigger;
    [SerializeField] GameObject gearlefttrigger;
    [SerializeField] GameObject gearrighttrigger;
    [SerializeField] GameObject branchlefttrigger;
    [SerializeField] GameObject branchrighttrigger;
    [SerializeField] Bird Gearbird;
    [SerializeField] GameObject Gearbirddest;
    [SerializeField] Bird Branchbird;
    [SerializeField] GameObject Branchbirddest;
    [SerializeField] Sprite Trash1;
    [SerializeField] SpriteRenderer TrashC;


    private void Update()
    {
        if(Gearbin.TrashCount >= 10 && Branchbin.TrashCount >= 10)
        {
            gearBin.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gearBin.GetComponent<BoxCollider2D>().isTrigger = true; 
            branchBin.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            branchBin.GetComponent<BoxCollider2D>().isTrigger = true;
            trashBin.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            trashlefttrigger.SetActive(true);
            trashrighttrigger.SetActive(true);
            gearlefttrigger.SetActive(false);
            gearrighttrigger.SetActive(false);
            branchlefttrigger.SetActive(false);
            branchrighttrigger.SetActive(false);
            if(Branchbird != null)
            {
                Branchbird.isnotFinished = false;
                Branchbird.transform.position = Vector3.MoveTowards(Branchbird.transform.position, Branchbirddest.transform.position, (1 * Time.deltaTime));
                if (Branchbird.transform.position.x == Branchbirddest.transform.position.x
                    && Branchbird.transform.position.y == Branchbirddest.transform.position.y)
                {
                    Destroy(Branchbird.gameObject);
                }
            }
            if(Gearbird != null)
            {
                Gearbird.isnotFinished = false;
                Gearbird.transform.position = Vector3.MoveTowards(Gearbird.transform.position, Gearbirddest.transform.position, (1 * Time.deltaTime));
                if (Gearbird.transform.position.x == Gearbirddest.transform.position.x
                    && Gearbird.transform.position.y == Gearbirddest.transform.position.y)
                {
                    Destroy(Gearbird.gameObject);
                }
            }
            TrashC.sprite = Trash1;
        }
    }
}
