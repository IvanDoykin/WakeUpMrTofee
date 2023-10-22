using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Transform _root;
    [SerializeField] private TriggerReceiver _triggerReceiver;

    [SerializeField] private GameObject _interactable;
    [SerializeField] private GameObject _realSizeInteractable;

    private RectTransform _rectTransform;
    private bool _isDragging = false;
    private bool _canBeSpawned = false;

    private Camera _camera;
    private Transform _startParent;

    private List<Collider2D> _colliders = new List<Collider2D>();
    private List<Wood> _woods = new List<Wood>();

    private void Start()
    {
        _triggerReceiver.TriggerEnter += OnTriggerEnter2D;
        _triggerReceiver.TriggerExit += OnTriggerExit2D;

        _rectTransform = GetComponent<RectTransform>();
        _camera = FindObjectOfType<Camera>();
        _startParent = transform.parent;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateState();
        _interactable.SetActive(false);
        _realSizeInteractable.SetActive(true);
        _isDragging = true;
        transform.SetParent(_root, true);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isDragging)
        {
            _isDragging = false;
            if (_canBeSpawned)
            {
                _realSizeInteractable.GetComponent<Wood>().SetUp(_woods[0].GetComponent<Rigidbody2D>());
            }

            else
            {
                _interactable.SetActive(true);
                _realSizeInteractable.SetActive(false);

                transform.SetParent(_startParent, true);
                transform.SetAsFirstSibling();
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isDragging)
        {
            Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, _camera.WorldToScreenPoint(_rectTransform.position).z);
            Vector3 worldPosition = _camera.ScreenToWorldPoint(screenPoint);
            _rectTransform.position = worldPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDragging)
        {
            AddCollider(collision);
            UpdateState();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isDragging)
        {
            RemoveCollider(collision);
            UpdateState();
        }
    }

    private void AddCollider(Collider2D collision)
    {
        var wood = collision.GetComponent<Wood>();
        if (wood != null)
        {
            _woods.Add(wood);
        }
        else
        {
            _colliders.Add(collision);
        }
    }

    private void RemoveCollider(Collider2D collision)
    {
        var wood = collision.GetComponent<Wood>();
        if (wood != null)
        {
            _woods.Remove(wood);
        }
        else
        {
            _colliders.Remove(collision);
        }
    }

    private void UpdateState()
    {
        if (_woods.Count >= 1 && _colliders.Count == 0)
        {
            _realSizeInteractable.GetComponent<SpriteRenderer>().color = Color.white;
            _canBeSpawned = true;
        }
        else
        {
            _realSizeInteractable.GetComponent<SpriteRenderer>().color = Color.red;
            _canBeSpawned = false;
        }
    }
}