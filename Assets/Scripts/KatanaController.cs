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
            // Pedimos la animación de desenfundar
            animator.SetTrigger("Draw");
            animator.SetBool("SwordDrawn", true);
            isDrawn = true;              // 🔹 AHORA SÍ CAMBIA
        }
        else
        {
            // Pedimos la animación de enfundar
            animator.SetTrigger("Sheathe");
            animator.SetBool("SwordDrawn", false);
            isDrawn = false;              // 🔹 AHORA SÍ CAMBIA
        }

        Debug.Log("estado cambiado -> " + isDrawn);
    }
}

    // ---------- MÉTODOS PARA ANIMATION EVENTS ----------

    // Llamar en el frame donde la espada ya está "en la mano"
    public void AttachKatanaToHand()
    {
        katana.SetParent(handSocket);
        katana.localPosition = Vector3.zero;
        katana.localRotation = Quaternion.identity;
    }

    // Llamar en el frame donde la espada ya está dentro de la funda
    public void AttachKatanaToHip()
    {
        katana.SetParent(hipSocket);
        katana.localPosition = Vector3.zero;
        katana.localRotation = Quaternion.identity;
    }

    // Opcional: actualizar estado lógico
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
