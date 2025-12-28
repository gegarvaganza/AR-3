using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    private FixedJoystick fixedJoystick;
    private Rigidbody rb;

    void Awake()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rb = GetComponent<Rigidbody>();

        // 🔴 VERY IMPORTANT FOR AR
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        if (fixedJoystick == null) return;

        float x = fixedJoystick.Horizontal;
        float y = fixedJoystick.Vertical;

        Vector3 input = new Vector3(x, 0f, y);

        if (input.sqrMagnitude < 0.001f)
            return;

        // ✅ LOCAL movement relative to AR image
        Vector3 move =
            transform.parent.TransformDirection(input);

        rb.MovePosition(
            rb.position + move * speed * Time.fixedDeltaTime
        );

        // ✅ Smooth rotation
        Quaternion targetRotation = Quaternion.LookRotation(move);
        rb.MoveRotation(
            Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime)
        );
    }
}
