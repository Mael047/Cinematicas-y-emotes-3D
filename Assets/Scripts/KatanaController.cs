using UnityEngine;

public class KatanaController : MonoBehaviour
{
    [Header("Referencias")]
    public Transform katana;
    public Transform hipSocket;
    public Transform handSocket;
    public Animator animator;

    private bool isDrawn = false;

    public KeyCode drawKey = KeyCode.R;

    void Update()
    {
        if (Input.GetKeyDown(drawKey))
        {
            if (!isDrawn)
            {
                animator.SetTrigger("Draw");
                animator.SetBool("SwordDrawn", true);
                isDrawn = true;
            }
            else
            {
                animator.SetTrigger("Sheathe");
                animator.SetBool("SwordDrawn", false);
                isDrawn = false;
            }

            Debug.Log("estado cambiado -> " + isDrawn);
        }
    }

    public void AttachKatanaToHand()
    {
        katana.SetParent(handSocket);
        katana.localPosition = Vector3.zero;
        katana.localRotation = Quaternion.identity;
    }

    public void AttachKatanaToHip()
    {
        katana.SetParent(hipSocket);
        katana.localPosition = Vector3.zero;
        katana.localRotation = Quaternion.identity;
    }
    public void SetSwordDrawn()
    {
        isDrawn = true;
        animator.SetBool("SwordDrawn", true);
    }

    public void SetSwordSheathed()
    {
        isDrawn = false;
        animator.SetBool("SwordDrawn", false);
    }

}
