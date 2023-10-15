using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private bool IsAI;
    [SerializeField]
    private GameObject Ball;

    private Rigidbody2D Rigidbody;
    private Vector2 PlayerMove;

    void Start()
        => Rigidbody = GetComponent<Rigidbody2D>();

    void Update()
    {
        if (IsAI) {
            InitiateComControll();
        } else {
            InitiatePlayerControll();
        }
    }

	void InitiatePlayerControll()
        => PlayerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));

	private void InitiateComControll()
    {
		if (Ball.transform.position.y > transform.position.y + 0.5f) {
            PlayerMove = new Vector2(0, 1);
        } else if (Ball.transform.position.y < transform.position.y - 0.5f) {
            PlayerMove = new Vector2(0, -1);
        } else {
            PlayerMove = Vector2.zero;
        }
	}

	private void FixedUpdate()
        => Rigidbody.velocity = IsAI ? PlayerMove * (MovementSpeed - (GameManager.Instance.HitCounter * 0.25f)) : PlayerMove * MovementSpeed;
}
