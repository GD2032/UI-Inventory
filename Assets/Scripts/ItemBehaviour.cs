using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Vector3[] InvEspacos;
    [SerializeField] private Vector3[] BauEspacos;
    public int espacoAtual;
    private RaycastResult raycast;
    public int colecao; //0 - inventario 1 - bau
    private GameObject itemAtual;
    private Vector3 position;
    public static ItemBehaviour item;
    void Start()
    {
        item = this;
        SaveLoadJson.Load();
        for (int i = 0; i < BauEspacos.Length; i++)
        {
            if(colecao == 0)
            {
                transform.localPosition = InvEspacos[espacoAtual];
                Controlador.invEspacosContem[espacoAtual] = true;
            }
            else
            {
                transform.localPosition = BauEspacos[espacoAtual];
                Controlador.bauEspacosContem[espacoAtual] = true;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        raycast = eventData.pointerCurrentRaycast;
        if (raycast.gameObject.tag == "Item")
        {
            itemAtual = eventData.pointerCurrentRaycast.gameObject;
            if (colecao == 1)
            {
                Controlador.bauEspacosContem[espacoAtual] = false;
                for (int i = 0; i < InvEspacos.Length; i++)
                {
                    if (!Controlador.invEspacosContem[i])
                    {
                        colecao = 0;
                        itemAtual.transform.localPosition = InvEspacos[i];
                        Controlador.invEspacosContem[i] = true;
                        espacoAtual = i;
                        break;
                    }
                }
            }
            else
            {
                Controlador.invEspacosContem[espacoAtual] = false;
                for (int i = 0; i < BauEspacos.Length; i++)
                {
                    if (!Controlador.bauEspacosContem[i])
                    {
                        colecao = 1;
                        itemAtual.transform.localPosition = BauEspacos[i];
                        Controlador.bauEspacosContem[i] = true;
                        espacoAtual = i;
                        break;
                    }
                }
            }
        }    
    }
}
