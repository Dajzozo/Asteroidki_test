using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_sript_player : MonoBehaviour
{
    [Header("Control Settings")] // dodawanie nag��wk�w przy zmiennych
    public float Speed = 3; // publiczne zmienne do edycji w Unity
    public float Sprint = 2;

    [SerializeField] // uwidocznienie przywatnych zmiennych
    private Rigidbody rb; // prywatna zmienna przechowuj�ca informacje z Rigidbody - systemu fizyki w Unity
    private bool isRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>(); // Przypisanie do zmiennej komponentu Rigidbody - fizyka w Unity
        isRigidbody = TryGetComponent<Rigidbody>(out rb); // sprawdza czy Rigidbody istnieje a jak tak to przypisuje go do rb, jak nie to nie robi nic poza przypisaniem isRigidbody false
    }

    // Update is called once per frame
    void Update()
    {
        float Hdirection, Vdirection, sprint0 = 1;

        // Instrukcja chodzenia w boki, prz�d i ty�, inputy z Unity, sprint na lshift
        // 1 - pozycja bezwzgl�dna w �wiecie (nie uwzgl�dnia obracania si� gracza), 2 - dzia�anie si�� na obiekt, 3 - ruch obrotowy
        if (isRigidbody && (Hdirection = Input.GetAxis("Horizontal")) != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift)) sprint0 = Sprint;
            // 1 transform.Translate(0, 0, direction * Speed * Time.deltaTime * sprint0, Space.World);
            // 2 rb.AddForce(0, 0, direction * Speed * Time.deltaTime * sprint0);

            rb.AddTorque(Hdirection * Speed * Time.deltaTime * sprint0, 0, 0);
        }
        if (isRigidbody && (Vdirection = Input.GetAxis("Vertical")) != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift)) sprint0 = Sprint;
            // 1 transform.Translate(-direction * Speed * Time.deltaTime * sprint0, 0, 0, Space.World);
            // 2 rb.AddForce(-direction * Speed * Time.deltaTime * sprint0, 0, 0);

            rb.AddTorque(0, 0, Vdirection * Speed * Time.deltaTime * sprint0);
        }




    }
}
