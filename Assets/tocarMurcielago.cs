using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tocarMurcielago : MonoBehaviour
{

    
    public Transform jugador;
    public Transform posParticulas;
    public float tamanoRandom;
    public int puntos;
    public Text textPuntos;
    public Transform moverObjeto;
    float hipotenusa;
    float pasoEnX;
    float pasoEnZ;
    public float velocidad = 0.05f;
    float posX;
    float posZ;
    bool entrar = true;   

    public ParticleSystem particleLauncher;

    // Start is called before the first frame update
    void Start()
    {
        cambiarPos();
        textPuntos.text = puntos.ToString();
        soundSystemFondo.instance.PlayMusic();
        //Debug.Log(transform.position);        
    }

    void Update() 
    {        
        hipotenusa = Mathf.Sqrt(Mathf.Pow(transform.position.x,2)+ Mathf.Pow(transform.position.z, 2));
        acercarse();

        if ((Input.touchCount > 0) && (int.Parse(textPuntos.text) != 10) )
        {   
           soundSystem.instance.PlayShoot();       
           //explotar();
        }

        if ((int.Parse(textPuntos.text) > 9) && (entrar == true)){
            entrar = false;
            soundSystem.instance.PlayCoin();            
        }
        

        //Debug.Log(transform.position +" "+ hipotenusa);
    }

    private void acercarse()
    {
        if (hipotenusa > 2)
        {
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x + pasoEnX, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - pasoEnX, transform.position.y, transform.position.z);
            }

            if (transform.position.z < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + pasoEnZ);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - pasoEnZ);
            }
        }                
    }

    private void OnMouseDown()  // Aqui se realizan acciones cuando se da un click sobre el objeto
    {
        explotar();
        cambiarPos();
        sumarPuntos();
        //soundSystem.instance.PlayCoin();  // Se llama al sistema de sonido y se toca la moneda
    }

    void sumarPuntos ()  // Aqui se suma la puntuación y se aumenta la velocidad
    {
        puntos++;
        textPuntos.text = puntos.ToString();
        velocidad = velocidad + 0.0025f;
    }

    void cambiarPos()  // Aqui se decide una nueva posición y se calcula la velocidad del objeto
    {
        hipotenusa = 25;
        posX = Random.Range(-tamanoRandom, tamanoRandom);
        posZ = Mathf.Sqrt(Mathf.Pow(hipotenusa, 2) - Mathf.Pow(posX, 2));
        //Debug.Log("Pocisiones "+posX +"  -  "+ posZ);
        if (Random.Range(0,3) > 1)
        {
            posZ = -posZ;
        }        
        transform.position = new Vector3(posX, transform.position.y, posZ);
        Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
        //Debug.Log("Pos jugador es: "+posJugador);
        transform.LookAt(posJugador);
        if (Mathf.Abs(transform.position.x) > Mathf.Abs(transform.position.z))
        {
            pasoEnX = velocidad;
            pasoEnZ = Mathf.Abs(transform.position.z) / (Mathf.Abs(transform.position.x) / pasoEnX);
        }
        else
        {
            pasoEnZ = velocidad;
            pasoEnX = Mathf.Abs(transform.position.x) / (Mathf.Abs(transform.position.z) / pasoEnZ);            
        }
    }

    void explotar(){              
        //Debug.Log(transform.position);
        posParticulas.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        particleLauncher.Emit(12) ;   
    }

}
