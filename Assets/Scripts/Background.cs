using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float sizeOfSprite, backgroundMoveSpeed;
    private float _spriteStartPosition;


    void Start()
    {
        _camera = Camera.main;
        sizeOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        _spriteStartPosition = transform.position.x;
    }

    
    void Update()
    {
        var cameraPos = _camera.transform.position.x;
        var temp = cameraPos * (1 - backgroundMoveSpeed);
        var distance = cameraPos * backgroundMoveSpeed;

        var newPosition = new Vector2(_spriteStartPosition + distance, transform.position.y);

        transform.position = newPosition;

        if(temp > _spriteStartPosition + (sizeOfSprite / 2))
        {
            _spriteStartPosition += sizeOfSprite;
        }
        else if(temp < _spriteStartPosition + (sizeOfSprite / 2))
        {
            _spriteStartPosition -= sizeOfSprite;
        }
    }
}
