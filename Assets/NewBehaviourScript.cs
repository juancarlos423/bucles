using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject esfera;                      //de declarar variable de tipo esfera
    public bool checkbox;                           //se declara variable booleana  para chequear
    int num;                                        //variable entera




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EsferasColores());            
    }

    public IEnumerator EsferasColores() {           //para crear una serie de datos, en este caso esferas
        Color[] color = new Color[6];               //para creara una lista de colores
        num = Random.Range(3, 12);                  //se crea un aleatorio entre 3 y 12
        Color colorObjeto1 = Color.blue;            //se crea una variable de tipo objeto 1
        Color colorObjeto2 = Color.red;             //se crea una variable de tipo objeto 2 

        color[0] = Color.yellow;                    //se crea un listado de 6 colores 
        color[1] = Color.blue;
        color[2] = Color.red;
        color[3] = Color.green;
        color[4] = Color.gray;
        color[5] = Color.cyan;

        if (checkbox == true)                                           //se genera una matriz de bolas entre el rango de 3 y 12 que se solicito
        {

            for (int x = 0; x < num; x++)                               //Ciclo para ir creando objetos de tipo esfera y se mueve en el eje y.
            {
                GameObject objeto1 = null;                              //se crea un objeto y se reiniciando con el valor null
                for (int y = 0; y < num; y++)                           // Ciclo interno para moverse en el eje x creando las esferas.
                {
                    GameObject esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);                        //Crea objeto tipo esfera.
                    esfera.GetComponent<Renderer>().material.color = color[Random.Range(0,color.Length)];        //asigna el un color aleatorio a la esfera
                    esfera.transform.position =new Vector3(y, x, 0);                                             //da la ubicación  a la esfera
                    Comparadora comparar = new Comparadora();                                                    //Crea variable tipo objeto: comparadora.
                    if (objeto1 != null)
                    {
                        colorObjeto2 = esfera.GetComponent<Renderer>().material.color;                           //guarda el color del objeto 2
                        colorObjeto1 = objeto1.GetComponent<Renderer>().material.color;                          //guarda el color del objeto 1
                        esfera.GetComponent<Renderer>().material.color= comparar.colorActual(colorObjeto1,colorObjeto2);        //Asigna el color resultado de comparar el color Actual del objeto 1 con el color del objeto 2
                        objeto1.GetComponent<Renderer>().material.color = comparar.colorAnterior(colorObjeto1, colorObjeto2);   //Asigna el color resultado de comparar el color Anterior del objeto 1 con el color del objeto 2
                    }

                    yield return new WaitForSeconds(0.5f);     //Tiempo que demora antes de aparecer una nueva esfera.
                    objeto1 = esfera;                           
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

//  Crea la clase :Comparadora que permite comparar el color de una esfera que se crea, con el color de la esfera anterior.   Esta clase tiene dos métodos que permiten comparar los colores: colorAnterior y colorActual
//Cuando los dos colores de dos esferas consecutivas se repiten, inmediatamente cambian a color negro.
public class Comparadora
{

    public Color colorV = Color.black;
    // Start is called before the first frame update
    public Color colorAnterior(Color ant, Color prev)
    {
        if (ant == prev)
        {
            ant = colorV;
        }
        return ant;
  
    }
   public Color colorActual(Color ant, Color prev)
    {
        if (ant == prev)
        {
            prev= colorV;
        }
        return prev;
    }
        // Update is called once per frame
        void Update()
    {

    }
}




