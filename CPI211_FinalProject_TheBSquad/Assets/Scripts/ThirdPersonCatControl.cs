using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

    [RequireComponent(typeof (ThirdPersonCat))]
    public class ThirdPersonCatControl : MonoBehaviour
    {
        private ThirdPersonCat m_Character; // A reference to the ThirdPersonCharacter on the object
        public Rigidbody m_Rigidbody;
        public Transform m_Cam;                  // A reference to the main camera in the scenes transform
        public Vector3 m_CamForward;             // The current forward direction of the camera
        public Vector3 m_Move;
        public bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        public bool m_R;
        
        public Vector3 Attack;
		public float AttackPower = 200f;        [Range(1f, 4f)][SerializeField] float m_GravityMultiplier = 1f;
        public float orig_AttackStateCooldown = 0.25f;
        public float AttackStateCooldown = 0.25f;
        public bool AttackState;
        public AudioClip CatthewPounce;
		private AudioSource playerSounds;
        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCat>();
            m_Rigidbody = GetComponent<Rigidbody>();
            playerSounds = GetComponent<AudioSource>();
        }


        private void Update()
        {

        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            m_Jump = CrossPlatformInputManager.GetButton("Jump");
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            m_R = Input.GetKeyDown(KeyCode.R);
            // bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }

            // apply extra gravity from multiplier:
			if (m_Jump && m_Rigidbody.velocity.y >= 0)
			{
				Vector3 extraGravityForce = Physics.gravity * (m_GravityMultiplier/4f);
				m_Rigidbody.AddForce(extraGravityForce);
			}
			else
			{
				Vector3 extraGravityForce = Physics.gravity * m_GravityMultiplier;
				m_Rigidbody.AddForce(extraGravityForce);
			}

            // Rushing attack
            if (m_R && AttackStateCooldown >= 0f) //m_IsGrounded && 
			{
                playerSounds.clip = CatthewPounce;
        		playerSounds.Play();

				AttackState = true;
			}
            
            if (AttackState && AttackStateCooldown >= 0f)
            {
                AttackStateCooldown -= Time.deltaTime;
                Attack = new Vector3(0f,0f,AttackPower);
				m_Rigidbody.AddRelativeForce(Attack,ForceMode.Force);
            }
            else if (AttackStateCooldown < 0f && AttackStateCooldown > -2f)
            {
                AttackStateCooldown -= Time.deltaTime;
                AttackState = false;
                
            }
            else
            {
                AttackStateCooldown = orig_AttackStateCooldown;
            }

			// walk speed multiplier
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 1.5f;

            // pass all parameters to the character control script
            // m_Move = new Vector3(1, 0, 1);
            m_Character.Move(m_Move, m_Jump, m_R);//(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
