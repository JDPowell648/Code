using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private LivingObject livingObject = new LivingObject(100);
    [SerializeField] private float currentSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private bool isSprinting;
    [SerializeField] private bool isMoving;
    [SerializeField] private float maxStamina;
    [SerializeField] private float currentStamina;
    [SerializeField] private bool fatigued;
    [SerializeField] private float rayLen;
    [SerializeField] private LayerMask rayLayer;
    [SerializeField] private float range;
    [SerializeField] private LayerMask attackMask;
    [SerializeField] private int damage;
    [SerializeField] private float delaySpeed;
    [SerializeField] private float delayProg = 0;
    [SerializeField] private bool delaying;
    public int currentRound = 5;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private float reloadProg = 0;
    [SerializeField] private bool reloading;
    [SerializeField] private int capacity;
    [SerializeField] private bool isMaxAmmo;
    [SerializeField] private GameObject shellUI;
    [SerializeField] private Text capacityText;
    [SerializeField] private GameObject blood;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioSource walkSource;
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private Slider StaminaSlider;
    [SerializeField] private GameObject leftFoot;
    [SerializeField] private GameObject rightFoot;
    [SerializeField] private bool currentFoot = false;
    [SerializeField] private float printTimer;
    [SerializeField] private float footRate;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkSpeed;
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement();
        stamina();
        fireWeapon();
        soundManage();
        UIManage();
        reload();
        footPrints();
    }

    private void movement()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isMoving && !fatigued)
        {
            isSprinting = true;
            currentStamina -= .1f;
            if (currentSpeed < sprintSpeed)
            {
                currentSpeed += (Time.deltaTime * 5);
            }
            if (currentSpeed > sprintSpeed)
            {
                currentSpeed = sprintSpeed;
            }
        }
        else
        {
            isSprinting = false;
            if (currentSpeed > walkSpeed)
            {
                currentSpeed -= (Time.deltaTime * 5);
            }
            if (currentSpeed < walkSpeed)
            {
                currentSpeed = walkSpeed;
            }
        }
        if (Input.GetKey(KeyCode.W) && !drawRay(Vector2.up))
        {
            isMoving = true;
            Vector3 direction = new Vector3(transform.position.x,transform.position.y + (.01f * currentSpeed) , transform.position.z);
            transform.position = direction;
        }
        if (Input.GetKey(KeyCode.S) && !drawRay(Vector2.down))
        {
            isMoving = true;
            Vector3 direction = new Vector3(transform.position.x, transform.position.y - (.01f * currentSpeed), transform.position.z);
            transform.position = direction;
        }
        if (Input.GetKey(KeyCode.A) && !drawRay(Vector2.left))
        {
            isMoving = true;
            Vector3 direction = new Vector3(transform.position.x - (.01f * currentSpeed), transform.position.y, transform.position.z);
            transform.position = direction;
        }
        if (Input.GetKey(KeyCode.D) && !drawRay(Vector2.right))
        {
            isMoving = true;
            Vector3 direction = new Vector3(transform.position.x + (.01f * currentSpeed), transform.position.y, transform.position.z);
            transform.position = direction;
        }
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            isMoving = false;
        }
    }

    private bool drawRay(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLen, rayLayer);
        
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, direction * rayLen, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, direction * rayLen, Color.green);
        }
        RaycastHit2D hit2 = new RaycastHit2D();
        RaycastHit2D hit3 = new RaycastHit2D();
        RaycastHit2D hit4 = new RaycastHit2D();
        RaycastHit2D hit5 = new RaycastHit2D();
        if (direction == Vector2.up || direction == Vector2.down)
        {
            hit2 = Physics2D.Raycast(new Vector3((transform.position.x + .3f), transform.position.y, transform.position.z), direction, rayLen, rayLayer);
            hit3 = Physics2D.Raycast(new Vector3((transform.position.x - .3f), transform.position.y, transform.position.z), direction, rayLen, rayLayer);
            hit4 = Physics2D.Raycast(new Vector3((transform.position.x + .15f), transform.position.y, transform.position.z), direction, rayLen, rayLayer);
            hit5 = Physics2D.Raycast(new Vector3((transform.position.x - .15f), transform.position.y, transform.position.z), direction, rayLen, rayLayer);
            if (hit2.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x + .3f), transform.position.y, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x + .3f), transform.position.y, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit3.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x - .3f), transform.position.y, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x - .3f), transform.position.y, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit4.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x + .15f), transform.position.y, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x + .15f), transform.position.y, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit5.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x - .15f), transform.position.y, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x - .15f), transform.position.y, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit2.collider != null && hit3.collider == null && hit.collider == null && hit4.collider == null && hit5.collider == null)
            {
                Vector3 dir = new Vector3(transform.position.x - .01f, transform.position.y, transform.position.z);
                transform.position = dir;
            }
            if (hit3.collider != null && hit2.collider == null && hit.collider == null && hit4.collider == null && hit5.collider == null)
            {
                Vector3 dir = new Vector3(transform.position.x + .01f, transform.position.y, transform.position.z);
                transform.position = dir;
            }
        }
        if (direction == Vector2.right || direction == Vector2.left)
        {
            hit2 = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y + .3f), transform.position.z), direction, rayLen, rayLayer);
            hit3 = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y - .3f), transform.position.z), direction, rayLen, rayLayer);
            hit4 = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y + .15f), transform.position.z), direction, rayLen, rayLayer);
            hit5 = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y - .15f), transform.position.z), direction, rayLen, rayLayer);
            if (hit2.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y + .3f, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y + .3f, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit3.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y - .3f, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y - .3f, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit4.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y + .15f, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y + .15f, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit5.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y - .15f, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y - .15f, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit2.collider != null && hit3.collider == null && hit.collider == null && hit4.collider == null && hit5.collider == null)
            {
                Vector3 dir = new Vector3(transform.position.x, transform.position.y - .01f, transform.position.z);
                transform.position = dir;
            }
            if (hit3.collider != null && hit2.collider == null && hit.collider == null && hit4.collider == null && hit5.collider == null)
            {
                Vector3 dir = new Vector3(transform.position.x, transform.position.y + .01f, transform.position.z);
                transform.position = dir;
            }
        }

        if (hit.collider != null || hit2.collider != null || hit3.collider != null || hit4.collider != null || hit5.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void stamina()
    {
        if (!isSprinting)
        {
            currentStamina += Time.deltaTime;
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }

        if (currentStamina <= 0)
        {
            currentStamina = 0;
        }

        if (currentStamina > 0 && currentStamina <= 5 && !isSprinting)
        {
            fatigued = true;
        }
        else if (currentStamina <= 0)
        {
            fatigued = true;
        }
        else
        {
            fatigued = false;
        }
    }

    private void reload()
    {
        //needs work
        ammoUI();
        if (currentRound == 5 && !reloading)
        {
            isMaxAmmo = true;
        }
        else
        {
            isMaxAmmo = false;
        }
        if (delaying)
        {
            delayProg += Time.deltaTime;
        }
        if (delayProg >= delaySpeed)
        {
            delaying = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && capacity > 0 && !isMaxAmmo)
        {
            reloading = true;
            if (!reloading)
            {
                reloadProg = 0;
            }
        }
        if (reloading)
        {
            reloadProg += Time.deltaTime;
        }
        int amountToReload = 0;
        if (reloadProg >= reloadSpeed && reloading)
        {
            reloading = false;
            reloadProg = 0;
            amountToReload = 5 - currentRound;
            if (capacity < amountToReload) {
                amountToReload = capacity;
            }

            capacity -= amountToReload;
            currentRound += amountToReload;

            if (currentRound == 5)
            {
                shellUI.transform.GetChild(4).gameObject.SetActive(true);
                shellUI.transform.GetChild(3).gameObject.SetActive(true);
                shellUI.transform.GetChild(2).gameObject.SetActive(true);
                shellUI.transform.GetChild(1).gameObject.SetActive(true);
                shellUI.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (currentRound == 4)
            {
                shellUI.transform.GetChild(3).gameObject.SetActive(true);
                shellUI.transform.GetChild(2).gameObject.SetActive(true);
                shellUI.transform.GetChild(1).gameObject.SetActive(true);
                shellUI.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (currentRound == 3)
            {
                shellUI.transform.GetChild(2).gameObject.SetActive(true);
                shellUI.transform.GetChild(1).gameObject.SetActive(true);
                shellUI.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (currentRound == 2)
            {
                shellUI.transform.GetChild(1).gameObject.SetActive(true);
                shellUI.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (currentRound == 1)
            {
                shellUI.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void ammoUI()
    {
        capacityText.text = currentRound.ToString() + " / " + capacity.ToString();
        if (currentRound == 4)
        {
            shellUI.transform.GetChild(4).gameObject.SetActive(false);
        }
        if (currentRound == 3)
        {
            shellUI.transform.GetChild(3).gameObject.SetActive(false);
        }
        if (currentRound == 2)
        {
            shellUI.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (currentRound == 1)
        {
            shellUI.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (currentRound == 0)
        {
            shellUI.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void fireWeapon()
    {
        if (Input.GetMouseButtonDown(0) && !delaying && !reloading && currentRound > 0)
        {
            delaying = true;
            delayProg = 0;
            currentRound -= 1;
            AudioSource.PlayClipAtPoint(shootClip, transform.position);
            RaycastHit2D hit = Physics2D.Raycast(transform.GetChild(0).position, transform.GetChild(0).right, range, attackMask);
            Debug.DrawRay(transform.GetChild(0).position, transform.GetChild(0).right * range, Color.magenta);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("Hit an enemy! - " + hit.collider.gameObject.name);
                    GameObject enemy = hit.collider.gameObject;

                    enemy.GetComponent<EnemyScript>().livingObject.takeDamage(damage);
                    AudioSource.PlayClipAtPoint(hitClip, hit.point);
                    GameObject bloodObj = Instantiate(blood, hit.point, Quaternion.Euler(new Vector3(0, 0, 0)));

                }
                else
                {
                    Debug.Log("Hit an object: " + hit.collider.gameObject.name);
                }
            }
        }
    }

    private void soundManage()
    {
        if (isSprinting)
        {
            walkSource.pitch = 1.5f;
            footRate = .35f / 1.5f;
        }
        else
        {
            walkSource.pitch = 1;
            footRate = .35f;
        }
        if (isMoving)
        {
            if (!walkSource.isPlaying)
            {
                walkSource.Play();
            }
            else
            {
                walkSource.UnPause();
            }
        }
        else
        {
            walkSource.Pause();
        }
    }

    private void UIManage()
    {
        StaminaSlider.maxValue = maxStamina;
        StaminaSlider.value = currentStamina;
        HealthSlider.maxValue = livingObject.getMaxHealth();
        HealthSlider.value = livingObject.getHealth();
    }

    private void footPrints()
    {
        if (isMoving)
        {
            printTimer += Time.deltaTime;
            if(printTimer >= footRate)
            {
                printTimer = 0;
                if (currentFoot)
                {
                    leftFoot.GetComponent<ParticleSystem>().Play();
                    rightFoot.GetComponent<ParticleSystem>().Stop();
                }
                else
                {
                    rightFoot.GetComponent<ParticleSystem>().Play();
                    leftFoot.GetComponent<ParticleSystem>().Stop();
                }
                currentFoot = !currentFoot;
            }
        }
    }

    public void increaseCapacity(int i)
    {
        capacity += i;
    }
}
